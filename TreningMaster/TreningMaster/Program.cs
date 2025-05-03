
using System;
using System.Collections.Immutable;

namespace TreningMaster
{
    internal class Program
    {
        enum MuscleParts
        {
            back = 1,
            buttocks = 2,
            thighs = 3,
            calves = 4
        }

        static void Main(string[] args)
        {
            List<string> exercises = ["Monster Walk", "Glute Bridge", "Arch hold"];// dodaniała Listt przed i nie wiem czy nie powinnam teraz zmienć nawiasów kwadratowych()


            ///////////////////////////////
            Console.WriteLine("Dodaj nowe ćwiczenia:");
            
            while (true)
            {

                string userExercise = Console.ReadLine();
                if (userExercise == "exit")
                {
                    
                    break;
                }

                exercises.Add(userExercise);
            }

            ///////////////////////////////

            Console.WriteLine("Lista ćwiczeń na pośladki:");
            foreach (string exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }

            Console.WriteLine("Sortowanie od a do z:");
            exercises.Sort();//pod foreach nie dziłało, czemu tak?
            foreach (string exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }

            Console.WriteLine("A teraz od z do a:");
            exercises.Sort((x, y) => y.CompareTo(x));
            foreach (string exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }

            Console.WriteLine("A teraz od najkrótszego ciągu:");
            exercises.Sort((x, y) => x.Length.CompareTo(y.Length)); //tu potrzebuje pomocy 
            foreach (string exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }


            Console.WriteLine("A teraz od A do Z tylko po ostatniej literze w nazwie:");
            exercises.Sort((x, y) => x[x.Length - 1].CompareTo(y[y.Length - 1])); //tu potrzebuje pomocy 
            foreach (string exercise in exercises)
            {
                Console.WriteLine("\t" + exercise);
            }

        }
    

    }
}