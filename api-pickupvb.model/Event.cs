namespace api_pickupvb.model;
public class Event
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}
