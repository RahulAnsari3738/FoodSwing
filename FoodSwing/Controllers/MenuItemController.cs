using System;
using Microsoft.AspNetCore.Mvc;
using DbAccess.DatabaseContext;
using DbAccess.DbClasses;
using DataModel.Model;
namespace FoodSwing.Controllers;


[ApiController]
[Route("[controller]")]
public class MenuItemController : ControllerBase
{

    private readonly FoodSwingContext _context; //represent DataBase

    public MenuItemController(FoodSwingContext context)
    {

        _context = context;
        // Console.WriteLine(_context + "inside context");

    }

    private IQueryable<MenuItem> ActiveRestaurants()
    {
        return _context.MenuItems.Where(record => record.IsActive);
    }



    //get menuItem by  information
    [HttpGet]

    [Route("getmenuItem")]

    public MenuItem Get(Guid id)
    {
        var menuitem = ActiveRestaurants().Where(record => record.ID == id).FirstOrDefault();
        // var menuitem=ActiveRestaurants().Where(rest=>rest.ID==id);

        if (menuitem != null)

        {
            return menuitem;

        }

        throw new Exception("MenuItems not found...!");

    }


    // getallrestaurants api endPoint
    [HttpGet]

    [Route("getallmenuitems")]

    public List<MenuItem> GetAll()

    {

        var menuitems = ActiveRestaurants().ToList();
        Console.WriteLine(menuitems);
        return menuitems;

    }



    // createmenuItem api endPoint

    [HttpPost]

    [Route("createmenuitem")]

    public MenuItem Crate(CreateMenuItem MenuItemModel)

    {
        MenuItem menuitem = new MenuItem();

        if (menuitem.ID == Guid.Empty)
        {
            menuitem.ID = Guid.NewGuid();
        }
        menuitem.RestautantId = MenuItemModel.RestautantId;
        menuitem.ItemName = MenuItemModel.ItemName;
        menuitem.Icon = "item.jpg";
        menuitem.UnitPrice = MenuItemModel.UnitPrice;
        menuitem.IsActive = true;


        var ExistMenuItem = _context.MenuItems.Where(record => record.ItemName == menuitem.ItemName).Any();

        if (!ExistMenuItem)
        {

            _context.MenuItems.Add(menuitem);
            _context.SaveChanges();
            return menuitem;
        }

        throw new Exception("ItemtName is allready Exist");

    }



    // updatemenuitem api endPoint

    [HttpPut]

    [Route("updatemenuitem")]

    public MenuItem UpdateRestaurant(Guid ID, CreateMenuItem UpdateModel)
    {

        var ExistMenuItem = _context.MenuItems.Where(record => record.ID == ID).FirstOrDefault();

        if (ExistMenuItem.ID != null)
        {

            //Restaurant restaurant = new Restaurant();

            ExistMenuItem.ItemName = UpdateModel.ItemName;
            ExistMenuItem.Icon = UpdateModel.Icon;
            ExistMenuItem.UnitPrice = UpdateModel.UnitPrice;

            _context.SaveChanges();
            return ExistMenuItem;


        }

        throw new Exception("Not  Found");

    }



    //delete api endPoin
    [HttpDelete]
    [Route("deletemenuitem")]


    public MenuItem DeleteMenuItem(Guid ID)
    {


        var ExistDeleteID = _context.MenuItems.Where(record => record.ID == ID).FirstOrDefault();
        if (ExistDeleteID == null)
        {
            throw new Exception("MenuItem Id not found");
        }

        _context.MenuItems.Remove(ExistDeleteID);
        _context.SaveChanges();
        return ExistDeleteID;


    }

    //     public async MenuItem  DeleteMenu(Guid ID){

    //  var ExistDeleteId=_context.MenuItems.FindAsync(ID);

    //        if(ExistDeleteId==null)
    //        {
    //         throw new Exception(" MenuItem ID not found ");
    //        };

    //      _context.MenuItems.Remove(ExistDeleteId);
    //     }

    // DeIsActive api endPoint

    [HttpGet]
    [Route("deisactivate")]
    public bool DeIsActivate(Guid ID)
    {

        var menuitem = Get(ID);
        if (menuitem != null)
        {
            menuitem.IsActive = false;
        }
        return _context.SaveChanges() > 0;

    }


    // searchbyname api endPoint


    [HttpGet]
    [Route("searchbyname")]

    public List<MenuItem> Search(string Name)
    {

        Name = Name.ToLower();

        var list = _context.MenuItems.Where(record => record.ItemName.Contains(Name)).ToList();

        return list;

    }





}



