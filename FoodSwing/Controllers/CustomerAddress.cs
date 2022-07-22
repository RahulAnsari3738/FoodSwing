using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
namespace FoodSwing.Controllers;


[ApiController]
[Route("[Controller]")]
public class CustomerAddressController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase


    private ILogger<CustomerAddress> _logger; // represent logger
    public CustomerAddressController(FoodSwingContext context, ILogger<CustomerAddress> logger)
    {

        _logger = logger;

        _context = context;

    }


    //perform query Function
    private IQueryable<CustomerAddress> ActiveCustomerAddress()
    {
        return _context.CustomerAddresses.Where(x => x.Active);
    }


    //getCustomerAddressById
    [HttpGet]


    [Route("customeraddress/by/id")]

    public CustomerAddress Get(Guid ID)

    {

        _logger.LogInformation("information of customeraddress {id}");


        var customeraddress = ActiveCustomerAddress().Where(record => record.ID == ID).FirstOrDefault();

        if (customeraddress != null)

        {
            return customeraddress;

        }

        throw new Exception("Address not found...");

    }


    // GetAllCustomerAddress
    [HttpGet]

    [Route("allcustomeraddress")]

    public List<CustomerAddress> GetAll()

    {

        var customeraddress = ActiveCustomerAddress().ToList();
        Console.WriteLine(customeraddress);
        return customeraddress;

    }

    //Create CustomerAddress
    [HttpPost]

    [Route("create-customeraddress")]

    public CustomerAddress Crate(CreateCustomerAddress CreateAddressModel)

    {
        CustomerAddress customeraddress = new CustomerAddress();

        if (customeraddress.ID == Guid.Empty)
        {
            customeraddress.ID = customeraddress.ID = Guid.NewGuid();
        }
        customeraddress.CustomerId = CreateAddressModel.CustomerId;
        customeraddress.Street = CreateAddressModel.Street;
        customeraddress.City = CreateAddressModel.City;
        customeraddress.State = CreateAddressModel.State;
        customeraddress.Landmark = CreateAddressModel.Landmark;
        customeraddress.Phone = CreateAddressModel.Phone;
        customeraddress.Active = true;


        _context.CustomerAddresses.Add(customeraddress);
        _context.SaveChanges();
        return customeraddress;

    }

    //UpdaetCustomer-Address
    [HttpPut]

    [Route("updatecustomeraddress")]

    public CustomerAddress Updatecustomeraddress(Guid ID, CreateCustomerAddress UpdateModel)
    {

        var Existcustomeraddress = _context.CustomerAddresses.Where(record => record.ID == ID).FirstOrDefault();

        if (Existcustomeraddress.ID != null)
        {

            //customeraddress customeraddress = new customeraddress();

            Existcustomeraddress.Street = UpdateModel.Street;
            Existcustomeraddress.City = UpdateModel.Street;
            Existcustomeraddress.State = UpdateModel.State;
            Existcustomeraddress.Landmark = UpdateModel.Landmark;
            Existcustomeraddress.Phone = UpdateModel.Phone;



            // _context.customeraddresss.Add(customeraddress);

            _context.SaveChanges();
            return Existcustomeraddress;


        }

        throw new Exception(" Address Not  Found");

    }

    //Searach By Customer Address By City Name
    [HttpGet]
    [Route("searchbycityname")]

    public List<CustomerAddress> Search(string Name)
    {

        Name = Name.ToLower();

        var list = _context.CustomerAddresses.Where(record => record.City.Contains(Name)).ToList();

        return list;

    }

    // Dactiver Customer Address
    [HttpGet]
    [Route("DeIsActivate")]
    public bool DeIsActivate(Guid ID)
    {

        var customerAddress = Get(ID);
        if (customerAddress != null)
        {
            customerAddress.Active = false;
        }
        return _context.SaveChanges() > 0;

    }






}



