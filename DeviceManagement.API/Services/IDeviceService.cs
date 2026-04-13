using DeviceManagement.API.Models;

namespace DeviceManagement.API.Services;

public interface IDeviceService
{
    Task<IEnumerable<Device>> GetAllAsync();
    Task<Device?> GetByIdAsync(int id);
    Task<Device> CreateAsync(Device device);
    Task<Device?> UpdateAsync(int id, Device device);
    Task<bool> DeleteAsync(int id);
    Task<(bool Success, string Error)> AssignAsync(int deviceId, string userId);
    Task<(bool Success, string Error)> UnassignAsync(int deviceId, string userId);
}
