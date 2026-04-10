using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.API.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Role { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = string.Empty;

    // Navigation: devices assigned to this user
    public ICollection<Device> Devices { get; set; } = new List<Device>();
}
