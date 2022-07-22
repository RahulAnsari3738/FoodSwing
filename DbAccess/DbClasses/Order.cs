
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace DbAccess.DbClasses
{
    public class Order
    {
        public Guid ID { get; set; }

        [ForeignKey("customerbb")]
        public Guid? CustomerId { get; set; }
        public Customer customeri { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string SubTotal { get; set; }
        public string Tax { get; set; }

        public string Total { get; set; }

        [ForeignKey("restautantId")]

        public Guid? RestautantId { get; set; }
        public Restaurant restautantId { get; set; }

        [ForeignKey("menuitem")]
        public Guid? ItemId { get; set; }
        public MenuItem menuitem { get; set; }
        public string Instruction { get; set; }
        public string Landmark { get; set; }
        public string Phone { get; set; }

        public bool Active { get; set; }

    }
}