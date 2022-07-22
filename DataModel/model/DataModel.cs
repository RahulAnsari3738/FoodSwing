
using System.ComponentModel.DataAnnotations;

namespace DataModel.Model
{


    public class CreateRestaurant
    {

        public string RestaurantName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }



    }


    public class CreateMenuItem

    {
        //[FromBody]

        public Guid RestautantId { get; set; }

        public string? ItemName { get; set; }


        public string? Icon { get; set; }


        public int UnitPrice { get; set; }



    }


    public class createcart
    {

        public Guid ID { get; set; }

        public Guid CustomerId { get; set; }
        public Guid ItemId { get; set; }

        public string? Quantity { get; set; }


    }

    public class CreateCustomerAddress
    {

        // public Guid ID { get; set; }

        public Guid CustomerId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Landmark { get; set; }

        public string Phone { get; set; }

        // public bool Active { get; set; }





    }



    public class CreateOrder

    {

        // public Guid ID { get; set; }
        public Guid CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string SubTotal { get; set; }
        public string Tax { get; set; }

        public string Total { get; set; }
        public Guid RestautantId { get; set; }
        public Guid? ItemId { get; set; }
        public string Instruction { get; set; }
        public string Landmark { get; set; }
        public string Phone { get; set; }

        // public string Active { get; set; }





    }



    public class CustomerSignUp
    {


        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        [MaxLength(16), MinLength(8)]
        public string Password { get; set; }
    }


    public class CustomerLogin
    {


        public String Email { get; set; }
        [MaxLength(16), MinLength(8)]
        public string Password { get; set; }


    }


    // public class CartModel
    // {

    //     public Guid ID { get; set; }
    //     public Guid ItemId { get; set; }
    //     public string ItemName { get; set; }
    // }

    public class CartModel
    {

        public Guid RestautantId { get; set; }
        public Guid ItemId { get; set; }
        public Guid CustomerId { get; set; }

        public int Quantity { get; set; }
    }


    public class CreateOrderStatus
    {

        public Guid Orderid { get; set; }

        public DateTime StatusDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public string Desc { get; set; }
        public string StatusBy { get; set; }

    }

}