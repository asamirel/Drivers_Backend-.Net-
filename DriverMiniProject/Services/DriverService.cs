using DriverMiniProject.Model;
using DriverMiniProject.Helpers;
using Newtonsoft.Json;

namespace DriverMiniProject.Services
{
    public class DriverService : IDriverService
    {
        private static string filePath = Directory.GetCurrentDirectory() + "\\driverDB.json";

        public Driver getDriverById(Guid id)
        {
            List<Driver> drivers = FileHandler.LoadJson(filePath);
            return drivers.Find(d => d.id == id);
        }

        public Driver createDriver(Driver driver) 
        {
            FileHandler.WriteToJsonFile(filePath , driver);
            return driver;
        }

        public void deleteDriver(Guid id)
        {
            //get all drivers as object
            List<Driver> drivers = FileHandler.LoadJson(filePath);
            //delete the driver, then write them back
            drivers.Remove(drivers.Find(d => d.id == id));

            var jsonData = JsonConvert.SerializeObject(drivers);
            File.WriteAllText(filePath, jsonData);
        }

        public Driver updateDriverDetails(Guid id, Driver driver)
        {
            //get all drivers as object
            List<Driver> drivers = FileHandler.LoadJson(filePath);
            for(int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].id == id)
                {
                    drivers[i].email = driver.email;
                    drivers[i].firstName = driver.firstName;
                    drivers[i].lastName = driver.lastName;
                    drivers[i].phoneNumber = driver.phoneNumber;
                }
            }
            var jsonData = JsonConvert.SerializeObject(drivers);
            File.WriteAllText(filePath, jsonData);

            return driver;
        }

        public IEnumerable<Driver> getAllDrivers() 
        {
            List<Driver> drivers = FileHandler.LoadJson(filePath);
            return drivers;
        }

    }
}
