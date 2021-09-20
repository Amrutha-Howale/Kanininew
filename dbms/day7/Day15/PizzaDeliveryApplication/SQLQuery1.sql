create database PizzaDelevery

create table Register (
UserId int,
Username varchar(20),
Password varchar(20),
adress varchar(20)
)
drop table Register

select * from Register

create table Pizzashop (
PizzaID int,
PizzaName varchar(20),
Price int,
Type varchar(20)
)

create table Toppings(
ToppingId int,
ToppingName varchar(20),
price int)

select * from Pizzashop
select * from Toppings

create table OrderDetails(
OrderId int,
OrderPizza varchar(20),
PizzaToppings varchar(20),
UserId int,
Total varchar(20))

select * from OrderDetails
