using DeviceManagement.API.Models;

namespace DeviceManagement.API.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Devices.Any())
            return;

        var devices = new List<Device>
        {
            new() { Name = "iPhone 15 Pro",    Manufacturer = "Apple",     Type = "phone",  OperatingSystem = "iOS",     OsVersion = "17.4",  Processor = "A17 Pro",            RamAmount = "8GB",  Description = "Flagship Apple smartphone for development testing." },
            new() { Name = "Galaxy S24 Ultra",  Manufacturer = "Samsung",   Type = "phone",  OperatingSystem = "Android", OsVersion = "14",    Processor = "Snapdragon 8 Gen 3", RamAmount = "12GB", Description = "High-end Samsung device for Android testing." },
            new() { Name = "iPad Pro 12.9\"",   Manufacturer = "Apple",     Type = "tablet", OperatingSystem = "iPadOS",  OsVersion = "17.4",  Processor = "M2",                 RamAmount = "16GB", Description = "Large tablet used for UI/UX design reviews." },
            new() { Name = "Pixel 8 Pro",       Manufacturer = "Google",    Type = "phone",  OperatingSystem = "Android", OsVersion = "14",    Processor = "Tensor G3",          RamAmount = "12GB", Description = "Google reference device for pure Android testing." },
            new() { Name = "Galaxy Tab S9",     Manufacturer = "Samsung",   Type = "tablet", OperatingSystem = "Android", OsVersion = "14",    Processor = "Snapdragon 8 Gen 2", RamAmount = "8GB",  Description = "Android tablet for cross-platform testing." },
            new() { Name = "iPhone 14",         Manufacturer = "Apple",     Type = "phone",  OperatingSystem = "iOS",     OsVersion = "17.3",  Processor = "A15 Bionic",         RamAmount = "6GB",  Description = "Older iPhone kept for backward compatibility tests." },
            new() { Name = "OnePlus 12",        Manufacturer = "OnePlus",   Type = "phone",  OperatingSystem = "Android", OsVersion = "14",    Processor = "Snapdragon 8 Gen 3", RamAmount = "16GB", Description = "High-performance Android device." },
            new() { Name = "iPad Air",          Manufacturer = "Apple",     Type = "tablet", OperatingSystem = "iPadOS",  OsVersion = "17.4",  Processor = "M1",                 RamAmount = "8GB",  Description = "Mid-range Apple tablet for general use." },
            new() { Name = "Xiaomi 14",         Manufacturer = "Xiaomi",    Type = "phone",  OperatingSystem = "Android", OsVersion = "14",    Processor = "Snapdragon 8 Gen 3", RamAmount = "12GB", Description = "Budget-friendly flagship for international testing." },
            new() { Name = "Surface Duo 2",     Manufacturer = "Microsoft", Type = "phone",  OperatingSystem = "Android", OsVersion = "12L",   Processor = "Snapdragon 888",     RamAmount = "8GB",  Description = "Dual-screen foldable device for special UI testing." }
        };

        context.Devices.AddRange(devices);
        context.SaveChanges();
    }
}
