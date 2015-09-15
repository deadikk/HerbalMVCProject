IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'IIS APPPOOL\herb')
BEGIN
      CREATE LOGIN [IIS APPPOOL\herb] 
      FROM WINDOWS WITH DEFAULT_DATABASE=[herbalDB], 
      DEFAULT_LANGUAGE=[us_english]
END
GO
CREATE USER [defaultUser] 
  FOR LOGIN [IIS APPPOOL\herb]
GO
EXEC sp_addrolemember 'db_owner', 'defaultUser'
GO