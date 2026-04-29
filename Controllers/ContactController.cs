using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Models;
using System.Collections.Immutable;

namespace PhoneBookAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    static private List<Contact> contacts = new List<Contact>
    {
        new Contact
        { Id = 1,
          Name = "Sarah",
          Phone = "0763549335",
          Email ="sarah@gmail.com"
        },
        new Contact
        { Id = 2,
          Name = "Mona",
          Phone = "0836594123",
          Email ="mona@gmail.com"
        },
        new Contact
        { Id = 3,
          Name = "Earl",
          Phone = "0725698756",
          Email ="earl@gmail.com"
        }
    };
    [HttpGet]                                                          
    public ActionResult<List<Contact>> GetContact()
    {
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public ActionResult<Contact> GetContactByID(int id)
    {
        var contact = contacts.FirstOrDefault(x => x.Id == id);
        if (contact == null)
            return NotFound();

        return Ok(contact);
    }

    [HttpPost]
    public ActionResult<List<Contact>> AddContact([FromBody] Contact newContact)
    {
        if (newContact == null)
        {
            return BadRequest();
        }
        newContact.Id = contacts.Count + 1;
        contacts.Add(newContact);
        return Ok(contacts);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateContact(int id, [FromBody] Contact updatedContact)
    {
        var contact = contacts.FirstOrDefault(x => x.Id == id);
        if (contact == null)
            return NotFound();
        contact.Name = updatedContact.Name;
        contact.Phone = updatedContact.Phone;
        contact.Email = updatedContact.Email;

        return Ok(contact);
    }

    [HttpDelete("{id}")]
    public IActionResult deleteContact(int id)
    {
        var contact = contacts.FirstOrDefault(x => x.Id == id);
        if (contact == null)
            return NotFound();
        contacts.Remove(contact);
        return Ok(contact);
    }

}
