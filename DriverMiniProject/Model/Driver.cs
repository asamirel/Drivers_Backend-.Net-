using System.ComponentModel.DataAnnotations;

namespace DriverMiniProject.Model
{
    [Serializable]
    public class Driver
    {
        public Guid id { get; set; }

        [StringLength(255), Required]
        public string firstName { get; set; }

        [StringLength(255), Required]
        public string lastName { get; set; }

        [StringLength(255), Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [StringLength(255), Required]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }
    }
}
