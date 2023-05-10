using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;


namespace App.Logs
{
    public static class XmlToExcel
    {
        static private string _filePath = "C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\XMLData\\Log.xml";
        static private XDocument _doc = XDocument.Load(_filePath);

        public static void CreateTable()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            xlWorksheet.Cells[1, 1] = "Method";
            xlWorksheet.Cells[1, 2] = "Owner";
            xlWorksheet.Cells[1, 3] = "SpectacleName";
            xlWorksheet.Cells[1, 4] = "SpectacleDate";
            xlWorksheet.Cells[1, 5] = "Category";
            xlWorksheet.Cells[1, 6] = "Price";
            xlWorksheet.Cells[1, 7] = "Timestamp";

            int row = 2;
            foreach (XElement operation in _doc.Descendants("Operation"))
            {
                string method = operation.Element("Method").Value;
                string owner = operation.Element("Owner").Value;
                string spectacleName = operation.Element("SpectacleName").Value;
                string spectacleDate = operation.Element("SpectacleDate").Value;
                string category = operation.Element("Category").Value;
                string price = operation.Element("Price").Value;
                string timestamp = operation.Element("Timestamp").Value;

                xlWorksheet.Cells[row, 1] = method;
                xlWorksheet.Cells[row, 2] = owner;
                xlWorksheet.Cells[row, 3] = spectacleName;
                xlWorksheet.Cells[row, 4] = spectacleDate;
                xlWorksheet.Cells[row, 5] = category;
                xlWorksheet.Cells[row, 6] = price;
                xlWorksheet.Cells[row, 7] = timestamp;

                if (method == "Покупка билета")
                {
                    xlRange = xlWorksheet.Range[xlWorksheet.Cells[row, 1], xlWorksheet.Cells[row, 7]];
                    xlRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                }
                else if (method == "Возврат билета")
                {
                    xlRange = xlWorksheet.Range[xlWorksheet.Cells[row, 1], xlWorksheet.Cells[row, 7]];
                    xlRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                }

                row++;
            }
            string resultLog = $"C:\\Users\\Evgeni\\Desktop\\CourseWork\\App\\Logs\\Log.xlsx";
            xlWorkbook.SaveAs(new FileInfo(resultLog));

            xlWorkbook.Close();
            xlApp.Quit();

            Process.Start(resultLog);
        }
    }
}
