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
        for(int row = 1; row <= 10; row++)
        {
            for (int column = 1; column <= 10; column++)
            {
                worksheet.Cells[row, column] = row * column;
            }
        }

        // Save the workbook to a file
        workbook.SaveAs("Zadanie_12");
        // Close the workbook and Excel application
        workbook.Close();

        excel.Quit();
    }
}
