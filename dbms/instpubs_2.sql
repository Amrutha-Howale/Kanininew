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

