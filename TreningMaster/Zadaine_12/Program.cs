using System;
using System.Data.Common;
using System.Drawing;
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

        Microsoft.Office.Interop.Excel.Range chartRange2;
        chartRange2 = worksheet.get_Range("j1", "j10");
        for (int i = 1; i <= 10; i++)
        {
            worksheet.Cells[1, i].Interior.Color = System.Drawing.Color.Pink;
            worksheet.Cells[i, 1].Interior.Color = System.Drawing.Color.Pink;
            worksheet.Cells[10, i].Interior.Color = System.Drawing.Color.Pink;
            worksheet.Cells[i, 10].Interior.Color = System.Drawing.Color.Pink;

            string Letter = ((char)('A' + i - 1)).ToString(); //Ustawienie "A" jako pierwszej kolumny i zmiana tego na string - char
            worksheet.Cells[11, i].Formula = $"=SUM({Letter}1:{Letter}10)";
            worksheet.Cells[11, i].Interior.Color = System.Drawing.Color.SandyBrown;
            worksheet.Cells[11, i].Font.Color = System.Drawing.Color.MediumPurple;
            worksheet.Cells[11, i].Font.Italic = true;
            worksheet.Cells[11, i].Font.Bold = true;
        }

        Microsoft.Office.Interop.Excel.Range chartRange3;
        chartRange3 = worksheet.get_Range("a10", "j10");
        chartRange3.Font.Color = System.Drawing.Color.Red;

        Microsoft.Office.Interop.Excel.Range chartRange4;
        chartRange4 = worksheet.get_Range("a1", "j10");
        foreach (Microsoft.Office.Interop.Excel.Range cell in chartRange4.Cells)
        {
            cell.BorderAround2();
        }

        Microsoft.Office.Interop.Excel.Range chartRange;
        chartRange = worksheet.get_Range("a1", "j10");
        chartRange.BorderAround2(Weight: XlBorderWeight.xlThick);

        

        // Save the workbook to a file
        workbook.SaveAs("Zadanie_12");
        // Close the workbook and Excel application
        workbook.Close();

        excel.Quit();
    }
}
