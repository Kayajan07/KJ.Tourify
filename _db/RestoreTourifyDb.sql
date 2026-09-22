USE master;
GO

DECLARE @bak nvarchar(4000) =
    N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\TourifyDb.bak';

DECLARE @sql nvarchar(max) =
    N'RESTORE FILELISTONLY FROM DISK = N''' + @bak + N'''';
EXEC sp_executesql @sql;
GO


IF DB_ID('TourifyDb') IS NOT NULL
    ALTER DATABASE [TourifyDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO


DECLARE @bak nvarchar(4000) =
    N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\TourifyDb.bak';
DECLARE @dataDir nvarchar(4000) =
    CAST(SERVERPROPERTY('InstanceDefaultDataPath') AS nvarchar(4000));
DECLARE @logDir  nvarchar(4000) =
    CAST(SERVERPROPERTY('InstanceDefaultLogPath')  AS nvarchar(4000));

DECLARE @sql nvarchar(max) = N'
RESTORE DATABASE [TourifyDb]
FROM DISK = N''' + @bak + N'''
WITH
    MOVE N''TourifyDb''     TO N''' + @dataDir + N'TourifyDb.mdf'',
    MOVE N''TourifyDb_log'' TO N''' + @logDir  + N'TourifyDb_log.ldf'',
    REPLACE,
    RECOVERY,
    STATS = 5;';

PRINT @sql;   -- calisan komutu Messages sekmesinde gorursun
EXEC sp_executesql @sql;
GO


ALTER DATABASE [TourifyDb] SET MULTI_USER;
GO
ALTER AUTHORIZATION ON DATABASE::[TourifyDb] TO [sa];
GO


USE [TourifyDb];
GO
SELECT name AS TabloAdi FROM sys.tables ORDER BY name;
GO
SELECT * FROM dbo.Users;
GO
