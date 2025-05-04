
using System;
using System.Collections.Immutable;
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
            buttocks = 2,
            thighs = 3,
            calves = 4,
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Dostępne partie mięśniowe:");
            foreach (MuscleParts part in Enum.GetValues(typeof(MuscleParts)))
            {
                Console.WriteLine($"{(int)part} - {part}");
            }

            //["Monster Walk", "Glute Bridge", "Arch hold"];

            // Monster Walk;3

            List<Exercise> exercises = new List<Exercise>()
            {
                new Exercise()
                {
                    Name = "Monster Walk",
                    MusclePart = MuscleParts.back,
                },
                 new Exercise()
                {
                    Name = "Glute Bridge",
                    MusclePart = MuscleParts.back,
                },
            };

            ///////////////////////////////
            Console.WriteLine("Dodaj nowe ćwiczenia:");

            while (true)
            {
                // {nazwa};{number_partii}
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                string[] parts = input.Split(';');

                string name = parts[0];
                MuscleParts musclePart = Enum.Parse<MuscleParts>(parts[1]);

                exercises.Add(new Exercise { Name = name, MusclePart = musclePart });
            }

            ///////////////////////////////

            Console.WriteLine("Lista ćwiczeń na pośladki:");
            foreach (var exercise in exercises)
            {
                Console.WriteLine("\t" + exercise.Name + "\t" + exercise.MusclePart);
            }

            Console.WriteLine("Ćwiczenia");
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
            Console.WriteLine("Sortowanie od a do z:");
            exercises.Sort((x, y) => x.Name.CompareTo(y.Name));//pod foreach nie dziłało, czemu tak?
            foreach (var exercise in exercises)
            {
                Console.WriteLine("\t" + exercise.Name);
            }

            Console.WriteLine("A teraz od z do a:");
            exercises.Sort((x, y) => y.Name.CompareTo(x.Name));
            foreach (var exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }

            Console.WriteLine("A teraz od najkrótszego ciągu:");
            exercises.Sort((x, y) => x.Name.Length.CompareTo(y.Name.Length)); //tu potrzebuje pomocy 
            foreach (var exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }


            Console.WriteLine("A teraz od A do Z tylko po ostatniej literze w nazwie:");
            exercises.Sort((x, y) => x.Name[x.Name.Length - 1].CompareTo(y.Name[y.Name.Length - 1])); //tu potrzebuje pomocy 
            foreach (var exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }

        }


    }
}