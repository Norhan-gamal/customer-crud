using System.ComponentModel.DataAnnotations;

namespace lab6.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNum { get; set; }

        public IEnumerable<Order> ?Orders { get; set; }
    }
}

public enum Gender
{ Male, Female }