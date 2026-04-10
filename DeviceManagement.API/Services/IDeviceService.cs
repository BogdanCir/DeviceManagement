using DeviceManagement.API.Models;

namespace DeviceManagement.API.Services;

public interface IDeviceService
{
    Task<IEnumerable<Device>> GetAllAsync();
    Task<Device?> GetByIdAsync(int id);
    Task<Device> CreateAsync(Device device);
    Task<Device?> UpdateAsync(int id, Device device);
    Task<bool> DeleteAsync(int id);
}
