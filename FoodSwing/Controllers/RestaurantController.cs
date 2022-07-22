using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
using DbAccess.DisplayClasses;
using Microsoft.AspNetCore.Authorization;
namespace FoodSwing.Controllers;


[ApiController]
[Route("[Controller]")]
public class RestaurantController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase


    private ILogger<Restaurant> _logger; // represent logger
    public RestaurantController(FoodSwingContext context, ILogger<Restaurant> logger)
    {

        _logger = logger;

        _context = context;

    }

    private IQueryable<Restaurant> ActiveRestaurants()
    {
        return _context.Restaurants.Where(x => x.isActive);
    }

    //get Reastaurant information
    [HttpGet]

    [Route("getrestaurantbyid")]

    public Restaurant Get(Guid id)

    {

        _logger.LogInformation("information of restaurant {id}");


        var restaurant = ActiveRestaurants().Where(record => record.ID == id).FirstOrDefault();

        if (restaurant != null)

        {
            return restaurant;

        }

        throw new Exception("Restaurant not found...");

    }


    [Authorize]
    [HttpGet]

    [Route("getallrestaurants")]

    public List<Restaurant> GetAll()

    {

        var restaurant = ActiveRestaurants().ToList();
        Console.WriteLine(restaurant);
        return restaurant;

    }

    [HttpPost]

    [Route("createrestaurant")]

    public Restaurant Crate(CreateRestaurant Restmodel)

    {
        Restaurant restaurant = new Restaurant();

        if (restaurant.ID == Guid.Empty)
        {
            restaurant.ID = Guid.NewGuid();
        }
        restaurant.RestaurantName = Restmodel.RestaurantName;
        restaurant.Phone = Restmodel.Phone;
        restaurant.Email = Restmodel.Email;
        restaurant.State = Restmodel.State;
        restaurant.City = Restmodel.City;
        restaurant.Street1 = Restmodel.Street1;
        restaurant.Street2 = Restmodel.Street2;
        restaurant.Icone = "icon.jpg";
        restaurant.Landmark = Restmodel.Landmark;
        restaurant.isActive = true;

        var ExistRestaurantName = _context.Restaurants.Where(record => record.RestaurantName == restaurant.RestaurantName).Any();

        if (!ExistRestaurantName)
        {

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        throw new Exception("RestaurantName is allready Exist");

    }


    [HttpPut]

    [Route("updaterestaurant")]

    public Restaurant UpdateRestaurant(Guid ID, CreateRestaurant UpdateModel)
    {

        var ExistRestaurant = _context.Restaurants.Where(record => record.ID == ID).FirstOrDefault();

        if (ExistRestaurant.ID != null)
        {

            //Restaurant restaurant = new Restaurant();

            ExistRestaurant.RestaurantName = UpdateModel.RestaurantName;
            ExistRestaurant.Phone = UpdateModel.Phone;
            ExistRestaurant.Email = UpdateModel.Email;
            ExistRestaurant.State = UpdateModel.State;
            ExistRestaurant.City = UpdateModel.City;
            ExistRestaurant.Street1 = UpdateModel.Street1;
            ExistRestaurant.Street2 = UpdateModel.Street2;
            ExistRestaurant.Icone = "icon.jpg";
            ExistRestaurant.Landmark = UpdateModel.Landmark;

            // _context.Restaurants.Add(restaurant);

            _context.SaveChanges();
            return ExistRestaurant;


        }

        throw new Exception("Not  Found");

    }


    [HttpGet]
    [Route("searchbyname")]

    public List<Restaurant> Search(string Name)
    {

        Name = Name.ToLower();

        var list = _context.Restaurants.Where(record => record.RestaurantName.Contains(Name)).ToList();

        return list;

    }



    [HttpGet]
    [Route("DeIsActivate")]
    public bool DeIsActivate(Guid ID)
    {

        var restuarant = Get(ID);
        if (restuarant != null)
        {
            restuarant.isActive = false;
        }
        return _context.SaveChanges() > 0;

    }



    //DeActive And Activate Customer EndPoint

    [HttpPut]
    [Route("customer-active/deactive")]
    public bool ActiveDeactive(Guid ID)
    {

        var RestaurantActive = _context.Restaurants.Where(x => x.ID == ID).SingleOrDefault();

        if (RestaurantActive == null)
        {
            throw new Exception("Customer Not Found");
        }

        else if (RestaurantActive.isActive == false)
        {

            RestaurantActive.isActive = true;
        }

        else if (RestaurantActive.isActive == true)


        {

            RestaurantActive.isActive = false;


        }
        return _context.SaveChanges() > 0;




    }

    [HttpGet]
    [Route("avalibale-menuItem-in-restaurant")]

    public List<MenuItemDisplay> GetCustomerAddress(Guid ID)

    {



        var menuitem = _context.MenuItems.Where(x => x.RestautantId == ID).ToList();

        var restaurant = _context.Restaurants.Where(x => x.ID == ID).ToList();
        var query =

        from r in restaurant

        join m in menuitem
        on
        r.ID equals m.RestautantId

        select new MenuItemDisplay

        {
            ItemID = m.ID,
            ItemName = m.ItemName,
            UnitPrice = m.UnitPrice,
        };

        return query.ToList();



    }









}



