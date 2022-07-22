using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
namespace FoodSwing.Controllers;


[ApiController]
[Route("[controller]")]
public class OrderDetailController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase

    private ILogger<OrderDetail> _logger;

    public OrderDetailController(FoodSwingContext context, ILogger<OrderDetail> logger)
    {

        _context = context;
        _logger = logger;

    }


    //GetOrderById
    [HttpGet]

    [Route("orderdetailbyid")]

    public OrderDetail Get(Guid id)
    {
        var orderdetail = _context.OrderDetails.Where(record => record.ID == id).FirstOrDefault();


        if (orderdetail != null)

        {
            return orderdetail;

        }

        throw new Exception("OrerDetail not found...!");

    }


    //Get AllOrder
    [HttpGet]

    [Route("allorderdetail")]

    public List<OrderDetail> GetAll()

    {

        var orderdetail = _context.OrderDetails.ToList();
        Console.WriteLine(orderdetail);
        return orderdetail;

    }

    //Create OrderDetails

    [HttpPost]

    [Route("createorderdetail")]

    public OrderDetail Crate(OrderDetail OrderInfo)

    {



        if (OrderInfo.ID == Guid.Empty)
        {
            OrderInfo.ID = Guid.NewGuid();
        }


        _context.OrderDetails.Add(OrderInfo);
        _context.SaveChanges();
        return OrderInfo;
    }


    //UpdateOrderDetails

    [HttpPut]

    [Route("updateorderdetails")]

    public OrderDetail UpdateOrderDetail(Guid ID, OrderDetail UpdateOrder)
    {

        var ExistOrder = _context.OrderDetails.Where(record => record.ID == ID).FirstOrDefault();

        if (ExistOrder.ID != null)
        {

            //Restaurant restaurant = new Restaurant();

            ExistOrder.Orderid = UpdateOrder.Orderid;
            ExistOrder.itemid = UpdateOrder.itemid;
            ExistOrder.Quantity = UpdateOrder.Quantity;



            // _context.Restaurants.Add(restaurant);

            _context.SaveChanges();
            return ExistOrder;


        }

        throw new Exception("  OrerDetail Not  Found");

    }



    [HttpGet]
    [Route("orderdetailslinq")]

    public List<OrderDetailDisplay> OrderDetailasLInq(Guid OrdeID)
    {

        var order = _context.Orders.ToList();
        var customer = _context.customers.ToList();
        var menuItem = _context.MenuItems.ToList();
        var restaurant = _context.Restaurants.ToList();
        var carts = _context.Carts.ToList();





        var FindOrder = _context.Orders.Where(x => x.ID == OrdeID).SingleOrDefault();

        if (FindOrder == null)

        {

            throw new Exception("not Found..!");
        }

        else

        {

            var result = from o in order
                         join c in customer
                         on o.CustomerId equals c.ID

                         join i in menuItem
                         on o.ItemId equals i.ID

                         join r in restaurant
                         on o.RestautantId equals r.ID

                         join cart in carts
                         on i.ID equals cart.ItemId
                         select new OrderDetailDisplay
                         {

                             OrderId = o.ID,
                             ItemId = i.ID,
                             Quantity = cart.Quantity,
                             Data = o.Time


                         };

            return result.ToList();


        }

    }



}


