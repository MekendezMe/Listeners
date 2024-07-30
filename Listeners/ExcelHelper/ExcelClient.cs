using Listeners.DatabaseHelper;
using Listeners.Forms.Roles.Manager;
using Listeners.Interfaces;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Listeners.ExcelHelper
{
    public class ExcelClient
    {
        private MySqlClient sqlClient;

        public ExcelClient()
        {
            sqlClient = new MySqlClient();
        }

        public bool CreateStatReport()
        {
            string countWithOrganization = sqlClient.GetValue("SELECT COUNT(*) FROM record where" +
                " record.organization IS NOT NULL and creditedStatus=(SELECT id from creditedStatus where " +
                "name='закончил') AND openStatus=(SELECT id from openStatus where name='закрыт')");

            string countWithoutOrganization = sqlClient.GetValue("SELECT COUNT(*) FROM record where " +
                "record.organization IS NULL and creditedStatus=(SELECT id from creditedStatus where " +
                "name='закончил') AND openStatus=(SELECT id from openStatus where name='закрыт')");

            string countMoreThanHours = sqlClient.GetValue("SELECT COUNT(*) FROM RECORD WHERE " +
                "(SELECT course.duration from course where id=record.id) > 72" +
                " and creditedStatus=(SELECT id from creditedStatus where " +
                "name='закончил') AND openStatus=(SELECT id from openStatus where name='закрыт')");

            string countLessThanHours = sqlClient.GetValue("SELECT COUNT(*) FROM RECORD WHERE " +
                "(SELECT course.duration from course where id=record.id) < 73" +
                " and creditedStatus=(SELECT id from creditedStatus where " +
                "name='закончил') AND openStatus=(SELECT id from openStatus where name='закрыт')");

            System.Data.DataTable ageListeners = sqlClient.GetDataTable("SELECT listener.id, listener.birthday," +
                " TIMESTAMPDIFF(YEAR, listener.birthday, NOW()) AS 'Age' from listener" +
                " where listener.id in(SELECT record.listener from record);");

            int firstAge = 0;
            int secondAge = 0;
            int thirdAge = 0;
            int fourthAge = 0;

            for (int i = 0; i < ageListeners.Rows.Count; i++)
            {
                int currentAge = 0;

                if (!int.TryParse(ageListeners.Rows[i]["Age"].ToString(), out currentAge)) return false;

                if (currentAge > 13 && currentAge < 19)
                {
                    firstAge++;
                }
                else if (currentAge > 18 && currentAge < 25)
                {
                    secondAge++;
                }
                else if (currentAge > 24 && currentAge < 50)
                {
                    thirdAge++;
                }
                else
                {
                    fourthAge++;
                }
            }

            DateTime today = DateTime.Today;
            DateTime firstDayOfNextMonth = today.AddDays(1 - today.Day).AddMonths(1);
            DateTime firstDayOfThisMonth = today.AddDays(1 - today.Day);


            DateTime resultDate = today.Day == 1 ? firstDayOfThisMonth : firstDayOfNextMonth;
            string date = resultDate.ToString();

            try
            {
                Excel.Application excelApp = new Excel.Application();
                var workBook = excelApp.Workbooks.Add(Type.Missing);

                var report = workBook.ActiveSheet;
                report.Name = "Статистический отчет";
                var mechanicCells = report.Cells;

                Excel.Range range = report.Range["A1:I3"];
                range.Merge();
                report.Cells[1, 1] = "Отчет обучившихся на " + date.Replace(" 0:00:00", "");
                report.Cells[1, 1].Font.Bold = true;
                report.Cells[1, 1].Font.Name = "Times New Roman";
                report.Cells[1, 1].Font.Size = 23;
                report.Cells[1, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A4:I4"];
                range.Merge();
                report.Cells[4, 1] = "Кем направлен";
                report.Cells[4, 1].Font.Bold = true;
                report.Cells[4, 1].Font.Name = "Times New Roman";
                report.Cells[4, 1].Font.Size = 22;
                report.Cells[4, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A5:F5"];
                range.Merge();
                report.Cells[5, 1] = "От предприятия";
                report.Cells[5, 1].Font.Bold = false;
                report.Cells[5, 1].Font.Name = "Times New Roman";
                report.Cells[5, 1].Font.Size = 15;

                range = report.Range["G5:I5"];
                range.Merge();
                report.Cells[5, 7] = countWithOrganization + " чел.";
                report.Cells[5, 7].Font.Bold = false;
                report.Cells[5, 7].Font.Name = "Times New Roman";
                report.Cells[5, 7].Font.Size = 15;
                report.Cells[5, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A6:F6"];
                range.Merge();
                report.Cells[6, 1] = "Сами";
                report.Cells[6, 1].Font.Bold = false;
                report.Cells[6, 1].Font.Name = "Times New Roman";
                report.Cells[6, 1].Font.Size = 15;

                range = report.Range["G6:I6"];
                range.Merge();
                report.Cells[6, 7] = countWithoutOrganization + " чел.";
                report.Cells[6, 7].Font.Bold = false;
                report.Cells[6, 7].Font.Name = "Times New Roman";
                report.Cells[6, 7].Font.Size = 15;
                report.Cells[6, 7].HorizontalAlignment = Excel.Constants.xlCenter;


                range = report.Range["A7:I7"];
                range.Merge();
                report.Cells[7, 1] = "Количество часов";
                report.Cells[7, 1].Font.Bold = true;
                report.Cells[7, 1].Font.Name = "Times New Roman";
                report.Cells[7, 1].Font.Size = 22;
                report.Cells[7, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A8:F8"];
                range.Merge();
                report.Cells[8, 1] = "От 0 до 72 часов";
                report.Cells[8, 1].Font.Bold = false;
                report.Cells[8, 1].Font.Name = "Times New Roman";
                report.Cells[8, 1].Font.Size = 15;

                range = report.Range["G8:I8"];
                range.Merge();
                report.Cells[8, 7] = countLessThanHours + " чел.";
                report.Cells[8, 7].Font.Bold = false;
                report.Cells[8, 7].Font.Name = "Times New Roman";
                report.Cells[8, 7].Font.Size = 15;
                report.Cells[8, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A9:F9"];
                range.Merge();
                report.Cells[9, 1] = "Свыше 72 часов";
                report.Cells[9, 1].Font.Bold = false;
                report.Cells[9, 1].Font.Name = "Times New Roman";
                report.Cells[9, 1].Font.Size = 15;

                range = report.Range["G9:I9"];
                range.Merge();
                report.Cells[9, 7] = countMoreThanHours + " чел.";
                report.Cells[9, 7].Font.Bold = false;
                report.Cells[9, 7].Font.Name = "Times New Roman";
                report.Cells[9, 7].Font.Size = 15;
                report.Cells[9, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A10:I10"];
                range.Merge();
                report.Cells[10, 1] = "Возраст";
                report.Cells[10, 1].Font.Bold = true;
                report.Cells[10, 1].Font.Name = "Times New Roman";
                report.Cells[10, 1].Font.Size = 22;
                report.Cells[10, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A11:F11"];
                range.Merge();
                report.Cells[11, 1] = "От 14 до 18 лет";
                report.Cells[11, 1].Font.Bold = false;
                report.Cells[11, 1].Font.Name = "Times New Roman";
                report.Cells[11, 1].Font.Size = 15;

                range = report.Range["G11:I11"];
                range.Merge();
                report.Cells[11, 7] = firstAge + " чел.";
                report.Cells[11, 7].Font.Bold = false;
                report.Cells[11, 7].Font.Name = "Times New Roman";
                report.Cells[11, 7].Font.Size = 15;
                report.Cells[11, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A12:F12"];
                range.Merge();
                report.Cells[12, 1] = "От 19 до 24 лет";
                report.Cells[12, 1].Font.Bold = false;
                report.Cells[12, 1].Font.Name = "Times New Roman";
                report.Cells[12, 1].Font.Size = 15;

                range = report.Range["G12:I12"];
                range.Merge();
                report.Cells[12, 7] = secondAge + " чел.";
                report.Cells[12, 7].Font.Bold = false;
                report.Cells[12, 7].Font.Name = "Times New Roman";
                report.Cells[12, 7].Font.Size = 15;
                report.Cells[12, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A13:F13"];
                range.Merge();
                report.Cells[13, 1] = "От 25 до 49 лет";
                report.Cells[13, 1].Font.Bold = false;
                report.Cells[13, 1].Font.Name = "Times New Roman";
                report.Cells[13, 1].Font.Size = 15;

                range = report.Range["G13:I13"];
                range.Merge();
                report.Cells[13, 7] = thirdAge + " чел.";
                report.Cells[13, 7].Font.Bold = false;
                report.Cells[13, 7].Font.Name = "Times New Roman";
                report.Cells[13, 7].Font.Size = 15;
                report.Cells[13, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                range = report.Range["A14:F14"];
                range.Merge();
                report.Cells[14, 1] = "Свыше 50 лет";
                report.Cells[14, 1].Font.Bold = false;
                report.Cells[14, 1].Font.Name = "Times New Roman";
                report.Cells[14, 1].Font.Size = 15;

                range = report.Range["G14:I14"];
                range.Merge();
                report.Cells[14, 7] = fourthAge + " чел.";
                report.Cells[14, 7].Font.Bold = false;
                report.Cells[14, 7].Font.Name = "Times New Roman";
                report.Cells[14, 7].Font.Size = 15;
                report.Cells[14, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Columns.AutoFit();
                report.Rows.AutoFit();

                ControlExistDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "statistics"));

                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "statistics", "statistics-" +
                    DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "-") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".xlsx");
                workBook.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                workBook.Close();
                excelApp.Quit();
                Marshal.ReleaseComObject(workBook);
                Marshal.ReleaseComObject(excelApp);
                Process.Start(pathDocument);
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreatePaymentReport()
        {
            Excel.Application excelApp = null;
            Workbook workBook = null;
            try
            {
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Add(Type.Missing);

                var report = workBook.ActiveSheet;
                report.Name = "Отчет по оплатам";
                var mechanicCells = report.Cells;

                Excel.Range range = report.Range["A1:G1"];
                range.Merge();
                report.Cells[1, 1] = "Сведения о платных образовательных услугах на " + DateTime.Now.ToString("dd.MM.yyyy");
                report.Cells[1, 1].Font.Bold = true;
                report.Cells[1, 1].Font.Name = "Times New Roman";
                report.Cells[1, 1].Font.Size = 23;
                report.Cells[1, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[3, 1] = "№";
                report.Cells[3, 1].Font.Bold = true;
                report.Cells[3, 1].Font.Name = "Times New Roman";
                report.Cells[3, 1].Font.Size = 16;
                report.Cells[3, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[3, 2] = "Ф.И.О. слушателя курсов";
                report.Cells[3, 2].Font.Bold = true;
                report.Cells[3, 2].Font.Name = "Times New Roman";
                report.Cells[3, 2].Font.Size = 16;
                report.Cells[3, 2].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[3, 3] = "Заказчик";
                report.Cells[3, 3].Font.Bold = true;
                report.Cells[3, 3].Font.Name = "Times New Roman";
                report.Cells[3, 3].Font.Size = 16;
                report.Cells[3, 3].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[3, 4] = "№ договора";
                report.Cells[3, 4].Font.Bold = true;
                report.Cells[3, 4].Font.Name = "Times New Roman";
                report.Cells[3, 4].Font.Size = 16;
                report.Cells[3, 4].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[3, 5] = "Стоимость обучения";
                report.Cells[3, 5].Font.Bold = true;
                report.Cells[3, 5].Font.Name = "Times New Roman";
                report.Cells[3, 5].Font.Size = 16;
                report.Cells[3, 5].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[3, 6] = "Внесенная оплата на " + DateTime.Now.ToString("dd.MM.yyyy");
                report.Cells[3, 6].Font.Bold = true;
                report.Cells[3, 6].Font.Name = "Times New Roman";
                report.Cells[3, 6].Font.Size = 16;
                report.Cells[3, 6].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[3, 7] = "Примечание";
                report.Cells[3, 7].Font.Bold = true;
                report.Cells[3, 7].Font.Name = "Times New Roman";
                report.Cells[3, 7].Font.Size = 16;
                report.Cells[3, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                System.Data.DataTable courses = sqlClient.GetDataTable("SELECT id AS 'Номер', name AS 'Name', duration, price AS 'Price', (SELECT name from qualification where id=course.qualification) AS 'Qualification'" +
                    " from course");

                int a = 4;

                for (int i = 0; i < courses.Rows.Count; i++)
                {
                    range = report.Range["A" + a + ":G" + a + ""];
                    range.Merge();
                    report.Cells[a, 1] = courses.Rows[i]["Qualification"].ToString() + " - " + courses.Rows[i]["Name"].ToString();
                    report.Cells[a, 1].Font.Bold = true;
                    report.Cells[a, 1].Font.Name = "Times New Roman";
                    report.Cells[a, 1].Font.Size = 17;
                    report.Cells[a, 1].HorizontalAlignment = Excel.Constants.xlCenter;
                    a++;
                    System.Data.DataTable listeners = sqlClient.GetDataTable("SELECT CONCAT_WS(' ', listener.surname, listener.name," +
                        " listener.patronymic) AS 'Listener', (SELECT name from organization where id=record.organization) AS 'Organization'," +
                        "record.code AS 'Code', record.decorationDate AS 'Date', record.actualPayment AS 'Pay'" +
                        " from record INNER JOIN listener on record.listener = listener.id where record.course='" +
                        courses.Rows[i]["Номер"].ToString() + "'");

                    if (listeners.Rows.Count == 0) continue;

                    int index = 1;

                    for (int z = 0; z < listeners.Rows.Count; z++)
                    {
                        report.Cells[a, 1] = index.ToString();
                        report.Cells[a, 1].Font.Name = "Times New Roman";
                        report.Cells[a, 1].Font.Size = 12;

                        index++;

                        report.Cells[a, 2] = listeners.Rows[z]["Listener"].ToString();
                        report.Cells[a, 2].Font.Name = "Times New Roman";
                        report.Cells[a, 2].Font.Size = 12;

                        report.Cells[a, 3] = (listeners.Rows[z]["Organization"] != null &&
                            listeners.Rows[z]["Organization"].ToString() != string.Empty)
                            ? listeners.Rows[z]["Organization"].ToString()
                            : listeners.Rows[z]["Listener"].ToString();

                        report.Cells[a, 3].Font.Name = "Times New Roman";
                        report.Cells[a, 3].Font.Size = 12;

                        report.Cells[a, 4] = listeners.Rows[z]["Code"].ToString() + " от " + listeners.Rows[z]["Date"].ToString()
                            .Replace(" 0:00:00", "");
                        report.Cells[a, 4].Font.Name = "Times New Roman";
                        report.Cells[a, 4].Font.Size = 12;

                        report.Cells[a, 5] = double.Parse(courses.Rows[i]["Price"].ToString().Replace(".", ","));
                        report.Cells[a, 5].Font.Name = "Times New Roman";
                        report.Cells[a, 5].Font.Size = 12;

                        report.Cells[a, 6] = double.Parse(listeners.Rows[z]["Pay"].ToString().Replace(".", ","));
                        report.Cells[a, 6].Font.Name = "Times New Roman";
                        report.Cells[a, 6].Font.Size = 12;

                        a++;
                    }
                }

                report.Columns.AutoFit();
                report.Rows.AutoFit();
                ControlExistDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "payments"));

                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "payments", "payment-" +
                    DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "-") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".xlsx");
                workBook.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                workBook.Close();
                excelApp.Quit();
                Marshal.ReleaseComObject(workBook);
                Marshal.ReleaseComObject(excelApp);
                Process.Start(pathDocument);

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при выводе отчета об оплате", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }


        public bool CreatePatternDpo(string group)
        {
            try
            {
                string sourceFilePath = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "ReportLayout", "Shablon_DPO.xlsx");

                ControlExistDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "Patterns_DPO"));

                string destinationFilePath = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "Patterns_DPO", "Pattern-DPO-" +
                    DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "-") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".xlsx");

                File.Copy(sourceFilePath, destinationFilePath);

                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    sourceStream.CopyTo(destinationStream);
                    destinationStream.Flush();
                }

                Excel.Application excelApp = new Excel.Application();

                Excel.Workbook workBook = excelApp.Workbooks.Open(destinationFilePath);

                Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Sheets[1];

                List<IFirstPattern> records = sqlClient.GetInformationForPatternReport(group);

                for (int row = 0; row < records.Count; row++)
                {
                    string program = string.Empty;

                    if (records[row].Qualification == "повышение квалификации")
                    {
                        program = "Повышение квалификации";
                    }
                    else if (records[row].Qualification == "переподготовка")
                    {
                        program = "Профессиональная переподготовка";
                    }

                    workSheet.Cells[row + 2, 1] = records[row].Type;
                    workSheet.Cells[row + 2, 2] = records[row].Status;
                    workSheet.Cells[row + 2, 6] = records[row].Series;
                    workSheet.Cells[row + 2, 7] = records[row].Number;
                    workSheet.Cells[row + 2, 8] = records[row].IssueDate.Replace(" 0:00:00", "");
                    workSheet.Cells[row + 2, 10] = program;
                    workSheet.Cells[row + 2, 11] = records[row].Course;
                    workSheet.Cells[row + 2, 14] = records[row].Course;
                    workSheet.Cells[row + 2, 19] = DateTime.Parse(records[row].StartCourse).Year;
                    workSheet.Cells[row + 2, 20] = DateTime.Parse(records[row].EndCourse).Year;
                    workSheet.Cells[row + 2, 21] = records[row].Duration;
                    workSheet.Cells[row + 2, 22] = records[row].Surname;
                    workSheet.Cells[row + 2, 23] = records[row].Name;
                    workSheet.Cells[row + 2, 24] = records[row].Patronymic;
                    workSheet.Cells[row + 2, 25] = records[row].Birthday.Replace(" 0:00:00", "");
                    workSheet.Cells[row + 2, 26] = records[row].Gender == "Мужской" ? "Муж" : "Жен";
                    workSheet.Cells[row + 2, 27] = records[row].InsuranceNumber;
                    workSheet.Cells[row + 2, 28] = "Очно-заочная (вечерняя)";
                    workSheet.Cells[row + 2, 29] = "Платное обучение";
                    workSheet.Cells[row + 2, 30] = "в образовательной организации";
                    workSheet.Cells[row + 2, 31] = "643";
                }
                
                workSheet.Columns.AutoFit();
                workSheet.Rows.AutoFit();
                MessageBox.Show("Документ сохранен в: " + destinationFilePath, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                workBook.Close(true);
                excelApp.Quit();
                Marshal.ReleaseComObject(workBook);
                Marshal.ReleaseComObject(excelApp);
                Process.Start(destinationFilePath);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CreateReportAboutRecords()
        {
            try
            {

                Excel.Application excelApp = new Excel.Application();
                var workBook = excelApp.Workbooks.Add(Type.Missing);

                List<IRecordReceipt> records = sqlClient.GetInformationAboutRecords();

                var report = workBook.ActiveSheet;
                report.Name = "Отчет по договорам";
                var mechanicCells = report.Cells;

                Excel.Range range = report.Range["A1:P1"];
                range.Merge();
                report.Cells[1, 1] = "Отчет по договорам";
                report.Cells[1, 1].Font.Bold = true;
                report.Cells[1, 1].Font.Name = "Times New Roman";
                report.Cells[1, 1].Font.Size = 24;
                report.Cells[1, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 1] = "Код договора";
                report.Cells[2, 1].Font.Bold = true;
                report.Cells[2, 1].Font.Name = "Times New Roman";
                report.Cells[2, 1].Font.Size = 13;
                report.Cells[2, 1].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 2] = "Дата оформления";
                report.Cells[2, 2].Font.Bold = true;
                report.Cells[2, 2].Font.Name = "Times New Roman";
                report.Cells[2, 2].Font.Size = 13;
                report.Cells[2, 2].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 3] = "Слушатель";
                report.Cells[2, 3].Font.Bold = true;
                report.Cells[2, 3].Font.Name = "Times New Roman";
                report.Cells[2, 3].Font.Size = 13;
                report.Cells[2, 3].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 4] = "Заказчик";
                report.Cells[2, 4].Font.Bold = true;
                report.Cells[2, 4].Font.Name = "Times New Roman";
                report.Cells[2, 4].Font.Size = 13;
                report.Cells[2, 4].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 5] = "Курс";
                report.Cells[2, 5].Font.Bold = true;
                report.Cells[2, 5].Font.Name = "Times New Roman";
                report.Cells[2, 5].Font.Size = 13;
                report.Cells[2, 5].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 6] = "Квалификация курса";
                report.Cells[2, 6].Font.Bold = true;
                report.Cells[2, 6].Font.Name = "Times New Roman";
                report.Cells[2, 6].Font.Size = 13;
                report.Cells[2, 6].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 7] = "Группа";
                report.Cells[2, 7].Font.Bold = true;
                report.Cells[2, 7].Font.Name = "Times New Roman";
                report.Cells[2, 7].Font.Size = 13;
                report.Cells[2, 7].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 8] = "Начало обучения";
                report.Cells[2, 8].Font.Bold = true;
                report.Cells[2, 8].Font.Name = "Times New Roman";
                report.Cells[2, 8].Font.Size = 13;
                report.Cells[2, 8].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 9] = "Окончание обучения";
                report.Cells[2, 9].Font.Bold = true;
                report.Cells[2, 9].Font.Name = "Times New Roman";
                report.Cells[2, 9].Font.Size = 13;
                report.Cells[2, 9].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 10] = "Фактическая оплата";
                report.Cells[2, 10].Font.Bold = true;
                report.Cells[2, 10].Font.Name = "Times New Roman";
                report.Cells[2, 10].Font.Size = 13;
                report.Cells[2, 10].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 11] = "Полная оплата";
                report.Cells[2, 11].Font.Bold = true;
                report.Cells[2, 11].Font.Name = "Times New Roman";
                report.Cells[2, 11].Font.Size = 13;
                report.Cells[2, 11].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 12] = "Статус освоения";
                report.Cells[2, 12].Font.Bold = true;
                report.Cells[2, 12].Font.Name = "Times New Roman";
                report.Cells[2, 12].Font.Size = 13;
                report.Cells[2, 12].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 13] = "Статус обучения";
                report.Cells[2, 13].Font.Bold = true;
                report.Cells[2, 13].Font.Name = "Times New Roman";
                report.Cells[2, 13].Font.Size = 13;
                report.Cells[2, 13].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 14] = "Статус оплаты";
                report.Cells[2, 14].Font.Bold = true;
                report.Cells[2, 14].Font.Name = "Times New Roman";
                report.Cells[2, 14].Font.Size = 13;
                report.Cells[2, 14].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 15] = "Статус договора";
                report.Cells[2, 15].Font.Bold = true;
                report.Cells[2, 15].Font.Name = "Times New Roman";
                report.Cells[2, 15].Font.Size = 13;
                report.Cells[2, 15].HorizontalAlignment = Excel.Constants.xlCenter;

                report.Cells[2, 16] = "Примечание";
                report.Cells[2, 16].Font.Bold = true;
                report.Cells[2, 16].Font.Name = "Times New Roman";
                report.Cells[2, 16].Font.Size = 13;
                report.Cells[2, 16].HorizontalAlignment = Excel.Constants.xlCenter;


                int a = 0;
                int i = 0;
                for (i = 3; i < records.Count + 3; i++)
                {
                    report.Cells[i, 1] = records[a].Code;
                    report.Cells[i, 1].Font.Name = "Times New Roman";
                    report.Cells[i, 1].Font.Size = 11;

                    report.Cells[i, 2] = records[a].DecorationDate.Replace(" 0:00:00", "");
                    report.Cells[i, 2].Font.Name = "Times New Roman";
                    report.Cells[i, 2].Font.Size = 11;

                    report.Cells[i, 3] = records[a].ListenerSurname + " " + records[a].ListenerName + " " + records[a].ListenerPatronymic;
                    report.Cells[i, 3].Font.Name = "Times New Roman";
                    report.Cells[i, 3].Font.Size = 11;

                    string customer = string.Empty;
                    if (!string.IsNullOrEmpty(records[a].Representative))
                    {
                        customer = sqlClient.GetValue("SELECT concat_ws(' ', surname, name, patronymic) from representative where id='" + records[a].Representative + "'");
                    }
                    else if (!string.IsNullOrEmpty(records[a].Organization))
                    {
                        customer = sqlClient.GetValue("SELECT name from organization where id='" + records[a].Organization + "'");
                    }
                    else
                    {
                        customer = records[a].ListenerSurname + " " + records[a].ListenerName + " " + records[a].ListenerPatronymic;
                    }

                    report.Cells[i, 4] = customer;
                    report.Cells[i, 4].Font.Name = "Times New Roman";
                    report.Cells[i, 4].Font.Size = 11;

                    report.Cells[i, 5] = records[a].Course;
                    report.Cells[i, 5].Font.Name = "Times New Roman";
                    report.Cells[i, 5].Font.Size = 11;

                    report.Cells[i, 6] = records[a].Qualification;
                    report.Cells[i, 6].Font.Name = "Times New Roman";
                    report.Cells[i, 6].Font.Size = 11;

                    report.Cells[i, 7] = records[a].Group;
                    report.Cells[i, 7].Font.Name = "Times New Roman";
                    report.Cells[i, 7].Font.Size = 11;

                    report.Cells[i, 8] = records[a].StartCourse.Replace(" 0:00:00", "");
                    report.Cells[i, 8].Font.Name = "Times New Roman";
                    report.Cells[i, 8].Font.Size = 11;

                    report.Cells[i, 9] = records[a].EndCourse.Replace(" 0:00:00", "");
                    report.Cells[i, 9].Font.Name = "Times New Roman";
                    report.Cells[i, 9].Font.Size = 11;

                    report.Cells[i, 10] = double.Parse(records[a].ActualPayment.ToString().Replace(".", ","));
                    report.Cells[i, 10].Font.Name = "Times New Roman";
                    report.Cells[i, 10].Font.Size = 11;

                    report.Cells[i, 11] = double.Parse(records[a].Price.ToString().Replace(".", ","));
                    report.Cells[i, 11].Font.Name = "Times New Roman";
                    report.Cells[i, 11].Font.Size = 11;

                    report.Cells[i, 12] = records[a].EndStatus;
                    report.Cells[i, 12].Font.Name = "Times New Roman";
                    report.Cells[i, 12].Font.Size = 11;

                    report.Cells[i, 13] = records[a].CreditedStatus;
                    report.Cells[i, 13].Font.Name = "Times New Roman";
                    report.Cells[i, 13].Font.Size = 11;

                    report.Cells[i, 14] = records[a].PaymentStatus;
                    report.Cells[i, 14].Font.Name = "Times New Roman";
                    report.Cells[i, 14].Font.Size = 11;

                    report.Cells[i, 15] = records[a].OpenStatus;
                    report.Cells[i, 15].Font.Name = "Times New Roman";
                    report.Cells[i, 15].Font.Size = 11;

                    report.Cells[i, 16] = "";
                    report.Cells[i, 16].Font.Name = "Times New Roman";
                    report.Cells[i, 16].Font.Size = 11;

                    a++;
                }

                range = report.Range["A1:P" + i];

                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                report.Columns.AutoFit();
                report.Rows.AutoFit();

                ControlExistDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "reports"));

                string pathDocument = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "reports", "allContracts-" +
                    DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "-") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".xlsx");
                workBook.SaveAs(pathDocument);
                MessageBox.Show("Документ сохранен в: " + pathDocument, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                workBook.Close();
                excelApp.Quit();
                Marshal.ReleaseComObject(workBook);
                Marshal.ReleaseComObject(excelApp);
                Process.Start(pathDocument);
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool CreatePatternPo(string group)
        {
            try
            {
                string sourceFilePath = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "ReportLayout", "Shablon_PO.xlsx");

                ControlExistDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "Patterns_PO"));

                string destinationFilePath = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "Patterns_PO", "Pattern-PO-" +
                    DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "-") + "-" +
                    DateTime.Now.Millisecond.ToString() + ".xlsx");

                File.Copy(sourceFilePath, destinationFilePath, true);

                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    sourceStream.CopyTo(destinationStream);
                    destinationStream.Flush(); 
                }

                Excel.Application excelApp = new Excel.Application();

                Excel.Workbook workBook = excelApp.Workbooks.Open(destinationFilePath);

                Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Sheets[1];

                List<IFirstPattern> records = sqlClient.GetInformationForPatternReport(group);

                for (int row = 0; row < records.Count; row++)
                {
                    string program = string.Empty;

                    if (records[row].Qualification == "подготовка")
                    {
                        program = "Программа профессиональной подготовки по профессии рабочего, должности служащего";
                    }
                    else if (records[row].Qualification == "переподготовка")
                    {
                        program = "Программа переподготовки рабочих, служащих";
                    }
                    else
                    {
                        program = "Программа повышения квалификации рабочих, служащих";
                    }

                    workSheet.Cells[row + 2, 1] = records[row].Type;
                    workSheet.Cells[row + 2, 2] = records[row].Status;
                    workSheet.Cells[row + 2, 6] = records[row].Series;
                    workSheet.Cells[row + 2, 7] = records[row].Number;
                    workSheet.Cells[row + 2, 8] = records[row].IssueDate.Replace(" 0:00:00", "");
                    workSheet.Cells[row + 2, 10] = program;
                    workSheet.Cells[row + 2, 11] = records[row].Course;
                    workSheet.Cells[row + 2, 12] = records[row].Course;
                    workSheet.Cells[row + 2, 14] = DateTime.Parse(records[row].StartCourse).Year;
                    workSheet.Cells[row + 2, 15] = DateTime.Parse(records[row].EndCourse).Year;
                    workSheet.Cells[row + 2, 16] = records[row].Duration;
                    workSheet.Cells[row + 2, 17] = records[row].Surname;
                    workSheet.Cells[row + 2, 18] = records[row].Name;
                    workSheet.Cells[row + 2, 19] = records[row].Patronymic;
                    workSheet.Cells[row + 2, 20] = records[row].Birthday.Replace(" 0:00:00", "");
                    workSheet.Cells[row + 2, 21] = (records[row].Gender == "Мужской" ? "Муж" : "Жен");
                    workSheet.Cells[row + 2, 22] = records[row].InsuranceNumber;
                    workSheet.Cells[row + 2, 23] = "643";
                    workSheet.Cells[row + 2, 24] = "Очно-заочная (вечерняя)";
                    workSheet.Cells[row + 2, 25] = "Платное обучение";
                    workSheet.Cells[row + 2, 26] = "в образовательной организации";
                }

                workSheet.Columns.AutoFit();
                workSheet.Rows.AutoFit();
                MessageBox.Show("Документ сохранен в: " + destinationFilePath, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                workBook.Close(true);
                excelApp.Quit();
                Marshal.ReleaseComObject(workBook);
                Marshal.ReleaseComObject(excelApp);
                Process.Start(destinationFilePath); 
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
