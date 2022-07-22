namespace DbAccess.DisplayClasses;
public class OredrDisplay

{
    public Guid ID { get; set; }
    public Guid CustomerId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public DateTime Time { get; set; }
    public int SubTotal { get; set; }
    public int Tax { get; set; }
    public int Total { get; set; }
    public Guid RestautantId { get; set; }
    public Guid ItemId { get; set; }
    public string Instruction { get; set; }
    public string Landmark { get; set; }
    public string Phone { get; set; }
    public bool Active { get; set; }
}