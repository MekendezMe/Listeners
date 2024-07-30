using Listeners.DatabaseHelper;
using Listeners.Enums;
using Listeners.Interfaces;
using Listeners.Interfaces.Listener;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Listeners.Forms.Roles.Secretary.Listener
{
    public class ListenerService
    {
        private MySqlClient mySqlClient;
        private string sort = string.Empty;
        private string filter = string.Empty;
        private string search = string.Empty;

        public ListenerService()
        {
            mySqlClient = new MySqlClient();
        }

        public bool CanDelete(string primaryKey)
        {
            return Convert.ToInt32(mySqlClient.GetValue("SELECT COUNT(*) from record where record.listener IN('" + primaryKey + "')")) > 0;
        }
        public bool DeleteRow(string primaryKey)
        {
            List<string> queries = new List<string>()
            {
                {"DELETE FROM passport where passport.id=" +
                "(SELECT passport from document where document.id=(SELECT document from listener where" +
                " listener.id='" + primaryKey + "'))" },
                {"DELETE FROM document where document.id=" +
                "(SELECT document from listener where listener.id='" + primaryKey + "')" },
                {"DELETE FROM listener where listener.id='" + primaryKey + "'" }
            };

            return mySqlClient.ExecuteTransaction(queries);
        }

        public ListenerResponse GetListeners(ListenerRequest listenerRequest)
        {
            int currentPage = listenerRequest.CurrentPage;
            bool hasSearch = false;
            bool searchSuccess = true;

            if (!string.IsNullOrEmpty(listenerRequest.Search))
            {
                search = " ORDER BY CASE when document=(SELECT document.id from document where document.passport=(SELECT id from passport where number='"
                    + listenerRequest.Search + "')) THEN 0 when document IN(SELECT document.id from document where document.passport" +
                    " IN (SELECT id from passport where number LIKE '" + listenerRequest.Search + "%')) THEN 1 ELSE 2 END";
                hasSearch = true;
                currentPage = 1;
            }
            else
            {
                search = string.Empty;
                hasSearch = false;
            }

            if (!string.IsNullOrEmpty(listenerRequest.Filter))
            {
                filter = " WHERE listener.id IN (SELECT record.listener from record where record.group=(SELECT id from listeners.group where name='" + listenerRequest.Filter + "')) ";
                currentPage = 1;
            }
            else
            {
                filter = string.Empty;
            }

            if (!string.IsNullOrEmpty(listenerRequest.Sort))
            {
                if (hasSearch)
                {
                    sort = ", birthday " + (listenerRequest.Sort == Constants.SORT_ASC ? "asc " : "desc ");
                }
                else
                {
                    sort = " order by birthday " + (listenerRequest.Sort == Constants.SORT_ASC ? "asc " : "desc ");
                }

                currentPage = 1;
            }
            else
            {
                sort = string.Empty;
            }

            if (listenerRequest.RowCreated)
            {
                if (hasSearch)
                {
                    sort = ", listener.id desc ";
                }
                else
                {
                    sort = " order by listener.id desc ";
                }

                currentPage = 1;
            }

            if (listenerRequest.RowUpdated)
            {
                if (hasSearch)
                {
                    sort = ", listener.modifiedBy desc ";
                }
                else
                {
                    sort = " order by listener.modifiedBy desc ";
                }

                currentPage = 1;
            }

            if (hasSearch && !SearchIsSuccess(listenerRequest.Search))
            {
                search = string.Empty;
                searchSuccess = false;
            }

            int countPages = GetCountPages();

            currentPage = countPages > 1 ? listenerRequest.CurrentPage : currentPage;

            string pagination = " LIMIT " + listenerRequest.CountRowsInPage + " OFFSET " + ((currentPage - 1) * listenerRequest.CountRowsInPage);

            switch (listenerRequest.Pagination)
            {
                case Pagination.FirstPage:
                    currentPage = Constants.START_CURRENT_PAGE;
                    pagination = " LIMIT " + listenerRequest.CountRowsInPage + " OFFSET 0";
                    break;
                case Pagination.LastPage:
                    currentPage = countPages;
                    int lastPageOffset = (countPages - 1) * listenerRequest.CountRowsInPage;
                    pagination = " LIMIT " + listenerRequest.CountRowsInPage + " OFFSET " + lastPageOffset;
                    break;
                case Pagination.PreviousPage:
                    currentPage -= 1;
                    pagination = " LIMIT " + listenerRequest.CountRowsInPage + " OFFSET " + (currentPage - 1) * listenerRequest.CountRowsInPage;
                    break;
                case Pagination.NextPage:
                    currentPage += 1;
                    pagination = " LIMIT " + listenerRequest.CountRowsInPage + " OFFSET " + (currentPage - 1) * listenerRequest.CountRowsInPage;
                    break;
                case Pagination.None:
                    break;

            }

            DataTable listeners = mySqlClient.GetListeners("SELECT listener.id AS 'Идентификатор', " +
                "surname AS 'Фамилия', " +
                "name AS 'Имя', " +
                "patronymic AS 'Отчество', " +
                "address AS 'Адрес', " +
                "birthday AS 'Дата рождения', " +
                "phone AS 'Телефон', " +
                "(SELECT title FROM employment WHERE listener.employment = employment.id) AS 'Занятость', " +
                "(SELECT title FROM education WHERE listener.education = education.id) AS 'Образование', " +
                "(SELECT name from gender where gender.id=listener.gender) AS 'Пол', " +
                "(SELECT insuranceNumber from document where document.id=listener.document) AS 'СНИЛС', " +
                "(SELECT series FROM passport WHERE passport.id = document.passport) AS 'Серия', " +
                "(SELECT number FROM passport WHERE passport.id = document.passport) AS 'Номер' " +
                "FROM listener " +
                "INNER JOIN document ON listener.document = document.id " + filter + search + sort + pagination);

            countPages = GetCountPages();

            return new ListenerResponse()
            {
                SearchSuccess = searchSuccess,
                Listeners = listeners,
                CountPages = countPages,
                CurrentPage = currentPage,
                CountRows = GetCountRows(),
            };
        }

        private bool SearchIsSuccess(string numberSearch)
        {
            string customFilterForCheck = string.Empty;

            if (filter != string.Empty)
            {
                int index = filter.IndexOf("WHERE");

                if (index >= 0)
                {
                    customFilterForCheck = " AND " + filter.Substring(0, index) + filter.Substring(index + "WHERE".Length);
                }
            }

            string rowsAfterAllConditions = mySqlClient.GetValue(@"
                SELECT COUNT(*)
                FROM listener
                WHERE 
                document IN (
                SELECT document.id 
                FROM document 
                WHERE document.passport = (
                SELECT id 
                FROM passport 
                WHERE number = " + "'" + numberSearch + "')) OR document IN (SELECT document.id FROM document WHERE document.passport IN (" +
                "SELECT id FROM passport WHERE number LIKE '" + numberSearch + "%')) " + customFilterForCheck);

            int countRowsAfterConditions = 0;

            if (!int.TryParse(rowsAfterAllConditions, out countRowsAfterConditions))
            {
                return false;
            }

            if (countRowsAfterConditions <= 0)
            {
                return false;
            }

            return true;
        }

        public string[] GetAllGroups()
        {
            return mySqlClient.FillComboBox("SELECT name from listeners.group");
        }

        public int GetCountPages()
        {
            int countPages = 0;

            try
            {
                countPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(mySqlClient.GetValue("SELECT COUNT(*) from listener " + filter + search + sort)) / 15));
            }
            catch
            {
                return -1;
            }

            return countPages;

        }

        public int GetCountRows()
        {
            int countRows = 0;

            try
            {
                countRows = Convert.ToInt32(mySqlClient.GetValue("SELECT COUNT(*) from listener " + filter + search + sort));
            }
            catch
            {
                return -1;
            }

            return countRows;
        }
    }
}
