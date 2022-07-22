
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbAccess.DbClasses
{
    public class Cart
    {

        [Key]

        public Guid ID { get; set; }
        [ForeignKey("RestautantId")]
        public Guid RestautantIID { get; set; }
        public Restaurant RestautantI { get; set; }

        [ForeignKey("menuitem")]
        public Guid ItemId { get; set; }
        public MenuItem menuitem { get; set; }

        [ForeignKey("customer")]
        public Guid CustomerId { get; set; }
        public Customer customer { get; set; }
        // public string ItemName { get; set; }
        public int Quantity { get; set; }

    }
}