using DriverMiniProject.Model;
using DriverMiniProject.Services;
using Newtonsoft.Json;

namespace DriverMiniProject.Helpers
{
    public class FileHandler
    {
        public static void WriteToJsonFile(string filePath, Driver driver)
        {
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var driverList = JsonConvert.DeserializeObject<List<Driver>>(jsonData)
                                  ?? new List<Driver>();

            driverList.Add(driver);
            // Update json data string
            jsonData = JsonConvert.SerializeObject(driverList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        public static List<Driver> LoadJson(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<Driver> drivers = JsonConvert.DeserializeObject<List<Driver>>(json);
                return drivers;
            }
        }
    }
}
