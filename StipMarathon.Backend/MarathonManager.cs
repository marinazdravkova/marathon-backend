using StipMarathon.Backend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace StipMarathon.Backend
{
    public class MarathonManager
    {
        private List<Runner> _runners;

        private const string FilePath = "runners.json";

        public MarathonManager()
        {
            _runners = new List<Runner>();
            LoadJson();
        }

        public void AddRunner(Runner runner)
        {
           
                if(runner.FirstName == null || runner.LastName == null)
                {
                    throw new ArgumentException("Полињата за Име/Презиме не смеат да бидат празни");
                }

                bool runnerEmail = _runners.Any(x => x.Email == runner.Email);

                if(runnerEmail) {
                
                    throw new ArgumentException("Внесениот Емаил веќе постои.");
                 }
            
            
            _runners.Add(runner);
        }

        public List<Runner> GetAllRunners()
        {
            return _runners; 
        }

        public List<Runner> GetRunnersByCategory(Category category)
        {
            List<Runner> runnersByCategory = _runners.Where(x => x.Category == category).ToList();

            return runnersByCategory;
        }

        public List<Runner> GetUnderageRunners ()
        {
            List<Runner> runnersUnderage = _runners.Where(x => x.Age < 18).ToList();

            return runnersUnderage;
        }

        public void SaveJsonToFile()
        {
            string jsonString = JsonSerializer.Serialize(_runners);

            File.WriteAllText(FilePath, jsonString);
        }

        public void LoadJson()
        {
            if(File.Exists(FilePath))
            {
                string jsonString = File.ReadAllText(FilePath);

                _runners = JsonSerializer.Deserialize<List<Runner>>(jsonString) ?? new List<Runner>();
            }
        }
    }
}
