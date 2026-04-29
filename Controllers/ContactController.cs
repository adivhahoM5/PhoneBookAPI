using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Data;
using PhoneBookAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly FirstAPIContex _contex;

    public ContactController(FirstAPIContex contex)
    {
        _contex = contex;
    }

    [HttpGet]
    public async Task<ActionResult<List<Contact>>> GetContact()
    {
        return Ok(await _contex.contacts.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContactByID(int id)
    {
        var contact = await _contex.contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        return Ok(contact);
    }

    [HttpPost]
    public async Task<ActionResult<List<Contact>>> AddContact([FromBody] Contact newContact)
    {
        if (newContact == null)
            return BadRequest();

        _contex.contacts.Add(newContact);
        await _contex.SaveChangesAsync();

        return Ok(await _contex.contacts.ToListAsync());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, [FromBody] Contact updatedContact)
    {
        var contact = await _contex.contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        contact.Name = updatedContact.Name;
        contact.Phone = updatedContact.Phone;
        contact.Email = updatedContact.Email;

        await _contex.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteContact(int id)
    {
        var contact = await _contex.contacts.FindAsync(id);

        if (contact == null)
            return NotFound();

        _contex.contacts.Remove(contact);
        await _contex.SaveChangesAsync();

        return NoContent();
    }
}