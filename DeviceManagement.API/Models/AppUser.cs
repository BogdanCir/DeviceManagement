using Microsoft.AspNetCore.Identity;

namespace DeviceManagement.API.Models;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
}
