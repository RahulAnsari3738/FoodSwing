namespace DbAccess.DisplayClasses;


public class CartDisplay
{
    public Guid CartID { get; set; }

    public Guid CustomerID { get; set; }
    public object RestaurantName { get; set; }
    public Guid MenuItemID { get; set; }
    public object ItemName { get; set; }
    public int ItemQuantity { get; set; }
    public int ItemUnitPrice { get; set; }
    public int ItemPrice { get; set; }
}