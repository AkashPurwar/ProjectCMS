---- Drop tables
USE DB_CONTACTS
GO
DROP TABLE T_CONTACTS

-- Drop Database
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DB_CONTACTS'
GO
USE [master]
GO

DROP DATABASE [DB_CONTACTS]
GO
