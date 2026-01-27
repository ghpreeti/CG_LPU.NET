--CREATE SCHEMA PankajBatch
create table Person(Id int, Name varchar(30) Not Null,Age int,Address varchar(50), PhoneNo varchar(10))
insert into Person values(1,'Preeti',20,'ABC',7878787878)

select * from Person