select * from Customers
select * from Suppliers
select * from Orders
select * from Shippers
select * from [Order Details]
select * from Categories
select * from Employees
select * from Products

--1)  For each order, calculate a subtotal for each Order (identified by OrderID).
select orderid,sum((UnitPrice*Quantity) - ((UnitPrice*Quantity) * discount)) 'total bill' from [Order Details] group by OrderID

--2) get the year part from Shipped_Date column.
select year(ShippedDate) 'Year of shipped' from Orders group by year(ShippedDate)

--3) For each employee, get their sales amount, broken down by country name.
select concat(LastName,'',FirstName) 'employee name',e.Country, count(orderid) 'total sales'from Employees e join Orders o on e.EmployeeID=o.EmployeeID
group by e.Country, concat(LastName,'',FirstName)

--4) What does this query do?
select distinct b.*, a.CategoryName
from Categories a 
inner join Products b on a.CategoryID = b.CategoryID
where b.Discontinued = '0'
order by b.ProductName, a.CategoryName;

-------It will give all the distinct product details and category name where discontinued is false value or '0' value, 
-------it will be ordered by ProductName and CategoryName alphabet wise

--5) What is the diff between the query a and b
a) select distinct a.CategoryID, 
    a.CategoryName,  
    b.ProductName, 
    sum(round(y.UnitPrice * y.Quantity * (1 - y.Discount), 2)) as ProductSales
from [Order Details] y
inner join Orders d on d.OrderID = y.OrderID
inner join Products b on b.ProductID = y.ProductID
inner join Categories a on a.CategoryID = b.CategoryID
where d.OrderDate between date('1997-1-1') and date('1997-12-31')
group by a.CategoryID, a.CategoryName, b.ProductName
order by a.CategoryName, b.ProductName, ProductSales;

b)     a.CategoryName, 
    b.ProductName, 
    sum(c.ExtendedPrice) as ProductSales
from Categories a 
inner join Products b on a.CategoryID = b.CategoryID
inner join 
(
    select distinct y.OrderID, 
        y.ProductID, 
        x.ProductName, 
        y.UnitPrice, 
        y.Quantity, 
        y.Discount, 
        round(y.UnitPrice * y.Quantity * (1 - y.Discount), 2) as ExtendedPrice
    from Products x
    inner join [Order Details] y on x.ProductID = y.ProductID
    order by y.OrderID
) c on c.ProductID = b.ProductID
inner join Orders d on d.OrderID = c.OrderID
where d.OrderDate between date('1997/1/1') and date('1997/12/31')
group by a.CategoryID, a.CategoryName, b.ProductName
order by a.CategoryName, b.ProductName, ProductSales;

--both the queries give the values of orderid, productid, productname, unitprice, quantity and discount , the first query uses a inner join function 
--second query uses the queries inside query and inner join seperately for every inner query
--it will display only the orders between 1997/1/1 and 1997/12/31

--Unions
The UNION operator is used to combine the result-set of two or more SELECT statements.

Every SELECT statement within UNION must have the same number of columns
The columns must also have similar data types
The columns in every SELECT statement must also be in the same order
SELECT City FROM Customers
UNION
SELECT City FROM Suppliers
ORDER BY City;

--Soundex
SOUNDEX converts an alphanumeric string to a four-character code that is based on how the string sounds when 
spoken in English. The first character of the code is the first character of character_expression, converted to 
upper case. The second through fourth characters of the code are numbers that represent the letters in the expression.
The letters A, E, I, O, U, H, W, and Y are ignored unless they are the first letter of the string. Zeroes are added at
the end if necessary to produce a four-character code.

SELECT SOUNDEX('ammu'), SOUNDEX('Banana');

--Cross Join
In SQL, the CROSS JOIN is used to combine each row of the first table with each row of the second table
SELECT      [column names]
FROM        [Table1]
CROSS JOIN  [Table2]

SELECT * FROM employee 
select * from department
CROSS JOIN department 
