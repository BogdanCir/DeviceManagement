using System.Security.Claims;
using DeviceManagement.API.Models;
using DeviceManagement.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DevicesController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DevicesController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    // GET api/devices
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Device>>> GetAll()
    {
        var devices = await _deviceService.GetAllAsync();
        return Ok(devices);
    }

    // GET api/devices/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Device>> GetById(int id)
    {
        var device = await _deviceService.GetByIdAsync(id);
        if (device == null)
            return NotFound();

        return Ok(device);
    }

    // POST api/devices
    [HttpPost]
    public async Task<ActionResult<Device>> Create(Device device)
    {
        var created = await _deviceService.CreateAsync(device);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT api/devices/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Device>> Update(int id, Device device)
    {
        var updated = await _deviceService.UpdateAsync(id, device);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    // DELETE api/devices/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _deviceService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }

    // POST api/devices/5/assign
    [Authorize]
    [HttpPost("{id}/assign")]
    public async Task<IActionResult> Assign(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var (success, error) = await _deviceService.AssignAsync(id, userId);
        if (!success)
            return BadRequest(new { message = error });

        return Ok(new { message = "Device assigned successfully." });
    }

    // POST api/devices/5/unassign
    [Authorize]
    [HttpPost("{id}/unassign")]
    public async Task<IActionResult> Unassign(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var (success, error) = await _deviceService.UnassignAsync(id, userId);
        if (!success)
            return BadRequest(new { message = error });

        return Ok(new { message = "Device unassigned successfully." });
    }
}
