using System.Drawing;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Zadaine_12;

public class Program
{
    static void Main(string[] args)
    {
        int size = GetTableSizeFromArgs(args, defaultSize: 10);
        if (args.Length > 0)
        {
            Console.WriteLine(args[0]);
        }
        var excel = new Application();
        // Create a new workbook
        var workbook = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        // Get the first worksheet in the workbook
        var worksheet = (Worksheet)workbook.Worksheets[1];
        worksheet.Name = "multiplication table";

        FillMultiplicationTable(worksheet, size);
        HighlightBordersAndHeaders(worksheet, size);
        AddSumFormulas(worksheet, size);
        FormatBorders(worksheet, size);

        // Save the workbook to a file
        workbook.SaveAs("Zadanie_12");
        // Close the workbook and Excel application
        workbook.Close();

        excel.Quit();
    }

    static int GetTableSizeFromArgs(string[] args, int defaultSize)
    {
        if (args.Length > 0 && int.TryParse(args[0], out int parsedSize) && parsedSize > 0)
        {
            return parsedSize;
        }

        return defaultSize;
    }

    static void FillMultiplicationTable(Worksheet worksheet, int size)
    { // Set the value of a cell
        for (int row = 1; row <= size; row++)
        {
            for (int column = 1; column <= size; column++)
            {
                worksheet.Cells[row, column] = row * column;/// tu może być błąd
                if (row * column % 2 == 0)
                {
                    worksheet.Cells[row, column].Font.Color = Color.Green;
                }

            }
        }
    }

    
    static void HighlightBordersAndHeaders(Worksheet worksheet, int size)
    { 
       
        for (int i = 1; i <= size; i++)
        {
            worksheet.Cells[1, i].Interior.Color = Color.Pink;
            worksheet.Cells[i, 1].Interior.Color = Color.Pink;
            worksheet.Cells[size, i].Interior.Color = Color.Pink;
            worksheet.Cells[i, size].Interior.Color = Color.Pink;
        }
        var bottomRowRange = worksheet.get_Range($"A{size}", $"{ToExcelColumn(size)}{size}");/// tu może być błąd
        bottomRowRange.Font.Color = ColorTranslator.ToOle(Color.Red);
    }

    static void AddSumFormulas(Worksheet worksheet, int size)
    {
        for (int i = 1; i <= size; i++)
        {
            string Letter = ((char)('A' + i - 1)).ToString(); //Ustawienie "A" jako pierwszej kolumny i zmiana tego na string - char
            worksheet.Cells[11, i].Formula = $"=SUM({Letter}1:{Letter}10)";
            worksheet.Cells[11, i].Interior.Color = Color.SandyBrown;
            worksheet.Cells[11, i].Font.Color = Color.MediumPurple;
            worksheet.Cells[11, i].Font.Italic = true;
            worksheet.Cells[11, i].Font.Bold = true;
        }
      
    }


    static void FormatBorders(Worksheet worksheet, int size)
    {
        var fullRange = worksheet.get_Range("A1", $"{ToExcelColumn(size)}{size}");
        foreach (Range cell in fullRange.Cells)
        {
            cell.BorderAround2();
        }

        fullRange.BorderAround2(Weight: XlBorderWeight.xlThick);
    }


    static string ToExcelColumn(int columnNumber)
    {
        string columnName = "";
        while (columnNumber > 0)
        {
            int remainder = (columnNumber - 1) % 26;
            columnName = (char)(remainder + 'A') + columnName;
            columnNumber = (columnNumber - 1) / 26;
        }
        return columnName;
    }

}
