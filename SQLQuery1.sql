CREATE Table Workers 
(Id int Primary Key Identity(1,1),
FirstName nvarchar(30) NOT NULL,
LastName nvarchar(30) NOT NULL);

Create Table Letter
(Id int Primary key Identity(1,1),
LetterTheme nvarchar(100),
SenderId int References Workers (Id),
RecieverId int References Workers(Id),
LetterDate SmallDateTime NOT NULL,
Content nvarchar(255))