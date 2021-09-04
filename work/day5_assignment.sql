create table tblEmpSample
(id int identity(101,1) primary key,
name varchar(20),
age int)

CREATE table Salary(
salId int primary key
,basic int,
hra int,
da int,
deductions int) 

create table employeesalary(
empId int identity(201,1) primary key ,
salId int foreign key references salary (salId) ,
Date datetime ,
Extra  int,
saldate datetime)

select * from tblEmpSample
insert into tblEmpSample(name,age) values ('Amrutha',21)
insert into tblEmpSample(name,age) values ('chaitra',22) 
insert into tblEmpSample(name,age) values ('adhya',22) 
insert into tblEmpSample(name,age) values ('akanksha',23) 
insert into tblEmpSample(name,age) values ('anish',19) 
insert into tblEmpSample(name,age) values ('smith',32)
insert into tblEmpSample(name,age) values ('john',35) 

insert into  salary (salId, basic, hra  ,da , deductions) values ('201','25000','2000','1500','1000')
insert into  salary (salId, basic , hra  ,da , deductions) values (202,'27000','3500','1000','2000')
insert into  salary (salId, basic , hra  ,da , deductions) values (203,'28000','3500','3000','1500')
insert into  salary (salId, basic , hra  ,da , deductions) values (204,'32000','4000','5000','500')
insert into  salary (salId, basic , hra  ,da , deductions) values (205,'43000','2000','5500','2000')
insert into  salary (salId, basic , hra  ,da , deductions) values (206,'45000','3000','5000','500')
insert into  salary (salId, basic , hra  ,da , deductions) values (207,'50000','1000','3000','2000')

select * from Salary

insert into  employeesalary( salId ,Date ,Extra  ,saldate ) values ( 201,'2020-03-19',2500,'2020-04-09')

insert into  employeesalary( salId ,Date ,Extra  ,saldate ) values ( 202,'2020-05-20',1512,'2020-05-21')

insert into  employeesalary( salId ,Date ,Extra  ,saldate ) values ( 203,'2020-10-29',-200,'2020-03-03')

insert into  employeesalary( salId ,Date ,Extra  ,saldate ) values ( 204,'2020-09-23',-1603,'2020-09-30')

insert into  employeesalary( salId ,Date ,Extra  ,saldate ) values ( 205,'2020-10-09',2007,'2020-03-16')

insert into  employeesalary( salId ,Date ,Extra  ,saldate ) values ( 206,'2020-07-11',-1301,'2020-05-19')

insert into  employeesalary( salId ,Date ,Extra  ,saldate ) values ( 207,'2020-08-19',1220,'2020-06-10')

select * from employeesalary

--1)Create a procedure that will insert to the tables
--insertion proecdure for employee
create proc Insert_into_table_tblEmpSample(@ename varchar(30),@eage int)
as
    insert into tblEmpSample(name,age) values (@ename,@eage)

exec  Insert_into_table_tblEmpSample 'Geetha',45

--insertion proecdure for Salary
create proc Insert_into_table_salary(@sal_id int,@s_basic int,@s_hra int,@s_da int,@s_deduc int)
as
    insert into salary(salId,basic,hra,da,deductions) values (@sal_id,@s_basic ,@s_hra ,@s_da ,@s_deduc )

exec  Insert_into_table_salary 208,'35000',2500,1435,1572

--2)Create a function that will calcualte the total salary(Basic+HRA+Da-ded+extra)
create function fun_to_cal_totsal(@basic float,@hr float,@da float,@ded float,@extra float)
returns float 
as
begin
declare
@totalsal float
  set @totalsal = ( @basic+@hr+@da-@ded+@extra)
  return @totalsal	
end

select dbo.fun_to_cal_totsal (basic, hra, da, deductions, extra) from salary s join employeesalary e on e.salId=s.salId

--3)create a procedure that will take a employee id and give back the total salary received.Use the fuction to do the calculation
create function fun_to_cal_totsalary(@basic float,@hr float,@da float,@ded float,@extra float)
returns float 
as
begin
declare
@totalsal float
  set @totalsal = ( @basic+@hr+@da-@ded+@extra)
  return @totalsal	
end

select dbo.fun_to_cal_totsalary (basic, hra, da, deductions, extra) from salary s join employeesalary e on e.salId=s.salId

create proc func_employe_inser_by_id(@e_id varchar(20),@e_total int out)
as
begin
    set @e_total = (select salId,t.totalsal from employeesalary e join fun_to_cal_totsalary t where empId = @e_id)	
end

declare
  @ttto float,@totalsal float
begin  
  exec    func_employe_inser_by_id  '201', fun_to_cal_totsalary out
  set @ttto =  @totalsal
  print @ttto
end

select * from titles

--IF IN SQL
The IF() function returns a value if a condition is TRUE, or another value if a condition is FALSE.
syntax: IF(condition, value_if_true, value_if_false)

ex: 
select OrderID,(UnitPrice*Quantity) as 'Total price' from [Order Details]

BEGIN
    DECLARE @priceqty INT;

    SELECT 
        @priceqty = (UnitPrice*Quantity)
        from 
		[Order Details];

    SELECT @priceqty;

    IF @priceqty > 100
    BEGIN
        PRINT 'Great! The sales amount in 2018 is greater than 100';
    END
END

select * from [Order Details]

--FOR IN SQL
DECLARE @cnt INT = 0;

WHILE @cnt < cnt_total
BEGIN
   {...statements...}
   SET @cnt = @cnt + 1;
END;

DECLARE @cnt INT = 0;

WHILE @cnt < 10
BEGIN
   PRINT 'Inside simulated FOR LOOP on TechOnTheNet.com';
   SET @cnt = @cnt + 1;
END;

PRINT 'Done simulated FOR LOOP on TechOnTheNet.com';
GO