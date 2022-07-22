namespace DbAccess.DbClasses;


public class OrderDetailDisplay
{
    public Guid OrderId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime Data { get; set; }
}