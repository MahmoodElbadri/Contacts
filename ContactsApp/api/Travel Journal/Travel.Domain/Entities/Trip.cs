namespace Travel.Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int OwnerID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? CoverImageUrl { get; set; }
}
