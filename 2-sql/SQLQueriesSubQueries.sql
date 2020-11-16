-- 1. which artists did not make any albums at all?
SELECT *
FROM Album;

SELECT *
FROM Artist;

SELECT ar.Name
FROM Artist AS ar LEFT JOIN Album AS al ON ar.ArtistId = al.ArtistId
WHERE al.AlbumId IS NULL;

SELECT *
FROM Artist AS ar
WHERE ar.ArtistId NOT IN(
	SELECT ArtistId
	FROM Album)

-- 2. which artists did not record any tracks of the Latin genre?

-- 3. which video track has the longest length? (use media type table)

SELECT *
FROM MediaType;

SELECT *
FROM Track;

SELECT TOP(1) *
FROM Track AS t
WHERE MediaTypeId = 3
ORDER BY Milliseconds DESC;

SELECT TOP(1) *
FROM Track t
WHERE MediaTypeId IN (
	SELECT MediaTypeId
	FROM MediaType
	WHERE MediaTypeId = 3)
ORDER BY Milliseconds DESC;

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

SELECT City
FROM Employee
WHERE ReportsTo is NULL;

SELECT *
FROM Customer
WHERE City IN (
	SELECT City
	FROM Employee
	WHERE ReportsTo is NULL
);

SELECT c.*
FROM Customer AS c JOIN Employee AS e ON c.City = e.City
WHERE e.ReportsTo is NULL;



-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?
SELECT *
FROM (Invoice AS i INNER JOIN Customer AS c ON i.CustomerId = c.CustomerId)
WHERE c.Country = 'Germany';

SELECT SUM(il.UnitPrice * il.Quantity) AS TotalPricePaid
FROM Track AS t
	INNER JOIN MediaType AS mt ON mt.Name LIKE '%audio%' AND mt.MediaTypeId = t.MediaTypeId
	INNER JOIN InvoiceLine AS il ON il.TrackId = t.TrackId
	INNER JOIN Invoice AS i ON i.InvoiceId = il.InvoiceId
	INNER JOIN Customer AS c ON c.CustomerId = i.CustomerId
WHERE c.Country = 'Germany'
GROUP BY t.trackId

SELECT CustomerId
FROM Customer
WHERE Country = 'Germany';

SELECT COUNT(Invoiceid), SUM(Total)
FROM Invoice
WHERE CustomerId IN (
	SELECT CustomerId
	FROM Customer
	WHERE Country = 'Germany'
);

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.