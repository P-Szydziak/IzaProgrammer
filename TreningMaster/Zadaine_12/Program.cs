using System;
using System.Data.Common;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Zadaine_12;

public class Program
{
    static void Main(string[] args)
    {
        Application excel = new Application();
        // Create a new workbook
        Workbook workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        // Get the first worksheet in the workbook
        Worksheet worksheet = (Worksheet)workbook.Worksheets[1];
        worksheet.Name = "multiplication table";
        // Set the value of a cell
        for (int row = 1; row <= 10; row++)
        {
            for (int column = 1; column <= 10; column++)
            {
                worksheet.Cells[row, column] = row * column;
                if (row * column % 2 == 0)
                {
                    worksheet.Cells[row, column].Font.Color = System.Drawing.Color.Green;
                }

            }
        }
        Microsoft.Office.Interop.Excel.Range chartRange;
        chartRange = worksheet.get_Range("a1", "j10");
        foreach (Microsoft.Office.Interop.Excel.Range cell in chartRange.Cells)
        {
            chartRange.BorderAround2();
        }

        // Save the workbook to a file
        workbook.SaveAs("Zadanie_12");
        // Close the workbook and Excel application
        workbook.Close();

        excel.Quit();
    }
}
