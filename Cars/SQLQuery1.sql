CREATE DATABASE CarsAndManufactures;
GO
USE CarsAndManufactures
GO
CREATE TABLE Manufactures (
Id INT IDENTITY PRIMARY KEY,
Company NVARCHAR(20) NOT NULL,
Country NVARCHAR(20) NOT NULL,
);
GO
CREATE TABLE Cars (
Id INT IDENTITY PRIMARY KEY,
Model NVARCHAR(20) NOT NULL,
VIN NVARCHAR(17) NOT NULL,
Horsepower NVARCHAR(20) NOT NULL,
Type NVARCHAR(20) NOT NULL,
MakeId INT FOREIGN KEY REFERENCES Manufactures(Id)
);
GO



-- Scaffold-DbContext 'Data Source=TROYSPC;Initial Catalog=CarsAndManufactures; Integrated Security=SSPI;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models