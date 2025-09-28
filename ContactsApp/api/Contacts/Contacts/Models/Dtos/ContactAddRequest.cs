using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.Dtos;

public class ContactAddRequest
{
    [Required]
    public string? Name { get; set; }
    public string? Email { get; set; }
    [Required]
    public string? Phone { get; set; }
    public bool Favourite { get; set; }
}
