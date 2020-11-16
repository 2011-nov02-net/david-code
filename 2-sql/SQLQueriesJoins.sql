-- 1. show all invoices of customers from brazil (mailing address not billing)
SELECT Invoice.InvoiceId, Invoice.CustomerId, Invoice.InvoiceDate
FROM Invoice INNER JOIN Customer ON Invoice.CustomerId = Customer.CustomerId
WHERE Customer.Country = 'Brazil';

SELECT *
FROM Invoice;

-- 2. show all invoices together with the name of the sales agent of each one
SELECT *
FROM Invoice;

SELECT *
FROM Employee;

SELECT *
FROM CUSTOMER;

SELECT Invoice.*, Employee.FirstName, Employee.LastName 
FROM (Invoice 
	INNER JOIN Customer On Invoice.CustomerId = Customer.CustomerId) 
	LEFT JOIN Employee ON Customer.SupportRepId = Employee.EmployeeId;

-- 3. show all playlists ordered by the total number of tracks they have

SELECT *
FROM Playlist;

SELECT *
FROM PlaylistTrack;

SELECT PlaylistTrack.PlaylistId, Playlist.Name, COUNT(PlaylistTrack.PlaylistId) AS "Number of Tracks"
FROM Playlist INNER JOIN PlaylistTrack ON Playlist.PlaylistId = PlaylistTrack.PlaylistId
GROUP BY PlaylistTrack.PlaylistId, Playlist.Name
ORDER BY [Number of Tracks] DESC;

-- 4. which sales agent made the most in sales in 2009?

SELECT *
FROM EMPLOYEE;

SELECT TOP(1) SUM(Total), YEAR(Invoice.InvoiceDate), E.EmployeeId
FROM (Invoice INNER JOIN Customer On Invoice.CustomerId = Customer.CustomerId) INNER JOIN Employee AS E ON Customer.SupportRepId = E.EmployeeId
WHERE YEAR(Invoice.InvoiceDate) = '2009'
GROUP BY E.EmployeeId, YEAR(Invoice.InvoiceDate)
ORDER BY E.EmployeeId DESC;

-- 5. how many customers are assigned to each sales agent?

SELECT *
FROM Employee;

SELECT *
FROM Customer;

SELECT e.EmployeeId, COUNT(e.EmployeeId) AS "Number of Customers"
FROM Employee AS e JOIN Customer AS c On e.EmployeeId = c.SupportRepId
GROUP BY e.EmployeeId;

-- 6. which track was purchased the most since 2010?
SELECT *
FROM InvoiceLine;

SELECT *
FROM Invoice;

SELECT *
FROM Track;

SELECT *
FROM Album;

SELECT *
FROM Artist;

SELECT TOP(1) t.Name, t.TrackId, COUNT(t.TrackId) AS "Sales Since 2010"
FROM (Invoice AS i JOIN InvoiceLine AS il ON i.InvoiceId = il.InvoiceId) JOIN Track AS t ON il.TrackId = t.TrackId
WHERE YEAR(i.InvoiceDate) >= '2010'
GROUP BY t.Name, t.TrackId
ORDER BY [Sales Since 2010] DESC;

SELECT *
FROM InvoiceLine AS il  LEFT JOIN Track AS t ON il.TrackId = t.TrackId
WHERE t.Name = 'Eruption'

-- 7. show the top three best-selling artists.

SELECT TOP(3) ar.Name, COUNT(ar.Name) AS "Total Tracks Sold"
FROM ((InvoiceLine AS il JOIN Track AS t ON il.TrackId = t.TrackId) JOIN Album AS al ON t.AlbumId = al.AlbumId) JOIN Artist AS ar ON al.ArtistId = ar.ArtistId
GROUP BY ar.Name
ORDER BY [Total Tracks Sold] DESC;


-- 8. which customers have the same initials as at least one other customer?


-- Using Set Intersection
SELECT SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1) FROM Customer
INTERSECT
SELECT SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1) FROM Customer;


-- Random Stuff
SELECT * FROM Track WHERE TrackId NOT IN (
    SELECT TrackId FROM InvoiceLine
);

SELECT Track.*
FROM Track LEFT JOIN InvoiceLine ON Track.TrackId = InvoiceLine.TrackId
WHERE InvoiceLine.InvoiceLineId IS NULL;

SELECT * FROM Track;

SELECT *
FROM Artist
WHERE ArtistId NOT IN ( -- all the artists who wrote such an album
	SELECT ArtistId FROM Album WHERE AlbumId IN ( -- all the albums with a latin song
		SELECT AlbumId
		FROM Track           -- all the genres named latin
		WHERE GenreId IN (SELECT GenreId FROM Genre WHERE Name = 'Latin')
	)
);

