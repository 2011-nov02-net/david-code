SELECT *
FROM Customer
ORDER BY FirstName;

SELECT *
FROM Track;


-- 1. insert two new records into the employee table.

INSERT INTO Customer VALUES (60, 'David', 'Barnes', NULL, NULL, NULL, NULL, 'USA', NULL, NULL, NULL, 'test@test.com',  5);
INSERT INTO Customer VALUES (61, 'Arnold', 'Palmer', 'Golfing International', NULL, NULL, NULL, 'USA', NULL, NULL, NULL, 'test@test.com',  5);

-- 2. insert two new records into the tracks table.

INSERT INTO Track VALUES (3504, 'We Will Rock You', 1, 3, 18, NULL, 600400, 5555555, 4.99);
INSERT INTO Track VALUES (3505, 'Queen, The Musical', 1, 3, 18, NULL, 60040000, 5555555, 10.99);

-- 3. update customer Aaron Mitchell's name to Robert Walter
UPDATE Customer
SET FirstName = 'Robert', LastName = 'Walter'
WHERE CustomerID = (
	SELECT CustomerId
	FROM Customer
	WHERE FirstName = 'Aaron' AND LastName = 'Mitchell');

-- 4. delete one of the employees you inserted.
DELETE FROM Customer
WHERE CustomerId = 60;

-- 5. delete customer Robert Walter.

DELETE FROM Customer
WHERE FirstName = 'Arnold' AND LastName = 'Palmer';