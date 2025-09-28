using AutoMapper;
using Contacts.Models.Domain;

namespace Contacts.Models.Dtos;

public class ContactsProfile:Profile
{
    public ContactsProfile()
    {
        CreateMap<ContactAddRequest, Contact>()
            .ReverseMap();
        CreateMap<Contact, ContactResponse>()
            .ReverseMap();
    }
}
