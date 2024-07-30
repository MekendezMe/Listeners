using Listeners.Enums;
using Listeners.Dictionaries;
using Listeners.Interfaces;
using Listeners.Interfaces.Listener;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Listeners.DatabaseHelper;

namespace Listeners.Forms.Roles.Secretary.Listener
{
    public class ListenerController
    {
        private bool afterConditions = false;
        private Pagination lastPagination = Pagination.None;
        private int lastIndexOfFilter = Constants.START_VALUE_SELECTED_INDEX;
        private int lastIndexOfSort = Constants.START_VALUE_SELECTED_INDEX;
        private int currentPage = Constants.START_CURRENT_PAGE;
        private int countRowsInPage = 15;
        private int countPages = 0;
        private int countRows = 0;
        private ListenerView view;
        private ListenerService listenerService;

        public ListenerController(ListenerView view)
        {
            this.view = view;
            listenerService = new ListenerService();
        }

        public void ActivityControl(DateTime lastActivityTime)
        {
            TimeSpan inactiveDuration = DateTime.Now - lastActivityTime;

            if (inactiveDuration.TotalSeconds > Constants.MAX_INACTIVE_TIME_SECONDS)
            {
                view.StartLoginForm();
            }
        }

        public string[] GetAllGroups()
        {
            return listenerService.GetAllGroups();
        }

        private bool ValidatePrimaryKey(string primaryKey)
        {
            if (!int.TryParse(primaryKey, out int id))
            {
                return false;
            }

            if (id <= 0)
            {
                return false;
            }

            return true;
        }

        private bool CanDelete(string primaryKey)
        {
            return listenerService.CanDelete(primaryKey);
        }


        public void DeleteRow(string primaryKey)
        {
            if (!ValidatePrimaryKey(primaryKey))
            {
                view.ShowMessage(Errors.GetError(Error.NoOneRowFoundByPrimaryKey), "Ошибка", MessageBoxIcon.Error);
                return;
            }

            if (CanDelete(primaryKey))
            {
                view.ShowMessage("Невозможно удалить слушателя, который содержится в договорах", "Ошибка", MessageBoxIcon.Warning);
                return;
            }

            bool isDeleted = listenerService.DeleteRow(primaryKey);

            if (!isDeleted)
            {
                view.ShowMessage(Errors.GetError(Error.DeleteRowNotCompleted), "Ошибка", MessageBoxIcon.Error);
                return;
            }

            view.ResetConditions(true);
            view.LoadData();
        }

        public void GetListeners(string search, string filter, int indexOfFilter, string sort, int indexOfSort, Pagination pagination, bool rowCreated, bool rowUpdated)
        {
            ListenerResponse listenerResponse = listenerService.GetListeners(new ListenerRequest()
            {
                Search = search,
                CurrentPage = currentPage,
                Filter = indexOfFilter == lastIndexOfFilter ? string.Empty : filter,
                Sort = indexOfSort == lastIndexOfSort ? string.Empty : sort,
                Pagination = pagination == lastPagination ? Pagination.None : pagination,
                CountRowsInPage = countRowsInPage,
                RowCreated = rowCreated,
                RowUpdated = rowUpdated,
            });

            currentPage = listenerResponse.CurrentPage;
            countPages = listenerResponse.CountPages;
            countRows = listenerResponse.CountRows;
            ControlPagination(pagination);

            if (listenerResponse.Listeners == null || listenerResponse.Listeners.Rows.Count == 0)
            {
                currentPage = Constants.START_CURRENT_PAGE;
                countPages = Constants.START_CURRENT_PAGE;
                view.ResetConditions(afterConditions);
                view.ShowData(listenerResponse.Listeners, listenerResponse.Listeners.Rows.Count, countRows, currentPage, countPages);
                return;
            }

            if (!listenerResponse.SearchSuccess)
            {
                view.ShowMessage(Errors.GetError(Error.WithInputSearchDataNotFound), "Внимание", MessageBoxIcon.Information);
                view.ResetConditions(afterConditions, onlySearch: true);
                return;
            }

            afterConditions = true;
            view.ShowData(listenerResponse.Listeners, listenerResponse.Listeners.Rows.Count, countRows, currentPage, countPages);
        }


        private void ControlPagination(Pagination pagination)
        {
            view.BlockNextPagesButton(currentPage == countPages ||
                pagination == Pagination.LastPage);

            view.BlockPreviousPagesButton(currentPage == Constants.START_CURRENT_PAGE ||
                pagination == Pagination.FirstPage);
        }
    }
}
