using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Core.Utilities.Helpers.FileHelper;

namespace Core.Utilities.Helpers.ExcelHelper
{
    public class ListToExcelHelpers
    {
        public static byte[] ExportToExcel<T>(List<T> listT)
        {
           using (var workbook = new XLWorkbook())
           {
                var worksheet = workbook.Worksheets.Add();
                int currentRow = 1;
                int counter = 1;

                var propertiesOfT = typeof(T).GetProperties();

                foreach (var prop in propertiesOfT)
                {
                    worksheet.Cell(currentRow, counter).Value = prop.Name.ToString();
                    counter++;
                }

                foreach (var item in listT)
                {
                    currentRow++;
                    counter = 1;
                    foreach (var prop in propertiesOfT)
                    {
                        worksheet.Cell(currentRow, counter).Value = typeof(T).GetProperty(prop.Name.ToString()).GetValue(item, null).ToString();
                        counter++;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return content;
                }
           }
        }
    }
}
