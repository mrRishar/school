using Store.Application.Models;
using System.Text.Json;

namespace Store.Application.Models.Services
{
    public class PhonesService
    {
        private const string FilePath = "phones.json";

        public List<Phone> GetAll()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
            var fileContent = File.ReadAllText(FilePath);
            if (fileContent.Length > 2)
            {
                return JsonSerializer.Deserialize<List<Phone>>(fileContent);
            }
            return new List<Phone>();
        }

        public Phone Get(uint id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Add(Phone phone)
        {
            var phoneCollection = GetAll();
            if (phoneCollection.Any())
            {
                phone.Id = phoneCollection.Max(x => x.Id) + 1;
            }
            else
            {
                phone.Id = 1;
            }
            phoneCollection.Add(phone);

            var fileContent = JsonSerializer.Serialize(phoneCollection);
            File.WriteAllText(FilePath, fileContent);
        }

        public void Delete(uint id)
        {
            var phonesCollection = GetAll();
            phonesCollection = phonesCollection.Where(p => p.Id != id).ToList();

            var fileContent = JsonSerializer.Serialize(phonesCollection);
            File.WriteAllText(FilePath, fileContent);
        }
    }
}