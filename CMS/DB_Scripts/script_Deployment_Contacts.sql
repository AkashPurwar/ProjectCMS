-- Create Database
CREATE DATABASE DB_CONTACTS
GO
-- Create Table
USE DB_CONTACTS
GO
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'T_CONTACTS')
DROP TABLE T_CONTACTS

CREATE TABLE T_CONTACTS
(
	contact_id INT PRIMARY KEY IDENTITY,
	first_name NVARCHAR(15) NOT NULL,
	last_name  NVARCHAR(15) NULL,
	email	   NVARCHAR(30) NOT NULL,
	phone		BIGINT,
	status		NVARCHAR(10) DEFAULT 'ACTIVE',
	CONSTRAINT UNQ_EMAIL UNIQUE (email),
	CONSTRAINT CHK_STATUS CHECK(status IN ('ACTIVE','INACTIVE'))
)

CREATE NONCLUSTERED INDEX IX_CONTACT_EMAIL ON T_CONTACTS(email)
GO

-- Insert Sample Data
INSERT INTO T_CONTACTS (first_name,last_name,email,phone) VALUES ('Akash','Purwar','apurwar23@gmail.com',9638332731)
