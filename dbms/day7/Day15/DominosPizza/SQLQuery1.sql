create Database Pizza_Shop1
use Pizza_Shop1

create table Pizza(
ID int Identity(100,1),
Pizza_Name varchar(100) not null,
price float not null,
Pizza_Type varchar(20),
Constraint pk_Pizza primary key(ID))

Create table Toppings(
ID int Identity(1001,1),
Toppings_Name varchar(100) not null,
Price int not null,
Constraint pk_Toppings primary Key(ID))

Create table Customers(
Cust_ID int identity(2001,1),
Cust_Name varchar(100) not null,
Cust_Email varchar(100) not null,
Cust_Password varchar(100) not null,
Cust_Address varchar(1000) not null,
Cust_Phone char(11),
Constraint pk_customers primary key(Cust_ID))

Create table Orders(
Order_ID int identity(5000,1),
Total_Price float not null,
Cust_ID int foreign Key references Customers(Cust_ID),
Delivery_Address varchar(1000) not null,
Order_date datetime not null,
Constraint pk_Orders primary key(Order_ID))

sp_help Orders

Create table Order_Details(
ID int identity(6001,1),
Pizza_ID int foreign key references Pizza(ID) not null,
Qty int not null,
Order_ID int foreign key references Orders(Order_Id) not null,
constraint pk_Order_details primary key(ID))

create Table Topping_Details(
Topping_Details_id int identity(300,1) primary key,
Details_ID int foreign key references Order_Details(Id) not null,
Toppings_ID int foreign key references Toppings(ID) not null)

select * from Pizza
select * from Toppings
select * from Customers
select * from Orders
select * from Order_Details
select * from Topping_Details

insert into Pizza(Pizza_Name,Price,Pizza_Type) Values('Peppy Paneer Pizza',299,'Speicy')
insert into Pizza(Pizza_Name,Price,Pizza_Type) Values('Peppy Paneer Pizza',299,'Normal')
insert into Pizza(Pizza_Name,Price,Pizza_Type) Values('Mashroom Pizza',399,'Normal')
insert into Pizza(Pizza_Name,Price,Pizza_Type) Values('Veg Loaded',399,'Speicy')
insert into Pizza(Pizza_Name,Price,Pizza_Type) Values('non-Veg Loaded',399,'Fresh pan pizza')

insert into Toppings(Toppings_Name,Price)Values('Onion',80)
insert into Toppings(Toppings_Name,Price)Values('Cheese Bust',99)
insert into Toppings(Toppings_Name,Price)Values('Tomato',60)