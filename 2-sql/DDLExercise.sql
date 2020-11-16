CREATE SCHEMA Company;
GO

--DROP TABLE Company.Department;
CREATE TABLE Company.Department(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	Location NVARCHAR(150) NOT NULL
);

--DROP TABLE Company.Employee;
CREATE TABLE Company.Employee(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	SSN NVARCHAR(11) NOT NULL, --using NVARCHAR here for flexibility to contain dashes ie XXX-XX-XXXX 
	DeptID INT NOT NULL,
	CONSTRAINT FK_Emp_DeptId FOREIGN KEY (DeptID) REFERENCES Company.Department(Id) ON UPDATE CASCADE
);

--DROP TABLE Company.EmpDetails;
CREATE TABLE Company.EmpDetails(
	Id NVARCHAR(30) NOT NULL,
	EmployeeId INT NOT NULL,
	Salary Money NOT NULL,
	Address1 NVARCHAR(150) NOT NULL,
	Address2 NVARCHAR(150) NULL,
	City NVARCHAR(150) NOT NULL,
	State NVARCHAR(2) NOT NULL, --using state abbreviations here such as VA, TX, WV
	Country NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Id_EmployeeID PRIMARY KEY (Id, EmployeeId),
	CONSTRAINT FK_EmployeeID_ID FOREIGN KEY (EmployeeId) REFERENCES Company.Employee(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

SELECT * FROM Company.Department;
SELECT * FROM Company.Employee;
SELECT * FROM Company.EmpDetails;

INSERT INTO Company.Department (Name, Location) VALUES
	('MARKETING', 'Dallas'), ('HR', 'Richmond'), ('IT', 'At Home');

INSERT INTO Company.Employee (FirstName, LastName, SSN, DeptID) VALUES
	('David', 'Barnes', '111-11-1111', (SELECT Id FROM Company.Department WHERE Name = 'Marketing')),
	('John', 'Smith', '111-11-1112', (SELECT Id FROM Company.Department WHERE Name = 'HR')),
	('Jane', 'Doe', '11111113', (SELECT Id FROM Company.Department WHERE Name = 'IT'));

--INSERT INTO Company.EmpDetails (