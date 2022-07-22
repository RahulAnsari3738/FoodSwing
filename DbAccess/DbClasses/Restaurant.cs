
using System.ComponentModel.DataAnnotations;
namespace DbAccess.DbClasses
{
    public class Restaurant
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(24), MinLength(5)]
        public string RestaurantName { get; set; }
        [Required]
        public string Icone { get; set; }
        [Required]
        [MaxLength(12), MinLength(12)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string Landmark { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public bool isActive { get; set; }
    }
}