using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Dapper;
using Listeners.Interfaces;
using MySql.Data.MySqlClient;

namespace Listeners.DatabaseHelper
{
    public class MySqlClient
    {
        private static string _connectionString = "server=localhost;uid=root;pwd=root;database=listeners;";
        private static MySqlConnection _connection = new MySqlConnection(_connectionString);

        public DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, _connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return dataTable;
        }

        public DataTable GetListeners(string query)
        {
            DataTable listeners = new DataTable();

            try
            {
                _connection.Open();

                MySqlCommand command = new MySqlCommand(query, _connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(command);
                mySqlDataAdapter.Fill(listeners);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return listeners;
        }
        public T FindOne<T>(string query)
        {
            try
            {
                _connection.Open();

                object data = _connection.QueryFirstOrDefault<T>(query);

                if (data != null && !(data is DBNull))
                {
                    return (T)data;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return default;
        }

        public bool AddRecord(int idListener, string code, string organization, string group, int idCourse,
            DateTime now, int capital, DateTime start, DateTime end, string representative)
        {
            bool isExecute = false;
            try
            {
                _connection.Open();

                string sqlQuery = "INSERT INTO record (listener, code, organization, `group`, course, decorationDate, " +
                "maternityCapital, startCourse, endCourse, representative, paymentStatus, endStatus, creditedStatus," +
                "openStatus, actualPayment, modifiedBy) VALUES (@Listener, @Code, @Organization, @Group, @Course, @DecorationDate, " +
                "@MaternityCapital, @StartCourse, @EndCourse, @Representative, @PaymentStatus, @EndStatus, @CreditedStatus, @OpenStatus, @ActualPayment, @ModifiedBy)";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, _connection);
                cmd.Parameters.AddWithValue("@Listener", idListener);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@Organization", organization != null ? (object)organization : DBNull.Value);
                cmd.Parameters.AddWithValue("@Group", group != null ? (object)group : DBNull.Value);
                cmd.Parameters.AddWithValue("@Course", idCourse);
                cmd.Parameters.AddWithValue("@DecorationDate", now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@MaternityCapital", capital);
                cmd.Parameters.AddWithValue("@StartCourse", start.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EndCourse", end.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Representative", representative != null ? (object)representative : DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentStatus", 2);
                cmd.Parameters.AddWithValue("@EndStatus", 2);
                cmd.Parameters.AddWithValue("@CreditedStatus", 1);
                cmd.Parameters.AddWithValue("@OpenStatus", 1);
                cmd.Parameters.AddWithValue("@ActualPayment", 0);
                cmd.Parameters.AddWithValue("@ModifiedBy", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                isExecute = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return isExecute;
        }

        public bool UpdateRecord(int idRecord, string group, string transferOrder, string expulsionOrder,
            string dateTransferOrder, string dateExpulsionOrder, string statusPay, string statusOpen, string statusEnd,
            string statusCredited, string startCourse, string endCourse)
        {
            bool isExecute = false;

            try
            {
                _connection.Open();

                string sqlQuery = "UPDATE record set startCourse=@StartCourse, endCourse=@EndCourse, record.group" +
                    "=(SELECT id from listeners.group where listeners.group.name=@Group)," +
                    " transferOrder=@TransferOrder, dateTransferOrder=@DateTransferOrder, " +
                    "expulsionOrder=@ExpulsionOrder, dateExpulsionOrder=@DateExpulsionOrder," +
                    "paymentStatus=(SELECT id from paymentStatus where name=@PaymentStatus), endStatus=" +
                    "(SELECT id from endStatus where name=@EndStatus), creditedStatus=(SELECT id from creditedStatus where " +
                    "name=@CreditedStatus), openStatus=(SELECT id from openStatus where name=@OpenStatus), modifiedBy=@ModifiedBy where record.id=@IdRecord";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, _connection);
                cmd.Parameters.AddWithValue("@StartCourse", startCourse);
                cmd.Parameters.AddWithValue("@EndCourse", endCourse);
                cmd.Parameters.AddWithValue("@IdRecord", idRecord);
                cmd.Parameters.AddWithValue("@Group", group != null ? (object)group : DBNull.Value);
                cmd.Parameters.AddWithValue("@TransferOrder", transferOrder != null ? (object)transferOrder : DBNull.Value);
                cmd.Parameters.AddWithValue("@DateTransferOrder", dateTransferOrder != null ? (object)dateTransferOrder : DBNull.Value);
                cmd.Parameters.AddWithValue("@ExpulsionOrder", expulsionOrder != null ? (object)expulsionOrder : DBNull.Value);
                cmd.Parameters.AddWithValue("@DateExpulsionOrder", dateExpulsionOrder != null ? (object)dateExpulsionOrder : DBNull.Value);
                cmd.Parameters.AddWithValue("@PaymentStatus", statusPay);
                cmd.Parameters.AddWithValue("@EndStatus", statusEnd);
                cmd.Parameters.AddWithValue("@CreditedStatus", statusCredited);
                cmd.Parameters.AddWithValue("@OpenStatus", statusOpen);
                cmd.Parameters.AddWithValue("@ModifiedBy", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                isExecute = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return isExecute;
        }

        public List<IFirstPattern> GetInformationForPatternReport(string group)
        {
            List<IFirstPattern> information = new List<IFirstPattern>();

            try
            {
                _connection.Open();

                MySqlCommand command = new MySqlCommand(
                    "SELECT passport.Series AS Series," +
                    " passport.number AS Number," +
                    "  passport.issueDate AS IssueDate," +
                    "    listeners.group.name AS `Group`," +
                    "   course.name AS Course," +
                    "   qualification.name AS Qualification," +
                    "   record.startCourse AS StartCourse," +
                    "   record.endCourse AS EndCourse," +
                    "   course.duration AS Duration," +
                    "   listener.birthday AS Birthday," +
                    "   gender.name AS Gender," +
                    "listener.surname as Surname," +
                    "listener.Name as Name," +
                    "listener.Patronymic as Patronymic," +
                    "   document.insuranceNumber AS InsuranceNumber FROM" +
                    " record" +
                    " JOIN listener ON record.listener = listener.id" +
                    " JOIN   document ON listener.document = document.id" +
                    " JOIN  gender ON listener.gender = gender.id" +
                    " JOIN    course ON record.course = course.id" +
                    " JOIN   qualification ON course.qualification = qualification.id" +
                    " JOIN passport" +
                    " ON document.passport = passport.id    " +
                    " JOIN listeners.group ON record.group = listeners.group.id" +
                    " WHERE   record.group=" +
                    "(SELECT id from listeners.group where name='" + group + "');", _connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    information.Add(new IFirstPattern()
                    {
                        Series = reader["Series"].ToString(),
                        Number = reader["Number"].ToString(),
                        IssueDate = reader["IssueDate"].ToString(),
                        Group = reader["Group"].ToString(),
                        Course = reader["Course"].ToString(),
                        Qualification = reader["Qualification"].ToString(),
                        StartCourse = reader["StartCourse"].ToString(),
                        EndCourse = reader["EndCourse"].ToString(),
                        Birthday = reader["Birthday"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        InsuranceNumber = reader["InsuranceNumber"].ToString(),
                        Duration = reader["Duration"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Name = reader["Name"].ToString(),
                        Patronymic = reader["Patronymic"].ToString()
                    });
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return information;
        }

        public List<IRecordReceipt> GetInformationAboutRecords()
        {
            List<IRecordReceipt> information = new List<IRecordReceipt>();

            try
            {
                _connection.Open();

                MySqlCommand command = new MySqlCommand(
                    "SELECT record.code, record.decorationDate, listener.surname AS 'ListenerSurname', listener.name AS 'ListenerName'," +
                    "listener.patronymic AS 'ListenerPatronymic', course.name AS 'Course', qualification.name AS 'Qualification'," +
                    " listeners.group.name AS 'Group', record.startCourse," +
                    "record.endCourse, record.actualPayment, course.Price, creditedStatus.name AS 'CreditedStatus', openstatus.name AS 'OpenStatus'," +
                    "endstatus.name AS 'EndStatus', paymentStatus.name AS 'PaymentStatus'," +
                    "record.representative, record.organization from record JOIN listener on record.listener = listener.id " +
                    " JOIN listeners.group on record.group = listeners.group.id " +
                    "JOIN course on record.course = course.id " +
                    "JOIN qualification on course.qualification = qualification.id " +
                    "JOIN endStatus on record.endStatus = endStatus.id " +
                    "JOIN creditedStatus on record.creditedStatus = creditedStatus.id " +
                    "JOIN paymentStatus on record.paymentStatus = paymentStatus.id " +
                    "JOIN openStatus on record.openStatus = openStatus.id ", _connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    information.Add(new IRecordReceipt()
                    {
                        ListenerSurname = reader["ListenerSurname"].ToString(),
                        ListenerName = reader["ListenerName"].ToString(),
                        ListenerPatronymic = reader["ListenerPatronymic"].ToString(),
                        Code = reader["Code"].ToString(),
                        DecorationDate = reader["DecorationDate"].ToString(),
                        Course = reader["Course"].ToString(),
                        Qualification = reader["Qualification"].ToString(),
                        Price = reader["Price"].ToString(),
                        Group = reader["Group"].ToString(),
                        ActualPayment = reader["ActualPayment"].ToString(),
                        StartCourse = reader["StartCourse"].ToString(),
                        EndCourse = reader["EndCourse"].ToString(),
                        CreditedStatus = reader["CreditedStatus"].ToString(),
                        EndStatus = reader["EndStatus"].ToString(),
                        OpenStatus = reader["OpenStatus"].ToString(),
                        PaymentStatus = reader["PaymentStatus"].ToString(),
                        Organization = reader["Organization"].ToString(),
                        Representative = reader["Representative"].ToString(),
                    });
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return information;
        }

        public bool ExecuteRequest(string query)
        {
            bool requestIsExecute = false;
            try
            {
                _connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, _connection);
                requestIsExecute = mySqlCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return requestIsExecute;
        }

        public bool ExecuteTransaction(List<string> queries)
        {
            bool transactionSuccessful = false;

            try
            {
                _connection.Open();

                using (MySqlTransaction transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        foreach (string query in queries)
                        {
                            MySqlCommand mySqlCommand = new MySqlCommand(query, _connection, transaction);
                            mySqlCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        transactionSuccessful = true;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return transactionSuccessful;
        }

        public string[] FillComboBox(string query)
        {
            string[] items = new string[0];
            int index = 0;
            try
            {
                _connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, _connection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    Array.Resize(ref items, items.Length + 1);
                    items[index] = mySqlDataReader.GetString(0);
                    index++;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return items;
        }

        public string GetValue(string query)
        {
            string value = string.Empty;

            try
            {
                _connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, _connection);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    if (!mySqlDataReader.IsDBNull(0))
                    {
                        value = mySqlDataReader.GetString(0);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _connection.Close();
            }

            return value;
        }


        public bool ExportDatabase(string path, string fileName)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    using (MySqlBackup sqlBackup = new MySqlBackup(command))
                    {
                        _connection.Open();
                        command.Connection = _connection;
                        sqlBackup.ExportToFile(Path.Combine(path, fileName));
                        _connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool ImportDatabase(string path)
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder(_connectionString)
                {
                    Database = ""
                };
                string connectionWithoutDatabase = builder.ToString();

                using (var con = new MySqlConnection(connectionWithoutDatabase))
                {
                    con.Open();
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = con;

                        command.CommandText = "CREATE DATABASE IF NOT EXISTS listeners";
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }

                builder.Database = "listeners";
                string connectionWithDatabase = builder.ToString(); 

                using (var con = new MySqlConnection(connectionWithDatabase))
                using (var command = new MySqlCommand())
                using (var sqlBackup = new MySqlBackup(command))
                {
                    con.Open();
                    command.Connection = con;
                    sqlBackup.ImportFromFile(path);
                    con.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
