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


