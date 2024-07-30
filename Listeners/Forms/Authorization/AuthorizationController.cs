using Listeners.Dictionaries;
using Listeners.Interfaces;
using Listeners.Interfaces.Authorization;
using Listeners.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Authorization
{
    public class AuthorizationController
    {
        private bool captchaIsActive = false;
        private string activeCaptcha = string.Empty;
        private string activeCaptchaWithCrossedSymbols = string.Empty;
        private int countAttempts = 0;
        private AuthorizationView view;
        private AuthorizationService authorizationService = new AuthorizationService();

        public AuthorizationController(AuthorizationView view)
        {
            this.view = view;
        }

        public void Login(AuthorizationRequest candidate)
        {
            if (ValueIsEmpty(candidate.Login.Trim()) || ValueIsEmpty(candidate.Password.Trim()))
            {
                HaveError(Enums.Error.EmptyFields);
                return;
            }

            if (!ValidatePassword(candidate.Password))
            {
                HaveError(Enums.Error.UnvalidatePassword);
                return;
            }

            if (captchaIsActive && activeCaptcha != candidate.Captcha)
            {
                HaveError(Enums.Error.IncorrectCaptcha);
                return;
            }

            AuthorizationResponse authorizationResponse = authorizationService.Login(candidate);

            if (authorizationResponse.Employee == null)
            {
                HaveError(Enums.Error.EmployeeNotFound);
                return;
            }

            GlobalData.Employee = new Dtos.UserDto()
            {
                Name = authorizationResponse.Employee.Name,
                Surname = authorizationResponse.Employee.Surname,
                Patronymic = authorizationResponse.Employee.Patronymic,
                Id = authorizationResponse.Employee.Id,
                Role = Lists.Roles.GetRole(authorizationResponse.Employee.Role),
            };

            view.StartNewForm();
        }

        private void HaveError(Enums.Error error)
        {
            countAttempts++;
            CheckingCaptcha();
            view.ShowError(Dictionaries.Errors.GetError(error));
        }

        private bool ValidatePassword(string password)
        {
            return password.Length >= 5;
        }

        
        private void CheckingCaptcha()
        {
            GenerateCaptcha();

            if (countAttempts == 1)
            {
                view.ShowCaptcha();
                captchaIsActive = true;
            }

            if (countAttempts > 1)
            {
                view.BlockElements(true);
            }

            view.UpdateCaptcha(activeCaptchaWithCrossedSymbols);
        }

        private void GenerateCaptcha()
        {
            string symbols = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            activeCaptcha = string.Empty;
            int lengthCaptcha = 5;
            Random random = new Random();

            for (int i = 0; i < lengthCaptcha; i++) 
            {
                activeCaptcha += symbols[random.Next(0, symbols.Length - 1)];
            }

            GenerateCrossedOutCaptcha();
        }

        private void GenerateCrossedOutCaptcha()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in activeCaptcha)
            {
                stringBuilder.Append($"{c}\u0336");
            }

            activeCaptchaWithCrossedSymbols = stringBuilder.ToString();
        }

        private bool ValueIsEmpty(string value)
        {
            return value.Length == 0;
        }
    }
}
