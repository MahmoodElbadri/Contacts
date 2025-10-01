namespace Travel.Domain.Entities;

public class TripPhoto
{
    public int Id { get; set; }
    public int TripID { get; set; }
    public string Url { get; set; }
}
