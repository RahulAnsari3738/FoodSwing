using System.ComponentModel.DataAnnotations;
namespace DbAccess.DbClasses;



public class Customer
{

    [Key]
    public Guid ID { get; set; }

    [MinLength(3)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    [MaxLength(15), MinLength(9)]
    public string Password { get; set; }
    public bool isActive { get; set; } = true;

}

