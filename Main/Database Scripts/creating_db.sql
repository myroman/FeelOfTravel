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

-- new tables
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbOffers')) BEGIN
drop table tbOffers
end
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbOfferTypes')) BEGIN
drop table tbOfferTypes
end
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbCoreArticleData')) BEGIN
drop table tbCoreArticleData
end
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbInformationCategories')) BEGIN
drop table tbInformationCategories
end


-- create tables
/*create table tbMainPage
(
entryId int identity(1,1),
[text] varchar(max) not null,

constraint PK_mainPageId primary key(entryId)
)*/

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
create table tbInformationCategories
(
id int not null,
name varchar(max) not null,

constraint PK_InformationCategoryId primary key(id)
)

go
create table tbCoreArticleData
(
id int identity(1,1),
categoryId int not null,
header varchar(200) not null,
[text] varchar(max) not null,
imageUrl varchar(300),
publishDate date not null,

constraint PK_CoreArticleDataId primary key(id),
constraint FK_categoryId foreign key(categoryId)
references tbInformationCategories (id)
)

go
create table tbOfferTypes
(
id int not null,
[name] varchar(max) not null,

constraint PK_OfferTypeId primary key(id)
)

go
create table tbOffers
(
id int identity(1,1),
coreArticleDataId int not null,
price float,
typeId int not null,

constraint PK_OfferId primary key(id),
constraint FK_CoreArticleDataId foreign key(coreArticleDataId)
references tbCoreArticleData(id),
constraint FK_OfferTypeId foreign key(typeId)
references tbOfferTypes(id)
)

-- Fill db
insert into dbo.tbInformationCategories (id, name)
values(1,'Акции')
insert into dbo.tbInformationCategories (id, name)
values(2,'Новости')
insert into dbo.tbInformationCategories (id, name)
values(3,'Страны')

insert into dbo.tbOfferTypes (id, name)
values(1, 'Спецпредложения')
insert into dbo.tbOfferTypes (id, name)
values(2, 'Круизы')
insert into dbo.tbOfferTypes (id, name)
values(3, 'Автобусные туры')