using JsonLesson.Data;
using JsonLesson.Data.Races;
using Newtonsoft.Json;

namespace JsonLesson.Services
{
    public class RacesService
    {
        private const string FilePath = "races.json";

        public List<Race> GetAll()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            var fileContent = File.ReadAllText(FilePath);
            if (fileContent.Length > 2) 
            {
                return JsonConvert.DeserializeObject<List<Race>>(fileContent);
            }

           return new List<Race>();
        }

        public Race Get(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public void Add(Race race)
        {
            var racesData = GetAll();

            racesData.Add(race);

            var fileContent = JsonConvert.SerializeObject(racesData);
            File.WriteAllText(FilePath, fileContent);
        }
    }
}