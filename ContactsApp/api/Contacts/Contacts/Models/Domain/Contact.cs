using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.Domain;

public class Contact
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Email { get; set; }
    [Required]
    public string? Phone { get; set; }
    public bool Favourite { get; set; }
}
