using System.Text;

namespace TreningMaster
{
    class Progrma
    {
        public enum MuscleParts
        {
            butt = 1,
            back = 2,
            belly = 3,
            arms = 4,
            forearms = 5,
            legs = 6,
        }

        public enum DifficultyLevel
        {
            beginner,
            intermediate,
            advanced
        }

        public class Exercise
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public MuscleParts MuscleParts { get; set; }
            public DifficultyLevel DifficultyLevel { get; set; }
            public int NumberOfSeries { get; set; }
            public int NumberOfRepetitionsInTheSeries { get; set; }
        }
        static void Main(string[] args)
        {
            List<Exercise> exercises = new List<Exercise>();

            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"C:\Users\Izabella\Documents\Visual Studio 2022\nowe_zadanie.txt");

                line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(';');
                    string Name = parts[0];
                    string Description = parts[1];
                    MuscleParts MuscleParts = Enum.Parse<MuscleParts>(parts[2]);
                    DifficultyLevel DifficultyLevel = Enum.Parse<DifficultyLevel>(parts[3]);
                    int NumberOfSeries = int.Parse(parts[4]);
                    int NumberOfRepetitionsInTheSeries = int.Parse(parts[5]);

                    exercises.Add(new Exercise { Name = Name, Description = Description, MuscleParts = MuscleParts, DifficultyLevel = DifficultyLevel, NumberOfSeries = NumberOfSeries, NumberOfRepetitionsInTheSeries = NumberOfRepetitionsInTheSeries });
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }


            try
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\Izabella\Documents\Visual Studio 2022\zadanie_10_output.txt", true, Encoding.UTF8);
                foreach (MuscleParts part in Enum.GetValues(typeof(MuscleParts)))
                {
                    sw.WriteLine(part);
                    foreach (var exercise in exercises)
                    {
                        if (exercise.MuscleParts == part)
                        {
                            sw.WriteLine($"{exercise.Name};{exercise.Description};{exercise.MuscleParts};{exercise.DifficultyLevel};{exercise.NumberOfSeries};{exercise.NumberOfRepetitionsInTheSeries}");
                        }

                    }
                }
                sw.Close();
                Console.WriteLine("Dane zostały zapisane do pliku");
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd podczas zapisu: " + e.Message);
            }
        }
    }
}

