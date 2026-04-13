using DeviceManagement.API.Data;
using DeviceManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.API.Services;

public class DeviceService : IDeviceService
{
    private readonly AppDbContext _context;

    public DeviceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _context.Devices
            .Include(d => d.AssignedToUser)
            .ToListAsync();
    }

    public async Task<Device?> GetByIdAsync(int id)
    {
        return await _context.Devices
            .Include(d => d.AssignedToUser)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Device> CreateAsync(Device device)
    {
        _context.Devices.Add(device);
        await _context.SaveChangesAsync();
        return device;
    }

    public async Task<Device?> UpdateAsync(int id, Device device)
    {
        var existing = await _context.Devices.FindAsync(id);
        if (existing == null)
            return null;

        existing.Name = device.Name;
        existing.Manufacturer = device.Manufacturer;
        existing.Type = device.Type;
        existing.OperatingSystem = device.OperatingSystem;
        existing.OsVersion = device.OsVersion;
        existing.Processor = device.Processor;
        existing.RamAmount = device.RamAmount;
        existing.Description = device.Description;
        existing.AssignedToUserId = device.AssignedToUserId;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var device = await _context.Devices.FindAsync(id);
        if (device == null)
            return false;

        _context.Devices.Remove(device);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<(bool Success, string Error)> AssignAsync(int deviceId, string userId)
    {
        var device = await _context.Devices.FindAsync(deviceId);
        if (device == null)
            return (false, "Device not found.");

        if (device.AssignedToUserId != null)
            return (false, "Device is already assigned to another user.");

        device.AssignedToUserId = userId;
        await _context.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error)> UnassignAsync(int deviceId, string userId)
    {
        var device = await _context.Devices.FindAsync(deviceId);
        if (device == null)
            return (false, "Device not found.");

        if (device.AssignedToUserId != userId)
            return (false, "You can only unassign devices assigned to you.");

        device.AssignedToUserId = null;
        await _context.SaveChangesAsync();
        return (true, string.Empty);
    }
}
