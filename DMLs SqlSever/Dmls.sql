CREATE PROCEDURE GetSalesDatePrediction AS BEGIN WITH BeforeOrderDate AS (
    SELECT
        custid,
        orderdate,
        LAG(orderdate) OVER (
            PARTITION BY custid
            ORDER BY
                orderdate
        ) AS BeforeOrderDate
    FROM
        Sales.Orders
),
AvgDays AS (
    SELECT
        custid,
        MAX(orderdate) AS LastOrderDate,
        AVG(DATEDIFF(DAY, BeforeOrderDate, orderdate)) AS AvgDaysOrders
    FROM
        BeforeOrderDate
    WHERE
        BeforeOrderDate IS NOT NULL
    GROUP BY
        custid
)
SELECT
    a.custid,
    companyname AS CutomerName,
    LastOrderDate,
    DATEADD(DAY, a.AvgDaysOrders, a.LastOrderDate) AS NextPredictedOrder
FROM
    AvgDays a
    JOIN Sales.Customers c ON a.custid = c.custid
END;

CREATE PROCEDURE GetClientOrders @custid INT AS BEGIN
SELECT
    Orderid,
    Requireddate,
    Shippeddate,
    Shipname,
    Shipaddress,
    Shipcity
FROM
    Sales.Orders
WHERE
    custid = @custid;

END;

CREATE PROCEDURE GetEmployees AS BEGIN
SELECT
    Empid,
    CONCAT(firstname, ' ', lastname) AS FullName
FROM
    HR.Employees;

END;

CREATE PROCEDURE GetShippers AS BEGIN
SELECT
    Shipperid,
    Companyname
FROM
    Sales.Shippers
END;

CREATE PROCEDURE GetProducts AS BEGIN
SELECT
    Productid,
    Productname
FROM
    Production.Products
END;

CREATE PROCEDURE AddNewOrder @custid INT,
@empid INT,
@orderdate DATETIME,
@requireddate DATETIME,
@shippeddate DATETIME = NULL,
@shipperid INT,
@freight MONEY,
@shipname NVARCHAR(40),
@shipaddress NVARCHAR(60),
@shipcity NVARCHAR(15),
@shipregion NVARCHAR(15) = NULL,
@shippostalcode NVARCHAR(10) = NULL,
@shipcountry NVARCHAR(15),
@productid INT,
@unitprice MONEY,
@qty SMALLINT,
@discount NUMERIC(4, 3) AS BEGIN
SET
    NOCOUNT ON;

DECLARE @NewOrderID INT;


INSERT INTO
    Sales.Orders (
        custid,
        empid,
        orderdate,
        requireddate,
        shippeddate,
        shipperid,
        freight,
        shipname,
        shipaddress,
        shipcity,
        shipregion,
        shippostalcode,
        shipcountry
    )
VALUES
    (
        @custid,
        @empid,
        @orderdate,
        @requireddate,
        @shippeddate,
        @shipperid,
        @freight,
        @shipname,
        @shipaddress,
        @shipcity,
        @shipregion,
        @shippostalcode,
        @shipcountry
    );


SET
    @NewOrderID = SCOPE_IDENTITY();


INSERT INTO
    Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
VALUES
    (
        @NewOrderID,
        @productid,
        @unitprice,
        @qty,
        @discount
    );

SELECT
    @NewOrderID AS OrderID;

END;