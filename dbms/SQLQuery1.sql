create database dbCompany17Aug

use dbCompany17Aug

Create table Areas
(area varchar(20),
zip char(5)
)

Sp_help Areas

alter table Areas
alter column area varchar(20) not null

alter table Areas 
add constraint pk_Area primary key(area)

Sp_help Areas

drop table Areas

Create table Areas
(area varchar(20) constraint pk_Area primary key,
zip char(5)
)

create table Employee
(id int identity(101,1) primary key,
name varchar(20),
phone varchar(20),
employee_area varchar(20) foreign key references Areas(area))

Sp_help Employee

create table skill
(skill varchar(20) primary key,
skill_description varchar(20))

Sp_help skill

create table EmployeeSkill
(employee_id int foreign key references Employee(id),
skill_name varchar(20) foreign key references skill(skill),
skill_level float default(3),
primary key(employee_id,skill_name))

Sp_help EmployeeSkill

select * from Areas

insert into Areas values('AAA','12345')
insert into Areas values('BBB','12356')
insert into Areas values('CCC','12376')

--CANNOT DO THE FOLLOWING
insert into Areas values('AAA','123451223')
insert into Areas values(null,'12345')
insert into Areas values('AAA','12345')
--UPTO THIS

select * from Employee

insert into Employee(name,phone,employee_area) values('ammu','1234567890','AAA')
insert into Employee(name,phone,employee_area) values('mj','9874567890','BBB')
insert into Employee(name,phone,employee_area) values('adhi','9874654349','CCC')
--FAILS
insert into Employee(name,phone,employee_area) values('mj','9874567890','DDD')

select * from skill

insert into skill(skill,skill_description) values('SQL','RDBMS')
insert into skill(skill,skill_description) values('C','PLT')
insert into skill(skill,skill_description) values('JAVA','WEB')

select * from EmployeeSkill 

insert into EmployeeSkill values(101,'C',7)
insert into EmployeeSkill values(101,'SQL',8)
insert into EmployeeSkill values(102,'C',default)


create table pic
(id int primary key,
piclink varchar(20))

create table supplier(
id varchar(20) primary key,
name varchar(20),
phone varchar(20),
email varchar(20),
adress varchar(20))

create table category
(id int primary key,
name varchar(20),
description varchar(20))

create table occation
(id int primary key,
name varchar(20),
startdate datetime,
enddate datetime,
description varchar(20))

create table item
(id varchar(20) primary key,
name varchar(20),
price int,
quantityInstock varchar(20),
Description varchar(20),
Supplier_Id varchar(20) foreign key references supplier(id),
category_id int foreign key references category(id),
rating varchar(20))

create table itempic
(item_id varchar(20) foreign key references item(id),
pic_id int foreign key references pic(id)
primary key(item_id,pic_id))

create table city
(item_id varchar(20) foreign key references item(id),
city varchar(50)
primary key(item_id))

create table occation_item
(occation_id int foreign key references occation(id),
item_id varchar(20) foreign key references item(id),
primary key(occation_id,item_id),
discount_percentage varchar(20))





