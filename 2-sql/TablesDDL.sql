-- DDL
-- CREATE, ALTER, DROP

-- Create new database (Not reccomended with cloud, since we cannot control size)
-- CREATE DATABASE Chinook2;

-- SQL DBs have basically "namespace" for tables and other objects.
-- called schema

CREATE SCHEMA School;
GO -- 
-- in SQL Server, "dbo" is the default schema, the one that is assumes if you don't give one

-- tables for managing school/student/course/teacher
CREATE TABLE School.Course (
	Id NVARCHAR(30) NOT NULL PRIMARY KEY,
	Name NVARCHAR(150) NOT NULL,
	TeacherID INT NULL, -- good practice to write null to be explicit
	StartDate DATE NOT NULL DEFAULT GETDATE(),
	EndDate DATE NOT NULL,
	CHECK (EndDate > StartDate)
);

DROP TABLE School.Course;

SELECT * FROM School.Course;

-- Constraints in SQL Server
--	Any column by default can contain NULL
--		You can restrict this with "NOT NULL"

--	UNIQUE 
--		Prevent duplicate values in that column
--		Good for candidate keys
--		Can be applied to sets of columns
--		Good for representing 1-to-1 relationships to FK.

--	PRIMARY KEY
--		Set the primary key for the table
--		Automatically implies UNIQUE and NOT NULL
--		But we'd usally write NOT NULL anywasy just to be explicit.

--	CHECK
--		Put any expression in parens after this
--		and the expression needs to be true for every row

--	DEFAULT
--		Sets a default value if an INSERT is done without one.
--		Doesn't have to be constant, is evaluated at insert time.

--	FOREIGN KEY
--	

--	IDENTITY(START,OFFSET)
--		Sets an Auto-Incrementing default number
--		(default (1,1)) this constraint prevents manually inserting any value

ALTER TABLE School.Course
	DROP CONSTRAINT FK_Course_TeacherID

DROP TABLE School.Teacher;

CREATE TABLE School.Teacher(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL CHECK (LEN(Name) > 0)
);	

-- Add FK to Course
ALTER TABLE School.Course
	ADD CONSTRAINT FK_Course_TeacherID FOREIGN KEY (TeacherId)
	REFERENCES School.Teacher (Id);

INSERT INTO School.Teacher(Name) VALUES ('Steve');

SELECT * FROM School.Teacher;

INSERT INTO School.Course (Id, Name, TeacherId, EndDate) VALUES
	('CS-101', 'Intro To C#', (SELECT Id FROM School.Teacher WHERE name = 'Adam'), '2021-01-01');


--	Multiplicity of a relationship between data/entities
--		1-to-1 (one-to-one)
--			in SQL: Put the data for both entities in the same table/row
--				or put it in a separate table and have a UNIQUE FOREIGN KEY of one of them.
--			0or1-to-1 (possibly have a null value)

--		1-to-n (one-to-many)
--			in SQL: two tables, with a FK on the "Many" side.

--		n-to-n (many-to-many)
--			in SQL: "SQL doesn't support many-to-many relationship"
--				we can simulate it with two 1-to-many relationship
--				introduce a new table, give it two FK to the two preexisting tables
--				We call this "Join Table" or "Junction Table"

CREATE TABLE School.Student(
	Id Int NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(150) NOT NULL
);

DROP TABLE School.CourseStudent;

CREATE TABLE School.CourseStudent( --Enrollment
	CourseId NVARCHAR(30) FOREIGN KEY REFERENCES School.Course (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	StudentId INT FOREIGN KEY REFERENCES School.Student (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY (CourseId, StudentId)
);

INSERT INTO School.Student (Name) Values
	('David'), ('Nick'), ('Fred');

INSERT INTO School.CourseStudent (CourseId, StudentId) VALUES
	('CS-101',(SELECT Id FROM School.Student WHERE Name = 'Nick'));
INSERT INTO School.CourseStudent (CourseId, StudentId) VALUES
	('CS-101',(SELECT Id FROM School.Student WHERE Name = 'Fred'));

DELETE FROM School.Student WHERE Name = 'Nick';

SELECT * FROM School.Student;
SELECT * FROM School.CourseStudent;

-- FK can be created with ON DELETE and ON UPDATE behaviors
--		To control what happens

--	Indexes
--		data structures that we can have SQL Server maintain during writes
--		so that reads can be faster.

--		in SQL Server:
--			Clustered index
--				tells SQL Server what order to 'physically' arrange the table in.
--				can only be one
--				by default, PRIMARY KEY sets CLUSTERED INDEX.
--			Nonclustered index
--				maintains a separate data structure analogous to an index at the end of an enyclopedia
--				we can have many of these.
--				UNIQUE sets notclustered index by default
--		you want indexes onf the columns/sets of columns that you usally refence in the JOIN or WHERE conditions (FOREIGN KEYs are good candidate)