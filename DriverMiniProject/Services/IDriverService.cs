using DriverMiniProject.Model;

namespace DriverMiniProject.Services
{
    public interface IDriverService
    {
        public Driver getDriverById(Guid id);

        public Driver createDriver(Driver driver);
        public void deleteDriver(Guid id);

        public Driver updateDriverDetails(Guid id, Driver driver);

        public IEnumerable<Driver> getAllDrivers();
    }
}
