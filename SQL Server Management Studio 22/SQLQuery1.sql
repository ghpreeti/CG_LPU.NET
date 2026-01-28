use LPU_DB
select * from StudentInfo

Alter Table StudentInfo Add PhoneNo Varchar(10)
Alter Table StudentInfo Add SchoolName Varchar(10) default 'Rkkk'
Insert into StudentInfo (RollNo,Name,Age,LocalAddr,PermAddr,PhoneNo) values(102,'Riya',22,'delhi','Lucknow','9898989898')

Create Table StudentMarks(srNo int identity(1000,1), RollNo int References StudentInfo(RollNo),Phy int Not null,
Chem int not null,Maths int not null, TotalMarks As (Phy+Chem+Maths),Perc as ((Phy+Chem+Maths)/3))

Insert Into StudentMarks(RollNo,Phy,Chem,Maths) values(1,99,89,66)

Select * from StudentMarks


