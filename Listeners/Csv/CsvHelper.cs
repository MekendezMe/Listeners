using Listeners.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Listeners.Csv
{
    public class CsvHelper
    {
        private MySqlClient sqlClient;

        public CsvHelper()
        {
            sqlClient = new MySqlClient();
        }

        public bool ExportData(string path, string fileName)
        {
            DataTable dataTable = new DataTable();
            StreamWriter writer = null;

            try
            {
                string query = string.Empty;

                switch (fileName)
                {
                    case "customer.csv":
                        query = "SELECT name from customer";
                        break;
                    case "education.csv":
                        query = "SELECT title from education";
                        break;
                    case "employment.csv":
                        query = "SELECT title from employment";
                        break;
                    case "qualification.csv":
                        query = "SELECT name from qualification";
                        break;
                    case "group.csv":
                        query = "SELECT name, countPeople from listeners.group";
                        break;
                }

                dataTable = sqlClient.GetDataTable(query);

                FileStream fileStream = null;
                fileStream = new FileStream(Path.Combine(path, fileName), FileMode.OpenOrCreate);

                writer = new StreamWriter(fileStream, Encoding.UTF8);

                for (int i = 0, len = dataTable.Columns.Count - 1; i <= len; ++i)
                {
                    if (i != len)
                        writer.Write(dataTable.Columns[i].ColumnName + ";");
                    else
                        writer.Write(dataTable.Columns[i].ColumnName);
                }

                writer.Write("\n");

                int count = dataTable.Rows.Count;

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string row = string.Join(";", dataRow.ItemArray);
                    writer.WriteLine(row);
                }

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                writer?.Close();
            }


            return true;
        }

        public bool ImportEducationData(string fileName)
        {
            StreamReader FILE = null;

            try
            {
                string[] array;
                FILE = new StreamReader(fileName);
                string rowText = "";
                int row = 0;
                string insert = "";

                bool newRowsExists = false;

                while ((rowText = FILE.ReadLine()) != null)
                {
                    if (row == 0)
                    {
                        row++;
                        continue;
                    }

                    if (row > 1)
                    {
                        insert += ',';
                    }

                    array = rowText.Split(';');

                    if (sqlClient.GetValue("SELECT id from education where title='" + array[0] + "'").Length > 0) continue;
                    insert += "('" + array[0] + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    newRowsExists = true;
                    row++;
                }

                if (!newRowsExists) { return true; }
                bool isHave = sqlClient.ExecuteRequest("INSERT INTO education (title, modifiedBy) VALUES " + insert + ";");

                if (!isHave)
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                FILE?.Close();
            }

            return true;
        }


        public bool ImportCustomerData(string fileName)
        {
            StreamReader FILE = null;

            try
            {
                string[] array;
                FILE = new StreamReader(fileName);
                string rowText = "";
                int row = 0;
                string insert = "";

                bool newRowsExists = false;

                while ((rowText = FILE.ReadLine()) != null)
                {
                    if (row == 0)
                    {
                        row++;
                        continue;
                    }

                    if (row > 1)
                    {
                        insert += ',';
                    }

                    array = rowText.Split(';');
                    
                    if (sqlClient.GetValue("SELECT id from customer where name='" + array[0] + "'").Length > 0) continue;
                    insert += "('" + array[0] + "')";
                    newRowsExists = true;
                    row++;
                }

                if (!newRowsExists) { return true; }
                bool isHave = sqlClient.ExecuteRequest("INSERT INTO customer (name) VALUES " + insert + ";");

                if (!isHave)
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                FILE?.Close();
            }

            return true;
        }

        public bool ImportEmploymentData(string fileName)
        {
            StreamReader FILE = null;

            try
            {
                string[] array;
                FILE = new StreamReader(fileName);
                string rowText = "";
                int row = 0;
                string insert = "";

                bool newRowsExists = false;

                while ((rowText = FILE.ReadLine()) != null)
                {
                    if (row == 0)
                    {
                        row++;
                        continue;
                    }

                    if (row > 1)
                    {
                        insert += ',';
                    }

                    array = rowText.Split(';');

                    if (sqlClient.GetValue("SELECT id from employment where title='" + array[0] + "'").Length > 0) continue;
                    insert += "('" + array[0] + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    newRowsExists = true;
                    row++;
                }

                if (!newRowsExists) { return true; }
                bool isHave = sqlClient.ExecuteRequest("INSERT INTO employment (title, modifiedBy) VALUES " + insert + ";");

                if (!isHave)
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                FILE?.Close();
            }

            return true;
        }

        public bool ImportQualificationData(string fileName)
        {
            StreamReader FILE = null;

            try
            {
                string[] array;
                FILE = new StreamReader(fileName);
                string rowText = "";
                int row = 0;
                string insert = "";

                bool newRowsExists = false;

                while ((rowText = FILE.ReadLine()) != null)
                {
                    if (row == 0)
                    {
                        row++;
                        continue;
                    }

                    if (row > 1)
                    {
                        insert += ',';
                    }

                    array = rowText.Split(';');

                    if (sqlClient.GetValue("SELECT id from qualification where name='" + array[0] + "'").Length > 0) continue;
                    insert += "('" + array[0] + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    newRowsExists = true;
                    row++;
                }

                if (!newRowsExists) { return true; }
                bool isHave = sqlClient.ExecuteRequest("INSERT INTO qualification (name, modifiedBy) VALUES " + insert + ";");

                if (!isHave)
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                FILE?.Close();
            }

            return true;
        }

        public bool ImportGroupData(string fileName)
        {
            StreamReader FILE = null;

            try
            {
                string[] array;
                FILE = new StreamReader(fileName);
                string rowText = "";
                int row = 0;
                string insert = "";

                bool newRowsExists = false;

                while ((rowText = FILE.ReadLine()) != null)
                {
                    if (row == 0)
                    {
                        row++;
                        continue;
                    }

                    if (row > 1)
                    {
                        insert += ',';
                    }

                    array = rowText.Split(';');

                    if (sqlClient.GetValue("SELECT id from listeners.group where group.name='" + array[0] + "'").Length > 0) continue;
                    insert += "('" + array[0] + "','" + array[1] + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    newRowsExists = true;
                    row++;
                }

                if (!newRowsExists) { return true; }
                bool isHave = sqlClient.ExecuteRequest("INSERT INTO listeners.group (name, countPeople, modifiedBy) VALUES " + insert + ";");

                if (!isHave)
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                FILE?.Close();
            }

            return true;
        }
    }
}
