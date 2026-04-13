using DeviceManagement.API.Models;

namespace DeviceManagement.API.Services;

public interface IAiService
{
    Task<string> GenerateDeviceDescriptionAsync(Device device);
}
