using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Models;

namespace PhoneBookAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private static List<Contact> contacts = new List<Contact>();
    private static int nextId = 1;

    // GET: api/contact
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(contacts);
    }

    // GET: api/contact/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            return NotFound("Contact not found");
        }

        return Ok(contact);
    }

    // POST: api/contact
    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        contact.Id = nextId++;
        contacts.Add(contact);

        return Ok(contact);
    }

    // PUT: api/contact
    [HttpPut]
    public IActionResult Update(Contact contact)
    {
        var existing = contacts.FirstOrDefault(c => c.Id == contact.Id);

        if (existing == null)
        {
            return NotFound("Contact not found");
        }

        existing.Name = contact.Name;
        existing.Phone = contact.Phone;
        existing.Email = contact.Email;

        return Ok(existing);
    }

    // DELETE: api/contact/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            return NotFound("Contact not found");
        }

        contacts.Remove(contact);

        return Ok("Deleted successfully");
    }
}