
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbAccess.DbClasses
{
    public class OrderDetail
    {

        public Guid ID { get; set; }

        [ForeignKey("oredr")]
        public Guid Orderid { get; set; }
        public Order oredr { get; set; }

        [ForeignKey("ItemID")]
        public Guid itemid { get; set; }
        public MenuItem ItemID { get; }

        public string Quantity { get; set; }

        public DateTime DateOnly { get; set; } = DateTime.Now;



    }
}