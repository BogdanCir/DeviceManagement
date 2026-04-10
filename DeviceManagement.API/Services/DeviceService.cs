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
            .Include(d => d.User)
            .ToListAsync();
    }

    public async Task<Device?> GetByIdAsync(int id)
    {
        return await _context.Devices
            .Include(d => d.User)
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
        existing.UserId = device.UserId;

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
}
