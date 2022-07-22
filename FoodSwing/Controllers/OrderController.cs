using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
using DbAccess.DisplayClasses;
namespace FoodSwing.Controllers;


[ApiController]
[Route("[Controller]")]
public class OrderController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase


    private ILogger<Order> _logger; // represent logger
    public OrderController(FoodSwingContext context, ILogger<Order> logger)
    {

        _logger = logger;

        _context = context;

    }


    private IQueryable<Order> ActiveOrder()
    {
        return _context.Orders.Where(x => x.Active);
    }

    //get AllOrderBYid
    [HttpGet]


    [Route("Order/by/id")]

    public Order Get(Guid ID)

    {

        _logger.LogInformation("information of Order");


        var order = ActiveOrder().Where(record => record.ID == ID).FirstOrDefault();

        if (order != null)

        {
            return order;

        }

        throw new Exception("Order not found...");

    }


    //GetAllOrder

    [HttpGet]

    [Route("allorder")]

    public List<Order> GetAll()

    {

        var order = ActiveOrder().ToList();
        Console.WriteLine(order);
        return order;

    }


    //Create Order

    [HttpPost]

    [Route("create-order")]

    public Order Crate(CreateOrder OrderModel)

    {
        Order order = new Order();

        if (order.ID == Guid.Empty)
        {
            order.ID = Guid.NewGuid();
        }

        order.CustomerId = OrderModel.CustomerId;
        order.Street = OrderModel.Street;
        order.City = OrderModel.City;
        order.State = OrderModel.State;
        order.Time = DateTime.Now;
        order.SubTotal = OrderModel.SubTotal;
        order.Tax = OrderModel.Tax;
        order.Total = OrderModel.Total;
        order.RestautantId = OrderModel.RestautantId;
        order.ItemId = OrderModel.ItemId;
        order.Instruction = "Check Your Food";
        order.Landmark = OrderModel.Landmark;
        order.Phone = OrderModel.Phone;
        order.Active = true;


        var Existorder = _context.Orders.Where(record => record.ID == order.ID).Any();

        if (!Existorder)
        {

            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        throw new Exception("orderName is allready Exist");

    }


    //Order Update
    [HttpPut]

    [Route("updateorder")]

    public Order Updateorder(Guid ID, Order UpdateModel)
    {

        var Existorder = _context.Orders.Where(record => record.ID == ID).FirstOrDefault();

        if (Existorder.ID != null)
        {

            Existorder.CustomerId = UpdateModel.CustomerId;
            Existorder.Street = UpdateModel.Street;
            Existorder.City = UpdateModel.City;
            Existorder.State = UpdateModel.State;
            Existorder.Time = UpdateModel.Time;
            Existorder.SubTotal = UpdateModel.SubTotal;
            Existorder.Tax = UpdateModel.Tax;
            Existorder.Total = UpdateModel.Total;
            Existorder.RestautantId = UpdateModel.RestautantId;
            Existorder.Instruction = UpdateModel.Instruction;
            Existorder.Landmark = UpdateModel.Landmark;
            Existorder.Phone = UpdateModel.Phone;

            _context.SaveChanges();
            return Existorder;


        }

        throw new Exception(" Address Not  Found");

    }


    // [HttpGet]
    // [Route("searchbyOrdername")]

    // public List<Order> Search(string Name)
    // {

    //     Name = Name.ToLower();

    //     var list = _context.Orders.Where(record => record.City.Contains(Name)).ToList();

    //     return list;

    // }


    //DActiver Order
    [HttpGet]
    [Route("DeIsActivate")]
    public bool DeIsActivate(Guid ID)
    {

        var order = Get(ID);
        if (order != null)
        {
            order.Active = false;
        }
        return _context.SaveChanges() > 0;

    }

//     [HttpGet]
//     [Route("orderlinq")]
//     public Order  GetCartInfo(createcart create)
//     {

//         Order order = new Order();


//         if(order.ID==Guid.Empty)
//    {
//         order.ID=Guid.NewGuid();

//         }
//         var custsomer = _context.customers.ToList();
//         var menuItems = _context.MenuItems.ToList();
//         var restaurant = _context.Restaurants.ToList();
//         // var order = _context.Orders.ToList();
//         var CustAddress = _context.CustomerAddresses.ToList();
//         var cart = _context.Carts.ToList();

//         // var FindDisplayOrder = _context.customers.Where(x => x.ID == CutomerID).SingleOrDefault();

//         // if (FindDisplayOrder == null)

//         // {
//         // throw new Exception("Not Found..!");
//         // }

//         // else

//         // {

//         var query =

//                 // from o in order
//                 // join m in menuItems
//                 // on o.ItemId equals m.ID


//                 from carts in cart
//                 join m in menuItems
//                 on carts.ItemId equals m.ID

//                 join res in restaurant
//                 on carts.RestautantIID equals res.ID

//                 from c in custsomer
//                 join add in CustAddress
//                 on c.ID equals add.CustomerId


//                 select new 
//                 {

//                     ID = Guid.NewGuid(),
//                     CustomerId = c.ID,
//                     Street = add.State,
//                     City = add.City,
//                     State = add.State,
//                     Time = DateTime.Now,
//                     SubTotal = carts.Quantity * m.UnitPrice,
//                     Tax = 30,
//                     Total = carts.Quantity * m.UnitPrice + 30,
//                     RestautantId = res.ID,
//                     ItemId = m.ID,
//                     Instruction = "Check You",
//                     Landmark = add.Landmark,
//                     Phone = c.Phone,
//                     Active = res.isActive
//                 };


//                 // order.CustomerId=query.All(x=> x.CustomerId)



//     }





    // [HttpPost]
    // [Route("create-with-stored-data")]
    // public Order CreateWithData(CreateOrder createOrder)
    // {

    //     Order order = new Order();
    //     var cartData = _context.Carts.Where(x => x.CustomerId == createOrder.CustomerId);

    //     order.ID = Guid.NewGuid();
    //     order.CustomerId = createOrder.CustomerId;

    //     _context.Orders.Add(order);

    //     _context.SaveChanges();

    //     OrderDetailController createOrderDetails = new OrerStatusController(_context);// from OrderDetail Controller
    //     createOrderDetails.CreateWithCart(order.CustomerId, order.ID); // creating data auto.


    //     var menuItemData = _context.MenuItems.ToList();           //defining MenuItem 
    //     var orderDetailsData = _context.OrderDetails.Where(x => x.Orderid == order.ID).ToList(); // defining orderDetails


    //     // getting data by using menuitem and orderDetails and insert that data into order table
    //     var query =
    //    from menu in menuItemData
    //    join ordDetails in orderDetailsData
    //    on
    //    menu.ID equals ordDetails.Itemid
    //    select new
    //    {
    //        SubItemTotal = menu.UnitPrice * ordDetails.Quantity
    //    };

    //     int SubTotal = query.Sum(s => s.SubItemTotal);

    //     order.SubTotal = SubTotal;
    //     order.Tax = 30;
    //     order.Total = SubTotal + order.Tax;
    //     _context.SaveChanges();

    //     return order;








    }



