using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
using DbAccess.CustomerDisplay;
using DbAccess.DisplayClasses;
namespace FoodSwing.Controllers;



[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase

    private ILogger<Customer> _logger;

    public CustomerController(FoodSwingContext context, ILogger<Customer> logger)
    {
        _logger = logger;
        _context = context;
    }


    //Customer SignUp EndPoint

    [HttpPost]
    [Route("customer-signup")]

    public Customer SignUp(CustomerSignUp CustomerModel)
    {

        Customer customer = new Customer();
        if (customer.ID == Guid.Empty)
        {
            customer.ID = Guid.NewGuid();
        }



        var UserExist = _context.customers.Where(X => X.Email == CustomerModel.Email && X.Phone == CustomerModel.Phone).SingleOrDefault();

        if (UserExist == null)
        {
            customer.FirstName = CustomerModel.FirstName;
            customer.LastName = CustomerModel.LastName;
            customer.Email = CustomerModel.Email;
            customer.Phone = CustomerModel.Phone;
            customer.Password = CustomerModel.Password;
            customer.isActive = true;

            _context.customers.Add(customer);
            _context.SaveChanges();
            return customer;

        }
        else


        {

            throw new Exception("User Allready Exist");
        }

    }

    // Customer login EndPoint

    [HttpPost]
    [Route("customer-login")]

    public string login(CustomerLogin login)
    {


        var user = _context.customers.Where(x => x.Email == login.Email).SingleOrDefault();

        if (user == null)
        {
            throw new Exception("Customer  not SignUp Correct");
        }

        else if (user.Password != login.Password)
        {
            throw new Exception("PassWord Not Match");
        }

        else
        {
            return $"Welcome User {user.Email}";
        }

    }

    //Customer Update EndPoint

    [HttpPut]
    [Route("customer-update")]


    public Customer Update(Guid ID, CustomerSignUp UpdateModel)

    {

        var FindCustomer = _context.customers.Where(x => x.ID == ID).SingleOrDefault();
        if (FindCustomer == null)
        {

            throw new Exception("Customer Not Found");

        }
        else if (FindCustomer.isActive == false)
        {

            throw new Exception("Cant Update User Because User In DeisActive State");

        }

        else
        {

            FindCustomer.FirstName = UpdateModel.FirstName;
            FindCustomer.LastName = UpdateModel.LastName;
            FindCustomer.Email = UpdateModel.Email;
            FindCustomer.Phone = UpdateModel.Email;
            FindCustomer.Password = UpdateModel.Password;

            _context.SaveChanges();
            return FindCustomer;

        }
    }




    //DeisActive Customer EndPoint

    [HttpPut]
    [Route("customer-isActive/deisActive")]
    public bool DeisActive(Guid ID)
    {

        var CustomerisActive = _context.customers.Where(x => x.ID == ID).SingleOrDefault();

        if (CustomerisActive == null)
        {
            throw new Exception("Customer Not Found");
        }

        else if (CustomerisActive.isActive == false)
        {

            CustomerisActive.isActive = true;
        }

        else if (CustomerisActive.isActive == true)


        {

            CustomerisActive.isActive = false;


        }
        return _context.SaveChanges() > 0;




    }


    [HttpGet]
    [Route("yourorders")]

    public List<YourOrderDisplay> YourOrders(Guid ID)
    {

        var orderGetAll = _context.Orders.ToList();
        var restaurantGetAll = _context.Restaurants.ToList();
        var menuitemGetAll = _context.MenuItems.ToList();
        // string output = "";

        var FindCustomer = _context.customers.Where(x => x.ID == ID).SingleOrDefault();

        if (FindCustomer == null)

        {

            throw new Exception("not Found..!");
        }

        else


        {

            var result = from o in orderGetAll
                         join r in restaurantGetAll
                         on o.RestautantId equals r.ID

                         join i in menuitemGetAll
                         on o.ItemId equals i.ID
                         select new YourOrderDisplay
                         {

                             CustomerOredrId = o.ID,
                             RestaurantName = r.RestaurantName,
                             ItemName = i.ItemName,
                             TotalAmount = o.Total

                         };

            return result.ToList();


        }


    }


   
   

    //     var FindCustomer =_context.customers.Where(x=>x.ID==ID).SingleOrDefault();

    //     if(FindCustomer==null){
    //         throw new Exception("Customer Not found....!");

    //     }

    //     else
    //     {
    //            FindCustomer.isActive=true;
    //            return _context.SaveChanges()>0;
    //     }


    // }




}




