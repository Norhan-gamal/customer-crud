using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace lab6.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }


        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [minPrice(150)]
        public int TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        public Customer ?Customer { get; set; }
    }
}
