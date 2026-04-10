
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DeviceManagementDb')
BEGIN
    CREATE DATABASE DeviceManagementDb;
    PRINT 'Database DeviceManagementDb created successfully.';
END
ELSE
BEGIN
    PRINT 'Database DeviceManagementDb already exists. Skipping creation.';
END
GO
