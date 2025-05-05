
using System;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace TreningMaster
{
    internal class Program
    {
        public class Exercise
        {
            public string Name { get; set; }
            public MuscleParts MusclePart { get; set; }
        }
        public enum MuscleParts
        {
            back = 1,
            leg = 2,
            chest = 3,
            biceps = 4,
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Dostępne partie mięśniowe:");
            //foreach (MuscleParts part in Enum.GetValues(typeof(MuscleParts)))
            //{
            //    Console.WriteLine($"{(int)part} - {part}");
            //}

            List<Exercise> exercises = new List<Exercise>();
            //{
            //    new Exercise()
            //    {
            //        Name = "Monster Walk",
            //        MusclePart = MuscleParts.back,
            //    },
            //     new Exercise()
            //    {
            //        Name = "Glute Bridge",
            //        MusclePart = MuscleParts.back,
            //    },
            //};

            string line;
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Izabella\Documents\Visual Studio 2022\Zadanie.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(';');

                    string name = parts[0];
                    MuscleParts musclePart = Enum.Parse<MuscleParts>(parts[1]);

                    exercises.Add(new Exercise { Name = name, MusclePart = musclePart });

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Koniec czytania pliku\n");
            }




            //Console.WriteLine("Dodaj nowe ćwiczenia:");

            //while (true)
            //{
            //    // {nazwa};{number_partii}
            //    string input = Console.ReadLine();
            //    if (input == "exit")
            //    {
            //        break;
            //    }
            //    string[] parts = input.Split(';');

            //    string name = parts[0];
            //    MuscleParts musclePart = Enum.Parse<MuscleParts>(parts[1]);

            //    exercises.Add(new Exercise { Name = name, MusclePart = musclePart });
            //}

            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(@"C:\Users\Izabella\Documents\Visual Studio 2022\Zadanie_output.txt", true, Encoding.ASCII);
                foreach (MuscleParts part in Enum.GetValues(typeof(MuscleParts)))
                {
                    sw.WriteLine(part);
                    foreach (var exercise in exercises)
                    {
                        if (exercise.MusclePart == part)
                        {
                            sw.WriteLine("\t" + exercise.Name);
                        }
                    }
                }

                //close the file
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



            Console.WriteLine("Lista ćwiczeń:");
            foreach (var exercise in exercises)
            {
                Console.WriteLine("\t" + exercise.Name + "\t" + exercise.MusclePart);
            }
            Console.WriteLine();

            Console.WriteLine("Ćwiczenia:");
            foreach (MuscleParts part in Enum.GetValues(typeof(MuscleParts)))
            {
                Console.WriteLine(part);
                foreach (var exercise in exercises)
                {
                    if (exercise.MusclePart == part)
                    {
                        Console.WriteLine("\t" + exercise.Name);
                    }
                }
            }
            //Console.WriteLine("Sortowanie od a do z:");
            //exercises.Sort((x, y) => x.Name.CompareTo(y.Name));//pod foreach nie dziłało, czemu tak?
            //foreach (var exercise in exercises)
            //{
            //    Console.WriteLine("\t" + exercise.Name);
            //}

            //Console.WriteLine("A teraz od z do a:");
            //exercises.Sort((x, y) => y.Name.CompareTo(x.Name));
            //foreach (var exercise in exercises)
            //{
            //    Console.WriteLine("\t" + exercise);
            //}

            //Console.WriteLine("A teraz od najkrótszego ciągu:");
            //exercises.Sort((x, y) => x.Name.Length.CompareTo(y.Name.Length)); //tu potrzebuje pomocy 
            //foreach (var exercise in exercises)
            //{
            //    Console.WriteLine("\t" + exercise);
            //}


            //Console.WriteLine("A teraz od A do Z tylko po ostatniej literze w nazwie:");
            //exercises.Sort((x, y) => x.Name[x.Name.Length - 1].CompareTo(y.Name[y.Name.Length - 1])); //tu potrzebuje pomocy 
            //foreach (var exercise in exercises)
            //{
            //    Console.WriteLine("\t" + exercise);
            //}

        }


    }
}