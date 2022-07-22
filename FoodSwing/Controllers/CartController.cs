using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
using DbAccess.DisplayClasses;
namespace FoodSwing.Controllers;


[ApiController]
[Route("[Controller]")]
public class CartController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase


    private ILogger<Restaurant> _logger; // represent logger
    public CartController(FoodSwingContext context, ILogger<Restaurant> logger)
    {

        _logger = logger;

        _context = context;

    }

    //get Cart information By ID
    [HttpGet]

    [Route("cartbyid")]

    public Cart Get(Guid ID)

    {

        _logger.LogInformation("information of restaurant {id}");


        var cart = _context.Carts.Where(record => record.ID == ID).FirstOrDefault();

        if (cart != null)

        {
            return cart;

        }

        throw new Exception("Cart not found...");

    }


    // Get All Cart 
    [HttpGet]

    [Route("all-Cart")]

    public List<Cart> GetAll()

    {

        var cart = _context.Carts.ToList();
        Console.WriteLine(cart);
        return cart;

    }

    //Create Cart

    [HttpPost]
    [Route("cart-create")]
    public Cart Create(CartModel insert)
    {
        Cart cart = new Cart();
        if (cart.ID == Guid.Empty)
        {
            cart.ID = Guid.NewGuid();
        }
        var SameItemIDExists = _context.Carts.Where(x => x.ItemId == insert.ItemId && x.CustomerId == insert.CustomerId).Any();

        if (!SameItemIDExists)
        {
            cart.CustomerId = insert.CustomerId;
            cart.RestautantID = insert.RestautantId;
            cart.ItemId = insert.ItemId;
            cart.Quantity = 1;
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart;
        }
        else
        {
            Cart existingCart = _context.Carts.Where(x => x.ItemId == insert.ItemId && x.CustomerId == insert.CustomerId).FirstOrDefault();
            existingCart.RestautantID = insert.RestautantId;
            existingCart.ItemId = insert.ItemId;
            existingCart.Quantity++;
            _context.SaveChanges();
            return cart;
        }

    }


    [HttpGet]
    [Route("/get-cartdetailas-with-join")]
    public List<CartDisplay> GetCartInfo()
    {
        var menuItem = _context.MenuItems.ToList();
        var cart = _context.Carts.ToList();
        var restaurant = _context.Restaurants.ToList();

        var query =
        from c in cart
        join m in menuItem
        on c.ItemId equals m.ID
        join r in restaurant
        on c.RestautantID
         equals r.ID
        select new CartDisplay
        {
            CartID = c.ID,
            CustomerID = c.CustomerId,
            RestaurantName = r.RestaurantName,
            MenuItemID = m.ID,
            ItemName = m.ItemName,
            ItemQuantity = c.Quantity,
            ItemUnitPrice = m.UnitPrice,
            ItemPrice = c.Quantity * m.UnitPrice

        };

        return query.ToList();



    }

    //update cart

    [HttpPost]
    [Route("update-cart")]
    public Cart UpdateCart(Guid MenuItemID, Guid CustomerId, CartModel update) //remaining
    {
        var cart = _context.Carts.Where(x => x.ItemId == MenuItemID && x.CustomerId == CustomerId).SingleOrDefault();

        if (cart == null)
        {

            throw new Exception("Not found");

        }
        else
        {

            cart.RestautantID = update.RestautantId;
            cart.ItemId = update.ItemId;
            cart.Quantity = update.Quantity;

            _context.SaveChanges();
            return cart;
        }
    }

    //Remove Cart
    [HttpPost]
    [Route("delete")]
    public String CartDelete(Guid cartID)
    {
        var cart = _context.Carts.Where(c => c.ID == cartID).FirstOrDefault();
        _context.Remove(cart);
        _context.SaveChanges();

        return $"Cart Delete Successfully...!!";
    }


}





















