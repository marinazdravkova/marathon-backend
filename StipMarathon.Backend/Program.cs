using System;
using StipMarathon.Backend;
using StipMarathon.Backend.Enums;

namespace StipMarathon.Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            MarathonManager newManager = new MarathonManager();

            bool running = true;

            Console.WriteLine("Dobredojdovte na Stip Marathon 2026");

            while(running)
            {
                Console.WriteLine("Izberete opcija:");
                Console.WriteLine("1. Registriraj nov trkac");
                Console.WriteLine("2. Prikaz na site prijaveni trkaci");
                Console.WriteLine("3. Filtriraj po kategorija");
                Console.WriteLine("4. Prikaz na trkaci pod 18 godini");
                Console.WriteLine("5. Izlez od aplikacijata");

                Console.Write("Vasiot izbor (1-5): ");

                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        RegisterNewRunner(newManager);
                        break;
                    case "2":
                        ShowAllRunners(newManager);
                        break;
                    case "3":
                        FilterRunnersByCategory(newManager);
                        break;
                    case "4":
                        ShowUnderageRunners(newManager);
                        break;
                    case "5":
                        Console.WriteLine("Vi blagodarime sto ja koristevte aplikacijata");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Nevaliden izbor! Izberete od 1-5");
                        break;

                }
            }
            
        }
        static void RegisterNewRunner(MarathonManager manager)
        {
            Console.WriteLine("Registracija na nov trkac: ");

            try
            {
                int id = new Random().Next(1000, 9999);

                Console.WriteLine("Vnesete ime: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Vnesete prezime: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("Vnesete E-mail: ");
                string email = Console.ReadLine();

                Console.WriteLine("Vnesete godini:");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Izberete kategorija:");
                Console.WriteLine("1. 5Km");
                Console.WriteLine("2. 10Km");
                Console.WriteLine("3. 42Km");

                int categoryChoice = int.Parse(Console.ReadLine());
            
                Category category = (Category)categoryChoice;

                Runner newRunner = new Runner(id, firstName, lastName, email, age, category);

                manager.AddRunner(newRunner);
                manager.SaveJsonToFile();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Uspesno: Trkacot {firstName} {lastName} e uspesno registriran!!!");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Greska pri registracija {ex.Message}");
                Console.ResetColor();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vnesovte nevaliden format za godini ili kategorija");
                Console.ResetColor();
            }
        }
        static void ShowAllRunners(MarathonManager manager)
        {
            var runners = manager.GetAllRunners();
            PrintRunnersList(runners, "Site prijaveni trkaci");
        }
        static void FilterRunnersByCategory(MarathonManager manager)
        {
            Console.WriteLine("Izberete kategorija: ");
            Console.WriteLine("1. 5Km");
            Console.WriteLine("2. 10Km" );
            Console.WriteLine("3. 42Km");

            int categoryChoice = int.Parse(Console.ReadLine());

            if (categoryChoice >= 1 && categoryChoice <= 3)
            {
                Category category = (Category)categoryChoice;
                var filteredRunners = manager.GetRunnersByCategory(category);
                PrintRunnersList(filteredRunners, $"Prijaveni trkaci vo katergorijata {category}");
            }
            else
            {
                Console.WriteLine("Nevaliden izbor na kategorija");
            }
        }
        static void ShowUnderageRunners(MarathonManager manager)
        {
            var underage = manager.GetUnderageRunners();
            PrintRunnersList(underage, "Trkaci so pomalku od < 18 godini");
        }
        
        static void PrintRunnersList(List<Runner> runners, string title)
        {
            Console.WriteLine($"\n {title}");
            if(runners.Count == 0)
            {
                Console.WriteLine("Ne se pronajdeni trkaci");
                return;
            }
            foreach (var r in runners)
            {
                Console.WriteLine($"ID: {r.Id} | Ime: {r.FirstName} | Prezime: {r.LastName} | E-mail: {r.Email} | Age: {r.Age} | Kategorija: {r.Category}");
            }
        }
    }
}