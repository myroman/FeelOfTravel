--drop tables
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbMainPage')) BEGIN
 drop table tbMainPage
END
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbAboutPage')) BEGIN
drop table tbAboutPage
end
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbContactsPage')) BEGIN
drop table tbContactsPage
end

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbTeasers')) BEGIN
drop table tbTeasers
end
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbArticles')) BEGIN
drop table tbArticles
end
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbArticleTypes')) BEGIN
drop table tbArticleTypes
end

-- create tables
create table tbMainPage
(
entryId int identity(1,1),
[text] varchar(max) not null,

constraint PK_mainPageId primary key(entryId)
)

go
create table tbAboutPage
(
entryId int identity(1,1),
[text] varchar(max) not null,

constraint PK_aboutPageId primary key(entryId)
)

go
create table tbContactsPage
(
entryId int identity(1,1),
[text] varchar(max) not null,

constraint PK_contactsPageId primary key(entryId)
)

go
create table tbArticleTypes
(
articleTypeId int,
articleType varchar(50) not null,

constraint PK_articleTypeId primary key(articleTypeId)
)

go
create table tbArticles
(
articleId int identity(1, 1),
articleTypeId int not null,
header varchar(100) not null,
[text] varchar(max) not null,
price float,

constraint PK_articleId primary key(articleId),
constraint FK_articleTypeId foreign key(articleTypeId)
references tbArticleTypes (articleTypeId)
)
go

create table tbTeasers
(
teaserId int identity(1, 1),
preamble varchar(50) not null,
imageLink varchar(100),
relatedArticleId int not null,

constraint PK_teaserId primary key(teaserId),
constraint FK_relatedArticleId foreign key(relatedArticleId)
references tbArticles(articleId)
)
go

--fill db
delete from dbo.tbArticleTypes

insert into dbo.tbArticleTypes (articleTypeId, articleType) 
values(1, 'Акции')
insert into dbo.tbArticleTypes (articleTypeId, articleType) 
values(2, 'Круизы')
insert into dbo.tbArticleTypes (articleTypeId, articleType) 
values(3, 'Автобусные туры')