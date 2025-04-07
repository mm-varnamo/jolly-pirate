using System.Text.Json;

namespace Jolly_Pirate.model
{
    public class Database
    {
        private string _fileName = "MembersRegistry.json";

        public void SaveMembersRegistryToDB(IEnumerable<Member> members)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(members, options);
            File.WriteAllText(_fileName, jsonString);
        }

        public IEnumerable<Member> LoadMembersRegistryFromDB()
        {
            if (!File.Exists(_fileName)) return new List<Member>();

            try
            {
                string jsonString = File.ReadAllText(_fileName);
                return JsonSerializer.Deserialize<List<Member>>(jsonString) ?? new List<Member>();
            }
            catch
            {
                return new List<Member>();
            }
        }
    }
}