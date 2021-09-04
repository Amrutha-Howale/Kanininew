create database videostores

use videostores

Create table Movie_Category 
(category_id int primary key, 
category_name varchar(20))

CREATE TABLE Movies (
    movie_id int IDENTITY(1,1) PRIMARY KEY,
    movie_title varchar(255) NOT NULL,
    category_id int foreign key references Movie_Category(category_id),
movie_desc varchar(500),
	price float 
)

create table Member_type 
(mtype_id int primary key,
mtype_name  varchar(10),
max_mov_rent int)

Create table Members (
member_id int identity(201,1)  primary key,
category_id int foreign key references Movie_Category (category_id),
phone_no varchar(10),
member_name varchar(20),
mType_id int foreign key references Member_type(mtype_id))

CREATE TABLE Dependents (
    dep_id int IDENTITY(1,1) PRIMARY KEY,
    dep_fname varchar(50),
dep_lname varchar(50),
member_id int foreign key references Members(member_id)
)

Create table Formats(
format_id int primary key,
format_name varchar(20))

Create table Movie_Format
(MovFor_id int primary key,
movie_id int foreign key references Movies(movie_id),
format_id int foreign key references Formats(format_id))

Create table RentalDetails
(rentdetail_id int primary key,
movie_id  int foreign key references Movies,
member_id  int foreign key references Members(member_id),
dep_id  int foreign key references Dependents(dep_id))


Create table Rental
(rent_id int primary key,
Rent_date date,
Return_date date,
rentdetail_id int foreign key references RentalDetails(rentdetail_id) )

alter table Movies 
add  rating float

ALTER TABLE Member_type DROP COLUMN Max_Mov_Rent;

DBCC CHECKIDENT(Dependents, RESEED, 101)


alter table RentalDetails
add rent_status varchar(10)

alter table RentalDetails drop column status
alter table RentalDetails drop column MovFor_id

alter table RentalDetails
add MovFor_id int references Movie_Format(MovFor_id)

select * from Movie_Category 
select * from Movies 
select * from Member_type 
select * from Members 
select * from Dependents 
select * from Formats 
select * from RentalDetails 
select * from Rental 
select * from Movie_Format 


Insert into Movie_Category (category_id, category_name)
values(301, 'Action')
Insert into Movie_Category (category_id, category_name)
values(302, 'Comedy')
Insert into Movie_Category (category_id, category_name)
values(303, 'Adventure')
Insert into Movie_Category (category_id, category_name)
values(304, 'Fantasy')
Insert into Movie_Category (category_id, category_name)
values(305, 'Romantic')

Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('Justice League' , 303 , 'Bruce Wayne enlists the help of his new-found ally, Diana Prince, to face an even greater enemy.', 3.8 , 100)
Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('Extraction'  ,301 , 'A black-market mercenary who has nothing to lose is hired to rescue the 
kidnapped son of an imprisoned international crime lord.' , 4.3, 150)
Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('Tom and Jerry', 302, 'A legendary rivalry reemerges when Jerry moves into New York City''s finest hotel 
on the eve of the wedding of the century, forcing the desperate event planner to hire Tom to get rid of him' , 3.3, 70)
Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('Rebecca', 305, 'A young newlywed arrives at her husband''s imposing family estate',  3, 160)
Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('Venom' , 303 , 'While trying to take down Carlton, the CEO of Life Foundation, Eddie, a journalist, investigates experiments of human trials.' , 4.4 , 150)
Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('Me Before You' ,305, 'Vivacious, unassuming Lou faces pointed questions of the heart', 3.7, 130)
Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('The Tomorrow War', 303, 'A family man is drafted to fight in a future war where the fate of humanity relies on his ability to confront the past.', 3.8, 105)
Insert into Movies (movie_title, category_id, movie_desc, rating, price)
Values
('Ted 2', 302, 'John''s help to prove in court that Ted is a person and qualified to parent', 3.1, 100 )



Insert into Member_type (mtype_id, mtype_name) 
values (401 , 'Golden')
Insert into Member_type (mtype_id, mtype_name) 
values (402 , 'Bronze' )

Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (303 , '9473846274' , 'Bharath', 401)
Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (301 , '9758637484' , 'Akshatha', 401)
Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (304 , '9748572657' , 'Chaithanya', 402)
Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (303 , '9974857362' , 'Bindu', 401)
Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (305 , '9875674843' , 'Asmal', 402)
Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (302 , '8498810719' , 'Bohdan Mazhuga', 402)
Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (301 , '8310085985', 'Victor Hugo', 401)
Insert into Members (category_id, phone_no, member_name, mtype_id) 
values (302 , '9600108389', 'Tatiana Lopatchenko', 401)

Insert into Dependents (dep_fname, dep_lname, member_id)
Values ('Kavan' , 'Changappa' , 205)
Insert into Dependents (dep_fname, dep_lname, member_id)
Values ('Chaitra' ,'Devraj' , 202 )
Insert into Dependents (dep_fname, dep_lname, member_id)
Values ('Dasha' ,'Buria' , 204 )
Insert into Dependents (dep_fname, dep_lname, member_id)
Values ('Vasiliy' ,'Vaselenko' , 202 )
Insert into Dependents (dep_fname, dep_lname, member_id)
Values ('Adhya', 'Manjunath' , 203 )
Insert into Dependents (dep_fname, dep_lname, member_id)
Values ('Karthik','Kumar' , 205 )
Insert into Dependents (dep_fname, dep_lname, member_id)
Values ('Svitlana' , 'Pantiushenko' , 202 )

Insert into Formats (format_id, format_name)
Values (501, 'DVD')
Insert into Formats (format_id, format_name)
Values (502, 'VCD')
Insert into Formats (format_id, format_name)
Values (503, 'VHS')

Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values (601 , 4 , 501)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(602 , 5 , 501)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(603 , 7 , 502)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(604 , 1 , 501)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(605 , 8 , 502)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(607 , 4 , 502)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(608 , 2 , 501)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(609 , 7 , 503)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(610 , 3 , 502)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(611 , 4 , 503)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(612 , 2 , 503)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(613 , 1 , 502)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(614 , 7 , 501)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(615 , 8 , 503)
Insert into Movie_Format (MovFor_id, movie_id, format_id)
Values 
(616 , 6 , 503)

Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(701 , 4 , 201 , NULL , 601,'Rented')
Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(702 , 5 , 206 , NULL , 602, 'Rented')
Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(703 , 1 , 202 , 102   , 613, 'Returned')
Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(704 , 7 , 201 , NULL  , 609, 'Returned')
Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(705 , 8 , 202 , 102  , 605, 'Rented')
Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(706 , 2 , 205 , 107  , 608, 'Returned')
Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(707 , 3 , 203 , 105  , 610, 'Rented')
Insert into RentalDetails (rentdetail_id, movie_id, member_id, dep_id, MovFor_id, rent_status)
Values
(708 , 6 , 202 , 102  , 616, 'Rented')

Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(801 , '2021-07-07' , '2021-07-14' , 703)
Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(802 , '2021-08-20' , '2021-08-24' , 701)
Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(803 , '2021-08-01' , '2021-08-05' , 707)
Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(804 , '2021-09-17' , '2021-09-25' , 704) 
Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(805 , '2021-06-25' , '2021-07-05' , 706) 
Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(806 , '2021-01-05' , '2021-01-12' , 702)
Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(807 , '2021-10-03' , '2021-10-10' , 708) 
Insert into Rental ( Rent_ID, Rent_date, return_date, rentdetail_id)
Values
(808 , '2021-08-07' , '2021-08-14' , 705)
















