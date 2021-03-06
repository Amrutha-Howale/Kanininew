select * from Customers
select * from Suppliers
select * from Orders
select * from Shippers
select * from [Order Details]
select * from Categories
select * from Employees
select * from Products

--1)Print all the customer details
select * from Customers

--2)Print the product name and unit price
select ProductName,UnitPrice from Products

--3)For a given supplier name print all the products
select ProductName from Products where SupplierID in(
select SupplierID from Suppliers where CompanyName='Tokyo Traders' )

-- 4)Print the number of order for every customer
select count(OrderId) 'Number of order', CustomerID from Orders 
group by CustomerID

--5)For a given shipping company name print number of orders for every customer
select Count(OrderID) 'Orders',CustomerID from Orders where shipVia in(
select ShipperID from Shippers where CompanyName='Speedy Express') group by CustomerID

-- 6)Print the customer ID and the number of orders placed sorted by the orders in descending order
select CustomerID, Count(OrderID) 'Number of orders' from Orders group by CustomerID
order by count(OrderID) desc

--7)print the average price of items supplied by every supplier
select avg(UnitPrice) 'avg price',SupplierID from Products group by SupplierID

--8)Print the average price of products and supplier quantity
select avg(UnitPrice) 'avg price',Quantity from [Order Details] group by Quantity

--9)Print the total price of every order
select OrderID,(UnitPrice*Quantity) as 'Total price' from [Order Details] 

--10)Given a category name print the prodcts in it
select ProductName from Products where CategoryID in(
select CategoryID from Categories where CategoryName='Beverages')

--11)Print the product name, supplier name for all the products
select ProductName,CompanyName from Products p join Suppliers s on p.SupplierID=s.SupplierID

--12)Print the customer name and the total sales done by the customer
select ContactName 'customer name', count(orderid) 'total sales'from Customers c join Orders o on c.CustomerID=o.CustomerID
group by ContactName
--or
select ContactName , count(*) as 'Number of sales' from Customers c join Orders o on c.CustomerID = o.CustomerID group by ContactName

--13)Print the customer name, product name,category name and supplier name
select ProductName,CategoryName,ContactName 'Supplier Name',CompanyName 'Customer Name' from 
Categories ca join Products p on ca.CategoryID = p.CategoryID join Suppliers s on p.SupplierID = s.SupplierID

--14)Print the shipper name, customer name, product name and the full name of employee who took the order
select s.ShipperID,c.CompanyName,p.ProductName,concat(LastName,'',FirstName) 'employee name' 
from Shippers s,Customers c, Products p, Employees e,Orders o where o.EmployeeID=e.EmployeeID --wrong
--or
select S.CompanyName as 'ShipperName', C.CompanyName as 'Customer Name', P.ProductName, concat(E.Lastname,' ',E.FirstName) as 'Employee Name' 
from Shippers S join Orders O on S.ShipperID=O.ShipVia join Customers C on C.CustomerID=O.CustomerID join [Order Details] OD 
on O.OrderID=OD.OrderID join Products P on OD.ProductID=P.ProductID join Employees E on O.EmployeeID=E.EmployeeID
--or
select companyName 'ShipperName', ContactName'Customer Name',ProductName,concat(FirstName,'',lastname) 
from Employees e join orders o on e.EmployeeID=o.EmployeeID join Customers c on c.CustomerID=o.CustomerID join Products p on p.ProductID=o.OrderID  --wrong

--15)Print the product name and the total order price for every product
select ProductName,sum(unitprice) 'total price'  from Products GROUP BY ProductName --WRONG
--OR
select ProductName, sum(od.UnitPrice*od.Quantity) 'total order price for every product'
from Products p join [Order Details] od on p.ProductID=od.ProductID group by ProductName

