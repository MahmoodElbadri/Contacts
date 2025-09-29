namespace Travel.Domain.Entities;

public class TripDay
{
    public int Id { get; set; }
    public int TripID { get; set; }
    public int DayNumber { get; set; }
    public string Location { get; set; }
    public string Notes { get; set; }
}
