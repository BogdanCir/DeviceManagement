USE DeviceManagementDb;
GO

-- Seed Users (only if table is empty)
IF NOT EXISTS (SELECT 1 FROM Users)
BEGIN
    SET IDENTITY_INSERT Users ON;

    INSERT INTO Users (Id, Name, Role, Location) VALUES
        (1, 'Alice Johnson',    'Software Engineer',    'New York'),
        (2, 'Bob Smith',        'QA Analyst',           'London'),
        (3, 'Carol Williams',   'Project Manager',      'Berlin'),
        (4, 'David Brown',      'DevOps Engineer',      'Toronto'),
        (5, 'Eva Martinez',     'UX Designer',          'Barcelona');

    SET IDENTITY_INSERT Users OFF;
    PRINT 'Users seeded successfully (5 rows).';
END
ELSE
BEGIN
    PRINT 'Users table already has data. Skipping seed.';
END
GO

-- Seed Devices (only if table is empty)
IF NOT EXISTS (SELECT 1 FROM Devices)
BEGIN
    SET IDENTITY_INSERT Devices ON;

    INSERT INTO Devices (Id, Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, UserId) VALUES
        (1,  'iPhone 15 Pro',       'Apple',    'phone',    'iOS',      '17.4',     'A17 Pro',              '8GB',  'Flagship Apple smartphone for development testing.',   1),
        (2,  'Galaxy S24 Ultra',    'Samsung',  'phone',    'Android',  '14',       'Snapdragon 8 Gen 3',  '12GB', 'High-end Samsung device for Android testing.',         2),
        (3,  'iPad Pro 12.9"',      'Apple',    'tablet',   'iPadOS',   '17.4',     'M2',                  '16GB', 'Large tablet used for UI/UX design reviews.',          5),
        (4,  'Pixel 8 Pro',         'Google',   'phone',    'Android',  '14',       'Tensor G3',           '12GB', 'Google reference device for pure Android testing.',     NULL),
        (5,  'Galaxy Tab S9',       'Samsung',  'tablet',   'Android',  '14',       'Snapdragon 8 Gen 2',  '8GB',  'Android tablet for cross-platform testing.',           3),
        (6,  'iPhone 14',           'Apple',    'phone',    'iOS',      '17.3',     'A15 Bionic',          '6GB',  'Older iPhone kept for backward compatibility tests.',   NULL),
        (7,  'OnePlus 12',          'OnePlus',  'phone',    'Android',  '14',       'Snapdragon 8 Gen 3',  '16GB', 'High-performance Android device.',                     4),
        (8,  'iPad Air',            'Apple',    'tablet',   'iPadOS',   '17.4',     'M1',                  '8GB',  'Mid-range Apple tablet for general use.',               NULL),
        (9,  'Xiaomi 14',           'Xiaomi',   'phone',    'Android',  '14',       'Snapdragon 8 Gen 3',  '12GB', 'Budget-friendly flagship for international testing.',   2),
        (10, 'Surface Duo 2',      'Microsoft','phone',    'Android',  '12L',      'Snapdragon 888',      '8GB',  'Dual-screen foldable device for special UI testing.',   NULL);

    SET IDENTITY_INSERT Devices OFF;
    PRINT 'Devices seeded successfully (10 rows).';
END
ELSE
BEGIN
    PRINT 'Devices table already has data. Skipping seed.';
END
GO
