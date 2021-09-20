create database ProductDetails
use ProductDetails

create table Product(
ProdId int primary key,
ProdName varchar(20),
ProdPrice int,
quantity int
)

insert into Product(ProdId,ProdName,ProdPrice,quantity) values(101,'ABC',200,2)
insert into Product(ProdId,ProdName,ProdPrice,quantity) values(102,'YTH',100,4)
insert into Product(ProdId,ProdName,ProdPrice,quantity) values(103,'UDJ',299,5)

select * from Product
