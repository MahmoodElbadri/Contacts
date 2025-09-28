using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.Dtos;

public class ContactResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool Favourite { get; set; }
}