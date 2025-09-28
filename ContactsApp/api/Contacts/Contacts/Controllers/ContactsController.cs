using AutoMapper;
using Contacts.Data;
using Contacts.Models.Domain;
using Contacts.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController (ContactsDbContext _dbContext, IMapper _mapper): ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Contact>> GetAll()
    {
        var contacts = _dbContext.Contacts.ToList();
        return Ok(contacts);
    }

    [HttpPost]
    public ActionResult<ContactResponse> AddContact([FromBody] ContactAddRequest addRequest)
    {
        var contact = _mapper.Map<Contact>(addRequest);
        _dbContext.Contacts.Add(contact);
        _dbContext.SaveChanges();
        var response = _mapper.Map<ContactResponse>(contact);
        return Ok(response);
    }
}
