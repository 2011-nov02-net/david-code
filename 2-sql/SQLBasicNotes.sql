-- SQL Comment

-- If nothing is highlighted, execute will run entire file
-- If something is highlighted, it'll run the highlighted stuff.

SELECT *
FROM Customer;

-- String (varchar) literal, single quotes
-- semicolons are not required
-- case insensitive (usually)


SELECT *
FROM Album JOIN Artist
ON Album.ArtistId = Artist.ArtistId;

-- can combine columns
SELECT firstName + ' ' + lastName
FROM Customer;

-- Column Aliases
SELECT firstName + ' ' + lastName AS FullName
FROM Customer;

SELECT firstName + ' ' + lastName AS "Full Name"
FROM Customer;

SELECT firstName + ' ' + lastName AS [Full Name]
FROM Customer;

-- WHERE STATEMENT

SELECT *
FROM Customer
WHERE LEN(FirstName) > 5;

SELECT *
FROM Customer
WHERE Country = 'Brazil';

-- operators - < <= = >= >
-- not-equals is either != or <>
-- Boolean Operators - AND OR NOT

-- every customer with first name starting with B
SELECT *
FROM Customer
WHERE FirstName >= 'B' and FirstName < 'C';

-- aggregate functions
-- SUM, MIN, MAX, AVG

SELECT COUNT(*)
FROM Customer;

SELECT SUM(Total) AS "INVOICE TOTALS"
FROM Invoice;

SELECT AVG(Total)
FROM Invoice;

-- Group By

-- Shows how much each customer bought
SELECT CustomerId, SUM(Total)
FROM Invoice
GROUP BY CustomerId;

-- how can i do filtering based on rows have been grouped

-- All CustomerId that have bought more than $40 worth
-- use having clause
SELECT CustomerId, SUM(Total)
FROM Invoice
GROUP BY CustomerId
HAVING SUM(Total) > 40;

-- Sorting with OrderBy
SELECT CustomerId, SUM(Total)
FROM Invoice
GROUP BY CustomerId
HAVING SUM(Total) > 40
ORDER BY SUM(Total) DESC;

SELECT CustomerId, SUM(Total)
FROM Invoice
WHERE BillingCountry != 'USA'
GROUP BY CustomerId
HAVING SUM(Total) > 40
ORDER BY SUM(Total) DESC;

-- Other options with select statment
-- SELECT DISTINCT (remove duplicate rows)
-- SELECT TOP(x) (top x of the list, discard after x) (Make sure to order)

-- logical order of execution

-- FROM
-- WHERE
-- GROUP BY
-- HAVING
-- SELECT
-- ORDER BY