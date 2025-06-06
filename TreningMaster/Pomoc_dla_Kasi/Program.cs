using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Text;

namespace TreningMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<DateTime> futureWeekendDates = new List<DateTime>();
            string line;


            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Izabella\Documents\Visual Studio 2022\Zadanie_11_daty.txt");
                StreamWriter sw = new StreamWriter(@"C:\Users\Izabella\Documents\Visual Studio 2022\Zadanie_11_Kasia.txt", false, Encoding.UTF8);

                line = sr.ReadLine();

                while (line != null)
                {
                    if (DateTime.TryParseExact(line.Trim(), "yyyy-MM-dd",
                                               CultureInfo.InvariantCulture,
                                               DateTimeStyles.None, out DateTime date))
                    {
                        if (date > DateTime.Now && (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday))
                        {
                            sw.WriteLine(date.ToString("yyyy-MM-dd"));
                        }
                    }

                    line = sr.ReadLine();
                }

                sr.Close();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            //try
            //{
            //    StreamWriter sw = new StreamWriter(@"C:\Users\Izabella\Documents\Visual Studio 2022\Zadanie_11_Kasia.txt", false, Encoding.UTF8);

            //    foreach (var date in futureWeekendDates)
            //    {
            //        sw.WriteLine(date);
            //    }
            //    sw.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: " + e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}
        }
    }
}


