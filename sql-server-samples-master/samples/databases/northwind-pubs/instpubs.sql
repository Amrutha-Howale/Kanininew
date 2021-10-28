/*                                                                        */
/*              InstPubs.SQL - Creates the Pubs database                  */ 
/*                                                                        */
/*
** Copyright Microsoft, Inc. 1994 - 2000
** All Rights Reserved.
*/

select * from titles

select title, price from titles

select title Book_name,price Book_price from titles

select * from titles where price<10

select * from titles where price<5

select * from titles where price between 5 and 10

--OR

select * from titles where price>=5 and price<=10

select * from titles where price>5 and type='psychology'

select title,price  from titles  where advance>3500

select * from titles where type='business' or type='mod_cook'

--OR

select * from titles where type in('business','mod_cook')

select * from titles where pubdate>'1991-06-12'

select * from authors

select * from authors where city='Oakland' or city='Salt Lake City' and state='CA'

select * from sales

select * from sales where qty>2

select title, price from titles where price is null

select count(au_id) from authors where state='CA'
select count(au_id) 'NUmber of authors' from authors where state='CA'

select min(price) 'min',max(price) 'max',avg(price) 'avg' from titles

select avg(price) 'avg of book' from titles where type in('business','mod_cook')

select type from titles

--AVOID REPETITION 

select distinct type from titles

--Get the avg price of every type (every=group by)
select type,avg(price) from titles
group by type

--get min quantity sold for every title
select title_id,min(qty) from sales 
group by title_id

--count authors from every city
select city,count(au_id) 'authors' from authors 
group by city

select * from titles

select pub_id,count(*) 'num of books',avg(price) 'price' from titles
group by pub_id

select * from employee

select pub_id, min(hire_date) as'first hire date' from employee group by pub_id

--HAVING CLAUSE
select type,avg(price) from titles
group by type
having avg(price)>15

select pub_id,count(*) 'num of emp' from employee 
group by pub_id
having count(*)>2

select title_id,avg(qty) from sales
group by title_id
having avg(qty)>4

--get the count of books sold by every publisher 
--which are in type 'business','mod_cook'
--where the count is greater the 2
select pub_id,count(title_id) 'books sold' from titles where type in('business','mod_cook')
group by pub_id
having count(title_id)>2

--ORDER BY CLAUSE
select * from titles ORDER BY price
select * from titles ORDER BY price desc

--select the titles that are priced>15 sort them by publisher date
select title,price from titles where price>15
order by pubdate 

--get the count of books sold by every publisher 
--which are in type 'business','mod_cook'
--where the count is greater the 2
--order them by number of employees 
select pub_id,count(*) 'num of emp'from employee 
group by pub_id
having count(*)>2
order by 2               ----(2 is the 2nd column)


select * from publishers

select * from titles
where pub_id=(select pub_id from publishers where pub_name='Algodata Infosystems')

select * from titles
where pub_id in (select pub_id from publishers where country='USA')

select * from sales
select * from titles
select * from employee

--print all the sales for title that priced >10
select * from sales where title_id in(
select title_id from titles where price>10)

--select authors who are from the same city as Algodata Infosystems
select * from authors where city =(
select city from publishers where pub_name='Algodata Infosystems')

select concat(fname,' ',lname) from employee

--print the employee name who work for the publisher who published 
--straight talk about computers
select fname from employee where pub_id=(select pub_id from publishers where pub_id=(
select pub_id from titles where title='Straight Talk About Computers'))

--JOIN
--INNER JOIN CLAUSE

select title,pub_name from publishers p join titles t
on p.pub_id=t.pub_id

select concat(au_fname,' ',au_lname)'author name', title 'Book name'
from titles t join titleauthor ta on t.title_id=ta.title_id
join authors a on a.au_id=ta.au_id

select * from titles
select * from sales
select title, (price*qty) as 'total price' 
from titles t join sales s on t.title_id=s.title_id

select * from employee
select * from publishers
select pub_name,concat(fname,'',lname) 'emp name' 
from publishers p join employee e on p.pub_id=e.pub_id

SELECT * from publishers
select * from titles
select * from sales
select * from 


--print the publishers who have not published yet 
select pub_id from publishers where pub_id not in(select distinct pub_id from titles)

select pub_name 'pub name' ,count(title_id)
from publishers p join titles t
on p.pub_id=t.pub_id 
group by pub_name
order by 2

select pub_name 'pub name' ,count(title_id)
from publishers p left outer join titles t
on p.pub_id=t.pub_id 
group by pub_name
order by 2

select title 'Book name', concat(au_fname,'',au_lname) 'author name'
from titleauthor ta right outer join authors a
on a.au_id=ta.au_id
left outer join titles t on t.title_id=ta.title_id
order by 1

select title, sum(t.price*s.qty) 'Total amount' from titles t, sales s 
group by title
order by 1
--or
select t.title, (t.price*s.qty) 'Total amount' from titles t left outer join sales s on t.title_id=s.title_id
order by 1

--SELF JOIN
create table cust
(id int identity(1,1) primary key,
name varchar(20),
reffBy int)

alter table cust
add constraint fk_reff foreign key(ReffBy) references cust(id)

select * from cust

insert into cust(name,reffBy) VALUES ('james',NULL)
insert into cust(name,reffBy) VALUES ('jack',1)
insert into cust(name,reffBy) VALUES ('jill',1)
insert into cust(name,reffBy) VALUES ('phill',2)

--customer name and reffBy name
select cus.name 'Customer Name',ref.name 'Reffered By' from
cust cus left outer join cust ref
on cus.reffBy=ref.id

--stored procedure --DML QUERIES 
	--complies and generated the excution plan only once
	--encapsulates the underlying table
	--no data injection --more secure
Create procedure proc_example
as 
begin
	print 'hello world'
end

execute proc_example

--sp with inner parameter
Create procedure proc_example_parameter(@username varchar(20))
as 
begin
	print 'hello '+@username
end

execute proc_example_parameter 'chaitra adhya'

--sp with out parameter 
Create procedure proc_example_out_parameter(@username varchar(20), @msg varchar(100) out)
as 
begin
	set @msg= 'hello '+@username
end

declare
	@myMsg varchar(100)
	exec proc_example_out_parameter 'ammu',@myMsg out
	print @myMsg

--sp with two out parameter 
Create procedure proc_example_out_city_parameter(@username varchar(20),@city varchar(20), @msg varchar(100) out, @msg2 varchar(100) out)
as 
begin
	set @msg= 'hello '+@username
	set @msg2= 'welcome to '+@city
end

declare
	@myMsg varchar(100),@myMsg2 varchar(100)
	exec proc_example_out_city_parameter 'james', ' smg',@myMsg2 out,@myMsg2 out
	print @myMsg
	print @myMsg2


--sp to get auth
create proc proc_getall_Authors
as
	select * from authors

exec proc_getall_Authors

--sp to get auth_id
create proc proc_get_authors_id(@aid varchar(20))
as
	select * from authors where au_id=@aid

exec proc_get_authors_id '213-46-8915'


--sp to get title_id
create proc proc_get_title_id(@tid varchar(20))
as
	select * from titles where title_id=@tid

exec proc_get_title_id 'BU1111'

--proc to get full name ans out of auth using auth_id
create proc proc_get_auth_full_name(@afull_id varchar(20))
as
	select concat(au_lname,'',au_fname) as author_name from authors where au_id=@afull_id 

exec proc_get_auth_full_name '213-46-8915'

--proc for two out
create proc proc_get_total_qty_price (@tid varchar(20),@tqty int out,@tprice float out)
as begin 
	set @tqty= (select sum(qty) from sales where title_id=@tid)
	set @tprice= (select price from titles where title_id=@tid)
end

Create table tblEmpSample
(id int identity(101,1) primary key,
name varchar(20),
age int)

--create a proc that will insert records into the table tblEmpSample 
CREATE PROC proc_Insert(@name VARCHAR(20), @age int) 
AS 
INSERT INTO tblEmpSample VALUES (@name, @age) 
EXEC proc_Insert 'amrutha', 25

--create a proc that will update age of employee ny taking the id
CREATE PROC proc_Update_Employee_Age_records(@id int, @age int) 
AS BEGIN
UPDATE tblEmpSample 
SET age = @age WHERE id = @id 
END
EXEC proc_Update_Employee_Age_records'101', 25

select * from tblEmpSample

--FUNTIONS (SCALAR FUNCTION OT TABLE VALUED FUNCTION)

create function fn_sample()
returns varchar(10)
as 
begin
	return 'hello'
end

select dbo.fn_sample()

create function fn_sample_with_value_ak1(@name varchar(20))
returns varchar(20)
as 
begin
	return 'hello '+@name
end

select dbo.fn_sample_with_value_ak1('akanksha')

--calculate the tax

create function fn_cal_tax(@value float)
returns float
begin
declare
	@net float
	set @net=@value+(@value*12.3/100)
	return @net
end

select dbo.fn_cal_tax(advance) from titles
select * from titles

--create a fun that will calculate the (advance-price) and use it in titles table
create function fn_cal_adv_price_diff(@adv float,@price int)
returns float
begin
declare
	@net float
	set @net=@adv-@price
	return @net
end

select dbo.fn_cal_adv_price_diff(advance,price) 'Result' from titles

--TABLE VALUED FUNCTION
create function fn_Table_Sample(@id int,@name varchar(5))
returns @myTable table(f1 int,f2 varchar(10))
as 
begin
	insert into @myTable VALUES(@id, concat('hi ', @name))
	return
end

select * from dbo.fn_Table_Sample(1,'james')
select * from dbo.fn_Table_Sample(2,'jill')

create function fn_getsaledetails(@tid varchar(20))
returns @salesTable table (ordernumber varchar(10),quantity int,price float)
as
begin
	insert into @salesTable
	select ord_num,qty,price from sales join titles on sales.title_id=titles.title_id
	where sales.title_id=@tid
	return
end

select * from titles

select * from dbo.fn_getsaledetails('BU1032')

--TRIGGERS
create table tblTriggercheck
(f1 int identity(1,1) primary key,
f2 varchar(20))

CREATE trigger trg_checkInsert
on tblTriggercheck
for Insert
as
begin
	print 'hello from insert trigger'
end

insert into tblTriggercheck(f2) values('one')

alter trigger trg_checkInsert
on tblTriggercheck
for Insert
as
begin
	declare
	   @name varchar(20)
	   set @name=(select f2 from inserted)
	print 'hello '+@name
end

insert into tblTriggercheck(f2) values('jam')
insert into tblTriggercheck(f2) values('jerry')

create table tblSalary
(id varchar(4) primary key,
basic float,
HRA float,
Da float,
deductions float)

insert into tblSalary values(1,20000,1000,2000,1000)
insert into tblSalary values(2,10000,1650,2000,1500)
insert into tblSalary values(3,40000,1500,2200,1000)


create table tbl_Empl
(id int identity(101,1) primary key,
name varchar(20))


insert into tbl_Empl values('jack')
insert into tbl_Empl values('jill')
insert into tbl_Empl values('james')


create table emplSal(
empId int foreign key references tbl_Empl(id) ,
salId varchar(4) foreign key references tblSalary(id) ,
salDate date,
totalSal float)



select * from tblSalary
select * from tbl_Empl
select * from emplSal

create trigger trg_insertemplsal
on emplSal
for insert
as 
begin
	declare
	@totalSalary float
	set @totalSalary =(select (basic+hra+da-deductions) from tblSalary where id=(select salId from inserted))
	UPDATE emplSal set totalsal = @totalSalary where empId=(select empID from inserted) and
	salid =(select salID from inserted)
end

insert into emplSal(empId,salId,salDate) values (101,'1',GETDATE())
insert into emplSal(empId,salId,salDate) values (102,'2',GETDATE())

SELECT * from emplSal


--CURSOR
--for cursor select from declare to Deallocate to execute 
declare 
@empId int, @salId varchar(4),@salDate Date, @totalSal float,@empName varchar(20)
print 'Salary details'
declare cur_empsal cursor for
select * from emplSal

open cur_empsal

fetch next from cur_empsal into @empId,@salId,@salDate,@totalSal
while (@@FETCH_STATUS=0)
	begin
		set @empName= (select name from tbl_Empl where id=@empId)
		print 'Employee id '+cast(@empId as varchar(5))
		print 'Employee Name '+ @empName
		print 'Salary id '+ @salId 
		print 'Salary '+cast(@totalSal as varchar(5))
		print 'Salary Date '+cast(@salDate as varchar(20))
		print '------------------------------------------'
		fetch next from cur_empsal into @empId,@salId,@salDate,@totalSal
	end
close cur_empsal
Deallocate cur_empsal



--create a trigger in employee table insert the employee id and name into another table
--(tblAnotherEmployee- create this table)

create table tblAnotherEmployee
(another_empID int identity(301,1) primary key,
emp_ID int foreign key references tbl_Empl(id),
emp_name varchar(20) )

select * from tbl_Empl


alter trigger trg_insert_empldetails
on tbl_Empl
for insert
as 
begin
	declare
	@insertname varchar(30), @insertid varchar(20)
	set @insertname = (select name from inserted)
	set @insertid= (select id from inserted)
	update tblAnotherEmployee set emp_ID=@insertid, emp_name=@insertname
	--update tblAnotherEmployee set emp_name=@insertname
	print 'values inserted '+ @insertname
	print 'employee id '+@insertid
end

insert into tbl_Empl values('larry')

select * from tblAnotherEmployee
select * from tbl_Empl

--or
create table tblanotheremp(id int ,name varchar(100))

create trigger insert_into_anothertable 
on tbl_Empl 
for insert 
as 
begin
	declare @id int,@name varchar(100) 
	set @id=(select id from inserted) 
	set @name=(select name from inserted)
	insert into tblanotheremp(id,name) values(@id,@name) 
end

insert into tbl_Empl values('larry1')
select * from tblanotheremp


--create a cursor thet will print the sale date in the following format
--Book Name: abc
--Book price: 20
--Author: XXX
--Authir YYY
--Quantity: 2
--Total price: 20*2-40
create table book_details
(
bookname varchar(20),
bookprice varchar(4),
author varchar(20),
quantity int,
totalprice varchar(5))

insert into book_details(bookname,bookprice,author,quantity,totalprice) values('ABC',50,'AAA',3,150)
insert into book_details(bookname,bookprice,author,quantity,totalprice) values('ABB',30,'BBB',2,60)
insert into book_details(bookname,bookprice,author,quantity,totalprice) values('AYY',35,'CCC',5,175)


select * from book_details
drop table book_details



declare 
 @bookname varchar(20), @bookprice varchar(4),@author varchar(20), @quantity int,@totalprice varchar(5)
print 'book details'
declare cur_bkdet cursor for
select * from book_details

open cur_bkdet

fetch next from cur_bkdet into @bookname,@bookprice,@author,@quantity,@totalprice
while (@@FETCH_STATUS=0)
	begin
	
		print 'Book name '+ cast(@bookname as varchar(20))
		print 'book price '+ cast( @bookprice as varchar(4))
		print 'author '+ cast(@author as varchar(20))
		print 'quantity '+ cast( @quantity as varchar(10))
		print 'totalprice '+cast(@totalprice as varchar(5))
		print '------------------------------------------'
		fetch next from cur_bkdet into @bookname,@bookprice,@author,@quantity,@totalprice
	end
close cur_bkdet
Deallocate cur_bkdet


