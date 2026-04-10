
USE DeviceManagementDb;
GO

-- Users table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE Users (
        Id          INT IDENTITY(1,1) PRIMARY KEY,
        Name        NVARCHAR(100) NOT NULL,
        Role        NVARCHAR(50)  NOT NULL,
        Location    NVARCHAR(100) NOT NULL
    );
    PRINT 'Table Users created successfully.';
END
ELSE
BEGIN
    PRINT 'Table Users already exists. Skipping creation.';
END
GO

-- Devices table
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Devices')
BEGIN
    CREATE TABLE Devices (
        Id              INT IDENTITY(1,1) PRIMARY KEY,
        Name            NVARCHAR(100) NOT NULL,
        Manufacturer    NVARCHAR(100) NOT NULL,
        Type            NVARCHAR(20)  NOT NULL,
        OperatingSystem NVARCHAR(50)  NOT NULL,
        OsVersion       NVARCHAR(30)  NOT NULL,
        Processor       NVARCHAR(100) NOT NULL,
        RamAmount       NVARCHAR(30)  NOT NULL,
        Description     NVARCHAR(500) NULL,
        UserId          INT NULL,

        CONSTRAINT FK_Devices_Users FOREIGN KEY (UserId)
            REFERENCES Users(Id)
            ON DELETE SET NULL
    );

    CREATE INDEX IX_Devices_UserId ON Devices(UserId);
    PRINT 'Table Devices created successfully.';
END
ELSE
BEGIN
    PRINT 'Table Devices already exists. Skipping creation.';
END
GO
