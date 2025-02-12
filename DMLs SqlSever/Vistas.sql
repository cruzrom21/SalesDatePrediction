CREATE VIEW [Sales].[GetShippers] AS
SELECT 
	Shipperid
	, Companyname
FROM Sales.Shippers

GO

CREATE VIEW [Sales].[GetSalesDatePrediction]
AS
SELECT        a.custid AS custid,  c.companyname AS CustomerName, a.LastOrderDate, DATEADD(DAY, a.AvgDaysOrders, a.LastOrderDate) AS NextPredictedOrder
FROM            (SELECT        o.custid, MAX(o.orderdate) AS LastOrderDate, AVG(DATEDIFF(DAY, prev_orders.BeforeOrderDate, o.orderdate)) AS AvgDaysOrders
                          FROM            Sales.Orders o JOIN
                                                        (SELECT        custid, orderdate, LAG(orderdate) OVER (PARTITION BY custid
                                                          ORDER BY orderdate) AS BeforeOrderDate
                          FROM            Sales.Orders) AS prev_orders ON o.custid = prev_orders.custid AND o.orderdate = prev_orders.orderdate
WHERE        prev_orders.BeforeOrderDate IS NOT NULL
GROUP BY o.custid) a JOIN
Sales.Customers c ON a.custid = c.custid;

GO

CREATE VIEW [Sales].[GetClientOrders]
AS
SELECT        orderid, custid, requireddate, shippeddate, shipname, shipaddress, shipcity
FROM            Sales.Orders

GO

CREATE VIEW [Production].[GetProducts] AS
SELECT productid, productname
FROM Production.Products

GO

CREATE VIEW [HR].[GetEmployees] AS
SELECT 
	Empid,
	CONCAT(firstname, ' ',  lastname) AS FullName
FROM HR.Employees;

GO
