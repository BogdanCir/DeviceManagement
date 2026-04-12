using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.API.Models;

public class Device
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Type { get; set; } = string.Empty; // "phone" or "tablet"

    [Required]
    [MaxLength(50)]
    public string OperatingSystem { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string OsVersion { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Processor { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string RamAmount { get; set; } = string.Empty; // e.g. "8GB"

    [MaxLength(500)]
    public string? Description { get; set; }

    // Navigation: which user currently has this device
    public string? AssignedToUserId { get; set; }
    public AppUser? AssignedToUser { get; set; }
}
