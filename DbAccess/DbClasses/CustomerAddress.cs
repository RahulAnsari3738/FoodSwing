
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbAccess.DbClasses
{
    public class CustomerAddress
    {
        [Key]
        [Required]
        public Guid ID { get; set; }

        [ForeignKey("customerbb")]
        public Guid CustomerId { get; set; }
        public Customer customerbb { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        [Required]
        public string State { get; set; }


        [Required]
        public string Landmark { get; set; }

        [Required]
        public string Phone { get; set; }

        public bool Active { get; set; }

    }
}