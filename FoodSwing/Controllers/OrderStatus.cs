using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
namespace FoodSwing.Controllers;


[ApiController]
[Route("[controller]")]
public class OrerStatusController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase

    private ILogger<OrderStatus> _logger; // represent logger
    public OrerStatusController(FoodSwingContext context, ILogger<OrderStatus> logger)
    {
        _logger = logger;
        _context = context;

    }

    //GetOrderStatusBy:ID

    [HttpGet]

    [Route("orderstatusbyid")]

    public OrderStatus Get(Guid id)
    {


        _logger.LogInformation("information of OrderStatus");

        var orderstatus = _context.OrderStatuses.Where(record => record.ID == id).FirstOrDefault();


        if (orderstatus != null)

        {
            return orderstatus;

        }

        throw new Exception("OrderStatus not found...!");

    }


    //Get AllOrderStatus
    [HttpGet]

    [Route("allorderstatus")]

    public List<OrderStatus> GetAll()

    {

        var orderStatus = _context.OrderStatuses.ToList();
        Console.WriteLine(orderStatus);
        return orderStatus;

    }


    //Create OredrStatus
    [HttpPost]

    [Route("createorderstatus")]

    public OrderStatus Crate(CreateOrderStatus createOrder)

    {

        OrderStatus status = new OrderStatus();

        if (status.ID == Guid.Empty)
        {
            status.ID = Guid.NewGuid();
        }

        status.Orderid = createOrder.Orderid;
        status.StatusDate = createOrder.StatusDate;
        status.Status = createOrder.Status;
        status.Desc = createOrder.Desc;
        status.StatusBy = createOrder.StatusBy;
        _context.OrderStatuses.Add(status);
        _context.SaveChanges();
        return status;
    }


    //UpdateOrderStatus
    [HttpPut]

    [Route("updateorderstatus")]

    public OrderStatus UpdateOrderStatus(Guid ID, OrderStatus UpdateOrderStatus)
    {

        var ExistOrderStatus = _context.OrderStatuses.Where(record => record.ID == ID).FirstOrDefault();

        if (ExistOrderStatus.ID != null)
        {

            ExistOrderStatus.Orderid = UpdateOrderStatus.Orderid;
            ExistOrderStatus.StatusDate = UpdateOrderStatus.StatusDate;
            ExistOrderStatus.Status = UpdateOrderStatus.Status;
            ExistOrderStatus.Desc = UpdateOrderStatus.Desc;
            ExistOrderStatus.StatusBy = UpdateOrderStatus.StatusBy;

            _context.SaveChanges();
            return ExistOrderStatus;


        }

        throw new Exception(" OrderStatus Not  Found");

    }


    // [HttpGet]
    // [Route("orderdetailslinq")]

    // public List<OrderStatusDisplay> OrderDetailasLInq(Guid OrdeID)
    // {

    //     var order = _context.Orders.ToList();
    //     var customer = _context.customers.ToList();
    //     var menuItem = _context.MenuItems.ToList();
    //     var restaurant = _context.Restaurants.ToList();
    //     var carts = _context.Carts.ToList();





    //     var FindOrder = _context.Orders.Where(x => x.ID == OrdeID).SingleOrDefault();

    //     if (FindOrder == null)

    //     {

    //         throw new Exception("not Found..!");
    //     }

    //     else

    //     {

    //         var result = from o in order
    //                      join c in customer
    //                      on o.CustomerId equals c.ID

    //                      join i in menuItem
    //                      on o.ItemId equals i.ID

    //                      join r in restaurant
    //                      on o.RestautantId equals r.ID

    //                      join cart in carts
    //                      on i.ID equals cart.ItemId
    //                      select new OrderStatusDisplay
    //                      {

    //                          OrderId = o.ID,
    //                          ItemId = i.ID,
    //                          Quantity = cart.Quantity,
    //                          Data = o.Time


    //                      };

    //         return result.ToList();


    //     }

    // }



}


