using Microsoft.AspNetCore.Mvc;
using Core;
using ContactsManagerProject.Api.Messaging; // IMPORTANT

namespace ContactsManagerProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ContactCrudService _service;
    private readonly RabbitMqPublisher _publisher;

    public ContactController()
    {
        _service = new ContactCrudService();
        _publisher = new RabbitMqPublisher();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddRequest request)
    {
        bool result = await _service.AddAsync(
            request.FirstName,
            request.LastName,
            request.Phone,
            request.Email,
            request.Address,
            request.ContactType,
            request.DateOfBirth,
            request.RelationType,
            request.CustomRelation,
            request.IsVip
        );

        if (result)
        {
            // ✅ Publish to RabbitMQ AFTER successful DB insert
            await _publisher.PublishAsync(new
                {
                    Email = string.IsNullOrEmpty(request.Email)
                                ? "default@email.com"
                                : request.Email,
                    Name = request.FirstName
                });

            return Ok("Added and Message Published");
        }

        return BadRequest("Failed");
    }

    [HttpDelete("{phone}")]
    public async Task<IActionResult> Delete(string phone)
    {
        bool result = await _service.DeleteAsync(phone);
        return result ? Ok("Deleted") : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRequest request)
    {
        bool result = await _service.UpdateAsync(
            id,
            request.FirstName,
            request.LastName,
            request.Phone,
            request.Email,
            request.Address
        );

        return result ? Ok("Updated") : BadRequest("Failed");
    }
}

public class AddRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? ContactType { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? RelationType { get; set; }
    public string? CustomRelation { get; set; }
    public bool IsVip { get; set; }
}

public class UpdateRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}