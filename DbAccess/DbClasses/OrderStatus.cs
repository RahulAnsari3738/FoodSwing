
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbAccess.DbClasses
{
    public class OrderStatus
    {
        [Key]
        public Guid ID { get; set; }
        [ForeignKey("orderInfo")]
        public Guid Orderid { get; set; }


        public DateTime StatusDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public string Desc { get; set; }
        public string StatusBy { get; set; }

    }
}