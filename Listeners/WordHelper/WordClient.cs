using Listeners.DatabaseHelper;
using Listeners.Interfaces;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using ZXing;
using ZXing.Common;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using QRCoder;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Listeners.WordHelper
{
    public class WordClient
    {
        private MySqlClient sqlClient;

        public WordClient()
        {
            sqlClient = new MySqlClient();
        }

        private readonly string receiptPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
            @"\ReportLayout\receipt.doc";

        private readonly string organizationPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
            @"\ReportLayout\contract_org.docx";

        private readonly string representativePath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
            @"\ReportLayout\contract_n.doc";

        private readonly string defaultPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
            @"\ReportLayout\contract_s.docx";

        private readonly string agreePath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
            @"\ReportLayout\contract_agree.docx";

        public bool CreateReceipt(string primaryKey, string primaryKeyListener)
        {
            Word.Application wordApp = null;
            Word.Document wordDocument = null;
            try
            {
                wordApp = new Word.Application()
                {
                    Visible = false
                };

                wordDocument = wordApp.Documents.Open(receiptPath);

                IReceiptReport receipt = sqlClient.FindOne<IReceiptReport>
                    ("SELECT record.code, record.DecorationDate, record.actualPayment AS 'FactPay', course.name AS 'Course'," +
                    "qualification.Name AS 'Qualification', course.Price, organization.littleName," +
                    "organization.inn, organization.kpp, organization.bik," +
                    "organization.paymentAccount, organization.personalAccount, organization.treasureAccount," +
                    "listener.surname, listener.name, listener.patronymic, " +
                    "(SELECT name from organization where id=record.organization) AS 'Customer'" +
                    " FROM record" +
                    " INNER JOIN course on record.course = course.id " +
                    "INNER JOIN qualification on course.qualification = qualification.id " +
                    "INNER JOIN organization on organization.id = 3 " +
                    "INNER JOIN listener on record.listener = '" + primaryKeyListener + "' " +
                    "WHERE record.id='" + primaryKey + "' AND organization.id = 3 AND " +
                    "listener.id='" + primaryKeyListener + "'");

                if (receipt == null) return false;

                string customer = (receipt.Customer != null && receipt.Customer != string.Empty) ?
                    receipt.Customer : receipt.Surname + " " + receipt.Name + " " + receipt.Patronymic;

                ReplaceWord("{Ls}", receipt.LittleName + ", л/с " + receipt.PaymentAccount, wordDocument);
                ReplaceWord("{orgrekviz3}", "ИНН " + receipt.Inn + " КПП " + receipt.Kpp, wordDocument);
                ReplaceWord("{bik}", receipt.Bik, wordDocument);
                ReplaceWord("{dogovor}", receipt.Code, wordDocument);
                ReplaceWord("{data}", receipt.DecorationDate.Replace(" 0:00:00", "") + " ", wordDocument);
                ReplaceWord("{proga}", receipt.Qualification, wordDocument);
                ReplaceWord("{kurs}", receipt.Course, wordDocument);
                ReplaceWord("{customer}", customer, wordDocument);

                ReplaceWord("{Ls1}", receipt.LittleName + ", л/с " + receipt.PaymentAccount, wordDocument);
                ReplaceWord("{orgrekviz31}", "ИНН " + receipt.Inn + " КПП " + receipt.Kpp, wordDocument);
                ReplaceWord("{bik1}", receipt.Bik, wordDocument);
                ReplaceWord("{dogovor1}", receipt.Code, wordDocument);
                ReplaceWord("{data1}", receipt.DecorationDate.Replace(" 0:00:00", "") + " ", wordDocument);
                ReplaceWord("{proga1}", receipt.Qualification, wordDocument);
                ReplaceWord("{kurs1}", receipt.Course, wordDocument);
                ReplaceWord("{customer1}", customer, wordDocument);

                string paymPeriodString = DateTime.Now.ToString("MM.yyyy");

                double factPay = 0.0;
                double price = 0.0;

                if (!double.TryParse(receipt.Price, out price) || !double.TryParse(receipt.FactPay, out factPay)) return false;

                double sum = price - factPay;

                string data = "ST00012|Name=" + receipt.PersonalAccount +
                            "|PersonalAcc=" + receipt.PaymentAccount.Split(' ')[0] +
                            "|BankName=" + string.Join(" ", receipt.PaymentAccount.Split(' ').Skip(1)) + "|BIC=" + receipt.Bik +
                            "|PayeeINN=" + receipt.Inn +
                            "|KPP=" + receipt.Kpp + "|Purpose=Курсы отделения дополнительного образования" +
                            "|childFio=" + customer +
                            "|PaymPeriod=" + paymPeriodString + "|Sum=" + sum;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                using (Bitmap qrCodeImage = qrCode.GetGraphic(2))
                {
                    ControlExistDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "codes"));
                    string qrCodePath = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "codes", "qrCode-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".png");
                    qrCodeImage.Save(qrCodePath, ImageFormat.Png);

                    Range range = wordDocument.Content;
                    range.Find.ClearFormatting();
                    range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                    range.InlineShapes.AddPicture(qrCodePath, Type.Missing, Type.Missing, Type.Missing);
                }

                ControlExistDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "cheques"));
                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "cheques", "cheque-" +
                    DateTime.Now.ToShortDateString() + "-" + receipt.Code.Replace("/", "-") + "-" + receipt.DecorationDate.Replace(" 0:00:00", "") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".doc");
                wordDocument.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                wordDocument.Close();
                wordApp.Quit();
                Marshal.ReleaseComObject(wordDocument);
                Marshal.ReleaseComObject(wordApp);
                Process.Start(pathDocument);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }

        }

        private void ControlExistDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void ReplaceWord(string findText, string text, Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: findText, ReplaceWith: text);
        }

        public bool CreateReportOrganization(string primaryKey, string primaryKeyListener)
        {
            Word.Application wordApp = null;
            Word.Document wordDocument = null;
            try
            {
                wordApp = new Word.Application
                {
                    Visible = false
                };

                wordDocument = wordApp.Documents.Open(organizationPath);

                IReceiptReport receipt = sqlClient.FindOne<IReceiptReport>
                    ("SELECT record.code, record.DecorationDate, record.actualPayment AS 'FactPay', record.startCourse," +
                    "record.EndCourse,  course.name AS 'Course'," +
                    "qualification.Name AS 'Qualification', course.Price, organization.name AS 'FullName', organization.littleName," +
                    "organization.inn, organization.kpp, organization.bik, organization.director," +
                    "organization.paymentAccount, organization.personalAccount, organization.treasureAccount, organization.onlyTreasureAccount, organization.license," +
                    " organization.requisites," +
                    "listener.surname, listener.name, listener.patronymic, listener.phone, listener.birthday, listener.address," +
                    "(SELECT name from organization where id=record.organization) AS 'Customer'," +
                    "passport.series, passport.number, passport.issueDate, passport.issuedBy " +
                    " FROM record" +
                    " INNER JOIN course on record.course = course.id " +
                    "INNER JOIN qualification on course.qualification = qualification.id " +
                    "INNER JOIN organization on organization.id = 3 " +
                    "INNER JOIN listener on record.listener = '" + primaryKeyListener + "' " +
                    " INNER JOIN document on listener.document = document.id " +
                    " INNER JOIN passport on document.passport = passport.id " +
                    "WHERE record.id='" + primaryKey + "' AND organization.id = 3 AND " +
                    "listener.id='" + primaryKeyListener + "'");

                if (receipt == null) return false;

                IOrganization organization = sqlClient
                    .FindOne<IOrganization>("SELECT * from organization where id=(SELECT organization from record where record.id='" +
                    primaryKey + "')");

                if (organization == null) return false;

                string listenerFullName = receipt.Surname + " " + receipt.Name + " " + receipt.Patronymic;

                string director = FormatDirectorName(receipt.Director);

                ReplaceWord("{code}", receipt.Code, wordDocument);
                ReplaceWord("{org_name_little}", receipt.LittleName, wordDocument);
                ReplaceWord("{org_cust_name}", organization.Name, wordDocument);
                ReplaceWord("{date_cont}", receipt.DecorationDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{full_org_title}", receipt.FullName, wordDocument);
                ReplaceWord("{little_org_title}", receipt.LittleName, wordDocument);
                ReplaceWord("{license}", receipt.License, wordDocument);
                ReplaceWord("{director1}", receipt.Director, wordDocument);
                ReplaceWord("{org_cust_name1}", organization.Name, wordDocument);
                ReplaceWord("{org_cust_name2}", organization.Name, wordDocument);
                ReplaceWord("{director_org_cust}", organization.Director, wordDocument);
                ReplaceWord("{listener_name1}", listenerFullName, wordDocument);
                ReplaceWord("{qual}", receipt.Qualification, wordDocument);
                ReplaceWord("{course_title}", receipt.Course, wordDocument);
                ReplaceWord("{hour}", receipt.Duration, wordDocument);
                ReplaceWord("{start_date}", receipt.StartCourse.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{end_date}", receipt.EndCourse.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{listener_name}", listenerFullName, wordDocument);
                ReplaceWord("{start_date1}", receipt.StartCourse.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{end_date1}", receipt.EndCourse.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{price}", receipt.Price, wordDocument);
                ReplaceWord("{treasure}", receipt.TreasureAccount, wordDocument);
                ReplaceWord("{onlyTreasure}", receipt.OnlyTreasureAccount, wordDocument);
                int thousands = int.Parse(receipt.Price) / 1000;
                ReplaceWord("{thous}", thousands.ToString(), wordDocument);
                ReplaceWord("{org_title11}", receipt.FullName, wordDocument);
                ReplaceWord("{org_title_litle11}", receipt.LittleName, wordDocument);
                ReplaceWord("{reausits}", receipt.Requisites, wordDocument);
                ReplaceWord("{INN}", receipt.Inn, wordDocument);
                ReplaceWord("{KPP}", receipt.Kpp, wordDocument);
                ReplaceWord("{pers_acc}", receipt.PersonalAccount, wordDocument);
                ReplaceWord("{payment_acc}", receipt.PaymentAccount, wordDocument);
                ReplaceWord("{director123}", director, wordDocument);
                ReplaceWord("{org_title_litle12}", receipt.LittleName, wordDocument);
                ReplaceWord("{org_title_cust21}", organization.Name, wordDocument);
                ReplaceWord("{ur_add}", organization.Requisites, wordDocument);
                ReplaceWord("{INN_CUST}", organization.INN, wordDocument);
                ReplaceWord("{KPP_CUST}", organization.KPP, wordDocument);
                ReplaceWord("{BIK_CUST}", organization.BIK, wordDocument);
                ReplaceWord("{COR_SC}", organization.TreasureAccount, wordDocument);
                ReplaceWord("{RAS_CUST}", organization.PaymentAccount, wordDocument);
                ReplaceWord("{BANK_CUST}", organization.Bank, wordDocument);
                ReplaceWord("{org_cust_name4}", organization.Name, wordDocument);
                ReplaceWord("{director_customer42}", organization.Director, wordDocument);

                ControlExistDirectory(
                    Path.Combine(
                        Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Организация"));
                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Организация", "contract-" +
                    DateTime.Now.ToShortDateString() + "-" + receipt.Code.Replace("/", "-") + "-" + receipt.DecorationDate.Replace(" 0:00:00", "") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".docx");
                wordDocument.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                wordDocument.Close();
                wordApp.Quit();
                Marshal.ReleaseComObject(wordDocument);
                Marshal.ReleaseComObject(wordApp);
                Process.Start(pathDocument);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        private string FormatDirectorName(string director)
        {

            string[] parts = director.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length <= 2) return director;

            return string.Join(" ", parts.Select((part, index) => index == 0 ? part : part[0] + "."));
        }

        public bool CreateReportAgree(string primaryKey, string primaryKeyListener)
        {
            Word.Application wordApp = null;
            Word.Document wordDocument = null;
            try
            {
                wordApp = new Word.Application
                {
                    Visible = false
                };

                wordDocument = wordApp.Documents.Open(agreePath);

                IReceiptReport receipt = sqlClient.FindOne<IReceiptReport>
                    ("SELECT record.code, record.DecorationDate, record.actualPayment AS 'FactPay', course.name AS 'Course'," +
                    "qualification.Name AS 'Qualification', course.Price, organization.name AS 'FullName', organization.littleName," +
                    "organization.inn, organization.kpp, organization.bik, organization.director," +
                    "organization.paymentAccount, organization.personalAccount, organization.treasureAccount, organization.onlyTreasureAccount," +
                    " organization.license," +
                    " organization.requisites," +
                    "listener.surname, listener.name, listener.patronymic, listener.phone, listener.birthday, listener.address," +
                    "(SELECT name from organization where id=record.organization) AS 'Customer'," +
                    "passport.series, passport.number, passport.issueDate, passport.issuedBy " +
                    " FROM record" +
                    " INNER JOIN course on record.course = course.id " +
                    "INNER JOIN qualification on course.qualification = qualification.id " +
                    "INNER JOIN organization on organization.id = 3 " +
                    "INNER JOIN listener on record.listener = '" + primaryKeyListener + "' " +
                    " INNER JOIN document on listener.document = document.id " +
                    " INNER JOIN passport on document.passport = passport.id " +
                    "WHERE record.id='" + primaryKey + "' AND organization.id = 3 AND " +
                    "listener.id='" + primaryKeyListener + "'");

                if (receipt == null) return false;

                IRepresentative representative = sqlClient
                    .FindOne<IRepresentative>("SELECT * from representative where id=(SELECT representative from record where record.id='" +
                    primaryKey + "')");

                if (representative == null) return false;

                string listenerFullName = receipt.Surname + " " + receipt.Name + " " + receipt.Patronymic;
                string representativeFullName = representative.Surname + " " + representative.Name + " " + representative.Patronymic;
                string director = FormatDirectorName(receipt.Director);

                ReplaceWord("{contract_code}", receipt.Code, wordDocument);
                ReplaceWord("{contract_date}", receipt.DecorationDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{sogl_date}", receipt.DecorationDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{org_title}", receipt.FullName, wordDocument);
                ReplaceWord("{license}", receipt.License, wordDocument);
                ReplaceWord("{director1}", receipt.Director, wordDocument);
                ReplaceWord("{cust_name}", representativeFullName, wordDocument);
                ReplaceWord("{list_name}", listenerFullName, wordDocument);
                ReplaceWord("{birthdate_listener}", receipt.Birthday.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{pass_series_list}", receipt.Series, wordDocument);
                ReplaceWord("{pass_num_list}", receipt.Number, wordDocument);
                ReplaceWord("{ pass_date_list}", receipt.IssueDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{pass_issue_list}", receipt.IssuedBy, wordDocument);
                ReplaceWord("{contract_code2}", receipt.Code, wordDocument);
                ReplaceWord("{contract_code4}", receipt.Code, wordDocument);
                ReplaceWord("{cost_cifr}", receipt.Price, wordDocument);
                ReplaceWord("{cost_cifr1}", receipt.Price, wordDocument);
                ReplaceWord("{treasure}", receipt.TreasureAccount, wordDocument);
                ReplaceWord("{onlyTreasure}", receipt.OnlyTreasureAccount, wordDocument);
                ReplaceWord("{org_title}", receipt.FullName, wordDocument);
                ReplaceWord("{info_req}", receipt.Requisites, wordDocument);
                ReplaceWord("{INN1}", receipt.Inn, wordDocument);
                ReplaceWord("{KPP1}", receipt.Kpp, wordDocument);
                ReplaceWord("{personal_acc}", receipt.PersonalAccount, wordDocument);
                ReplaceWord("{ras}", receipt.PaymentAccount, wordDocument);
                ReplaceWord("{bik}", receipt.Bik, wordDocument);
                ReplaceWord("{orf_title_litle5}", receipt.LittleName, wordDocument);
                ReplaceWord("{orf_title_litle6}", receipt.LittleName, wordDocument);
                ReplaceWord("{dir2}", director, wordDocument);
                ReplaceWord("{sur_list}", receipt.Surname, wordDocument);
                ReplaceWord("{name_list}", receipt.Name, wordDocument);
                ReplaceWord("{patronymic_list}", receipt.Patronymic, wordDocument);
                ReplaceWord("{address }", receipt.Address, wordDocument);
                ReplaceWord("{phone}", receipt.Phone, wordDocument);
                ReplaceWord("{sur_cust}", representative.Surname, wordDocument);
                ReplaceWord("{name_cust}", representative.Name, wordDocument);
                ReplaceWord("{patronymic_cust}", representative.Patronymic, wordDocument);
                ReplaceWord("{address_cust}", representative.Address, wordDocument);
                ReplaceWord("{phone_cust}", representative.Phone, wordDocument);

                ControlExistDirectory(
                    Path.Combine(
                        Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Мат-капитал"));

                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Мат-капитал", "contract-" +
                    DateTime.Now.ToShortDateString() + "-" + receipt.Code.Replace("/", "-") + "-" + receipt.DecorationDate.Replace(" 0:00:00", "") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".docx");
                wordDocument.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                wordDocument.Close();
                wordApp.Quit();
                Marshal.ReleaseComObject(wordDocument);
                Marshal.ReleaseComObject(wordApp);
                Process.Start(pathDocument);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool CreateReportWithRepresentative(string primaryKey, string primaryKeyListener)
        {
            Word.Application wordApp = null;
            Word.Document wordDocument = null;
            try
            {
                wordApp = new Word.Application
                {
                    Visible = false
                };

                wordDocument = wordApp.Documents.Open(representativePath);

                IReceiptReport receipt = sqlClient.FindOne<IReceiptReport>
                    ("SELECT record.code, record.DecorationDate, record.actualPayment AS 'FactPay', course.name AS 'Course'," +
                    "qualification.Name AS 'Qualification', course.Price, organization.name AS 'FullName', organization.littleName," +
                    "organization.inn, organization.kpp, organization.bik, organization.director," +
                    "organization.paymentAccount, organization.personalAccount, organization.treasureAccount, organization.onlyTreasureAccount, " +
                    "organization.license," +
                    " organization.requisites," +
                    "listener.surname, listener.name, listener.patronymic, listener.phone, listener.birthday, listener.address," +
                    "(SELECT name from organization where id=record.organization) AS 'Customer'," +
                    "passport.series, passport.number, passport.issueDate, passport.issuedBy " +
                    " FROM record" +
                    " INNER JOIN course on record.course = course.id " +
                    "INNER JOIN qualification on course.qualification = qualification.id " +
                    "INNER JOIN organization on organization.id = 3 " +
                    "INNER JOIN listener on record.listener = '" + primaryKeyListener + "' " +
                    " INNER JOIN document on listener.document = document.id " +
                    " INNER JOIN passport on document.passport = passport.id " +
                    "WHERE record.id='" + primaryKey + "' AND organization.id = 3 AND " +
                    "listener.id='" + primaryKeyListener + "'");

                if (receipt == null) return false;

                IRepresentative representative = sqlClient
                    .FindOne<IRepresentative>("SELECT * from representative where id=(SELECT representative from record where record.id='" +
                    primaryKey + "')");

                if (representative == null) return false;

                string listenerFullName = receipt.Surname + " " + receipt.Name + " " + receipt.Patronymic;
                string representativeFullName = representative.Surname + " " + representative.Name + " " + representative.Patronymic;
                string director = FormatDirectorName(receipt.Director);

                ReplaceWord("{code}", receipt.Code, wordDocument);
                ReplaceWord("{date_cont}", receipt.DecorationDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{full_org_title}", receipt.FullName, wordDocument);
                ReplaceWord("{little_org_title}", receipt.LittleName, wordDocument);
                ReplaceWord("{little_org_title7}", receipt.LittleName, wordDocument);
                ReplaceWord("{license}", receipt.License, wordDocument);
                ReplaceWord("{director1}", receipt.Director, wordDocument);
                ReplaceWord("{customer_name}", representativeFullName, wordDocument);
                ReplaceWord("{listener_name}", listenerFullName, wordDocument);
                ReplaceWord("{birth_day}", receipt.Birthday.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{pass_series}", receipt.Series, wordDocument);
                ReplaceWord("{pass_num}", receipt.Number, wordDocument);
                ReplaceWord("{pass_date}", receipt.IssueDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{pass_in}", receipt.IssuedBy, wordDocument);
                ReplaceWord("{qual_title}", receipt.Qualification.ToUpper(), wordDocument);
                ReplaceWord("{course_title}", receipt.Course.ToUpper(), wordDocument);
                ReplaceWord("{listener_name1}", listenerFullName, wordDocument);
                ReplaceWord("{price}", receipt.Price, wordDocument);
                int thousands = int.Parse(receipt.Price) / 1000;
                ReplaceWord("{thous}", thousands.ToString(), wordDocument);
                ReplaceWord("{org_title}", receipt.FullName, wordDocument);
                ReplaceWord("{info_req}", receipt.Requisites, wordDocument);
                ReplaceWord("{INN1}", receipt.Inn, wordDocument);
                ReplaceWord("{KPP1}", receipt.Kpp, wordDocument);
                ReplaceWord("{personal_acc}", receipt.PersonalAccount, wordDocument);
                ReplaceWord("{ras}", receipt.PaymentAccount, wordDocument);
                ReplaceWord("{bik}", receipt.Bik, wordDocument);
                ReplaceWord("{orf_title_litle5}", receipt.LittleName, wordDocument);
                ReplaceWord("{orf_title_litle6}", receipt.LittleName, wordDocument);
                ReplaceWord("{dir2}", director, wordDocument);
                ReplaceWord("{treasure}", receipt.TreasureAccount, wordDocument);
                ReplaceWord("{onlyTreasure}", receipt.OnlyTreasureAccount, wordDocument);
                ReplaceWord("{sur_ listener}", receipt.Surname, wordDocument);
                ReplaceWord("{name_ listener}", receipt.Name, wordDocument);
                ReplaceWord("{patronymic_listner}", receipt.Patronymic, wordDocument);
                ReplaceWord("{address}", receipt.Address, wordDocument);
                ReplaceWord("{phone}", receipt.Phone, wordDocument);
                ReplaceWord("{sur_cust}", representative.Surname, wordDocument);
                ReplaceWord("{name_cust}", representative.Name, wordDocument);
                ReplaceWord("{patronymic_cust}", representative.Patronymic, wordDocument);
                ReplaceWord("{address_customer}", representative.Address, wordDocument);
                ReplaceWord("{phone_custoner}", representative.Phone, wordDocument);

                ControlExistDirectory(
                    Path.Combine(
                        Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Законный-представитель"));

                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Законный-представитель", "contract-" +
                    DateTime.Now.ToShortDateString() + "-" + receipt.Code.Replace("/", "-") + "-" + receipt.DecorationDate.Replace(" 0:00:00", "") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".docx");
                wordDocument.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                wordDocument.Close();
                wordApp.Quit();
                Marshal.ReleaseComObject(wordDocument);
                Marshal.ReleaseComObject(wordApp);
                Process.Start(pathDocument);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public bool CreateReportListener(string primaryKey, string primaryKeyListener)
        {
            Word.Application wordApp = null;
            Word.Document wordDocument = null;
            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = false;
                wordDocument = wordApp.Documents.Open(defaultPath);

                IReceiptReport receipt = sqlClient.FindOne<IReceiptReport>
                    ("SELECT record.code, record.DecorationDate, record.actualPayment AS 'FactPay', course.name AS 'Course'," +
                    "qualification.Name AS 'Qualification', course.Price, organization.name AS 'FullName', organization.littleName," +
                    "organization.inn, organization.kpp, organization.bik, organization.director," +
                    "organization.paymentAccount, organization.personalAccount, organization.treasureAccount, organization.onlyTreasureAccount, " +
                    "organization.license," +
                    " organization.requisites," +
                    "listener.surname, listener.name, listener.patronymic, listener.phone, listener.birthday, listener.address," +
                    "(SELECT name from organization where id=record.organization) AS 'Customer'," +
                    "passport.series, passport.number, passport.issueDate, passport.issuedBy " +
                    " FROM record" +
                    " INNER JOIN course on record.course = course.id " +
                    "INNER JOIN qualification on course.qualification = qualification.id " +
                    "INNER JOIN organization on organization.id = 3 " +
                    "INNER JOIN listener on record.listener = '" + primaryKeyListener + "' " +
                    " INNER JOIN document on listener.document = document.id " +
                    " INNER JOIN passport on document.passport = passport.id " +
                    "WHERE record.id='" + primaryKey + "' AND organization.id = 3 AND " +
                    "listener.id='" + primaryKeyListener + "'");

                if (receipt == null) return false;

                string listenerFullName = receipt.Surname + " " + receipt.Name + " " + receipt.Patronymic;
                string director = FormatDirectorName(receipt.Director);

                ReplaceWord("{code}", receipt.Code, wordDocument);
                ReplaceWord("{date_cont}", receipt.DecorationDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{full_org_title}", receipt.FullName, wordDocument);
                ReplaceWord("{little_org_title}", receipt.LittleName, wordDocument);
                ReplaceWord("{little_org_title7}", receipt.LittleName, wordDocument);
                ReplaceWord("{license}", receipt.License, wordDocument);
                ReplaceWord("{director1}", receipt.Director, wordDocument);
                ReplaceWord("{listener_name}", listenerFullName, wordDocument);
                ReplaceWord("{birth_day}", receipt.Birthday.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{pass_series}", receipt.Series, wordDocument);
                ReplaceWord("{pass_num}", receipt.Number, wordDocument);
                ReplaceWord("{pass_date}", receipt.IssueDate.Replace(" 0:00:00", ""), wordDocument);
                ReplaceWord("{pass_in}", receipt.IssuedBy, wordDocument);
                ReplaceWord("{qual_title}", receipt.Qualification.ToUpper(), wordDocument);
                ReplaceWord("{course_title}", receipt.Course.ToUpper(), wordDocument);
                ReplaceWord("{listener_name1}", listenerFullName, wordDocument);
                ReplaceWord("{price}", receipt.Price, wordDocument);
                int thousands = int.Parse(receipt.Price) / 1000;
                ReplaceWord("{thous}", thousands.ToString(), wordDocument);
                ReplaceWord("{org_title}", receipt.FullName, wordDocument);
                ReplaceWord("{org_title_litle1}", receipt.LittleName, wordDocument);
                ReplaceWord("{treasure}", receipt.TreasureAccount, wordDocument);
                ReplaceWord("{onlyTreasure}", receipt.OnlyTreasureAccount, wordDocument);
                ReplaceWord("{info_req}", receipt.Requisites, wordDocument);
                ReplaceWord("{INN1}", receipt.Inn, wordDocument);
                ReplaceWord("{KPP1}", receipt.Kpp, wordDocument);
                ReplaceWord("{personal_acc}", receipt.PersonalAccount, wordDocument);
                ReplaceWord("{ras}", receipt.PaymentAccount, wordDocument);
                ReplaceWord("{bik}", receipt.Bik, wordDocument);
                ReplaceWord("{orf_title_litle5}", receipt.LittleName, wordDocument);
                ReplaceWord("{org_title_litle6}", receipt.LittleName, wordDocument);
                ReplaceWord("{dir2}", director, wordDocument);
                ReplaceWord("{sur_cust}", receipt.Surname, wordDocument);
                ReplaceWord("{name_cust}", receipt.Name, wordDocument);
                ReplaceWord("{patronymic_listener}", receipt.Patronymic, wordDocument);
                ReplaceWord("{address}", receipt.Address, wordDocument);
                ReplaceWord("{phone}", receipt.Phone, wordDocument);

                ControlExistDirectory(
                    Path.Combine(
                        Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Самостоятельно"));

                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "contracts", "Самостоятельно", "contract-" +
                    DateTime.Now.ToShortDateString() + "-" + receipt.Code.Replace("/", "-") + "-" + receipt.DecorationDate.Replace(" 0:00:00", "") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".docx");
                wordDocument.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                wordDocument.Close();
                wordApp.Quit();
                Marshal.ReleaseComObject(wordDocument);
                Marshal.ReleaseComObject(wordApp);
                Process.Start(pathDocument);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }

        }
    }

}
