
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbAccess.DbClasses
{
    public class MenuItem
    {
        [Key]
        public Guid ID { get; set; }


        [ForeignKey("restautantId")]

        public Guid RestautantId { get; set; }
        public Restaurant restautant { get; set; }
        //[FromBody]
        [Required]
        public string? ItemName { get; set; }

        [Required]
        public string? Icon { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }



}