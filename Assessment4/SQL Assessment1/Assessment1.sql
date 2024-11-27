create database AssessmentOne

//Creating books table
CREATE TABLE books
(
id INT PRIMARY KEY,
title VARCHAR(40),
author VARCHAR(40),
isbn VARCHAR(40) UNIQUE,
published_date DATETIME
);

INSERT INTO books VALUES
(1, 'My First SQL Book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
(2, 'My Second SQL Book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
(3, 'My Third SQL Book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44')

select * from books;

//Author whose name ends with er
SELECT * FROM books
where author LIKE '%er';

//Creating reviews table
CREATE TABLE reviews 
(
id INT PRIMARY KEY,
book_id INT,
reviewer_name VARCHAR(40),
content VARCHAR(400),
rating INT,
published_date DATETIME,
FOREIGN KEY (book_id) REFERENCES books(id)
);

INSERT INTO reviews VALUES
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11.1'),
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
(3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

select * from reviews;

//Joining and displaying
SELECT b.title, b.author, r.reviewer_name FROM books b JOIN reviews r ON b.id = r.book_id;

//Reviewed more than one book
SELECT reviewer_name FROM reviews GROUP BY reviewer_name HAVING COUNT(book_id) > 1;

//Creating table customer
CREATE TABLE Customer 
(
ID INT PRIMARY KEY,
NAME VARCHAR(30),
AGE INT,
ADDRESS VARCHAR(60),
SALARY FLOAT
);

INSERT INTO customer VALUES
(1, 'Ramesh', 32, 'Ahmdebad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23 , 'Kota', 2000.00),
(4,'Chaitali', 25, 'Mumbai', 6500.00),
(5,'Hardik', 27, 'Bhopal', 8500.00),
(6,'Komal', 22, 'MP', 4500),
(7,'Muffy', 24, 'Indore', 10000)

select * from customer;

//Customers who live in address which has letter o
SELECT NAME, ADDRESS
FROM customer
WHERE ADDRESS LIKE '%o%'

//Creating orders table
CREATE TABLE orders 
(
OID INT PRIMARY KEY,
DATE DATETIME,
CUSTOMER_ID INT,
AMOUNT FLOAT,
);

INSERT INTO orders VALUES
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560),
(103, '2008-05-20 00:00:00', 4, 2060)

select * from orders;

//Same date order 
SELECT DATE, COUNT(DISTINCT OID) AS CountOfCustomers
FROM orders
GROUP BY DATE;

//Creating Employee table
CREATE TABLE Employee 
(
ID INT PRIMARY KEY,
NAME VARCHAR(30),
AGE INT,
ADDRESS VARCHAR(60),
SALARY FLOAT
);

INSERT INTO Employee VALUES
(1, 'Ramesh', 32, 'Ahmdebad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23 , 'Kota', 2000.00),
(4,'Chaitali', 25, 'Mumbai', 6500.00),
(5,'Hardik', 27, 'Bhopal', 8500.00),
(6,'Komal', 22, 'MP', NULL),
(7,'Muffy', 24, 'Indore', NULL)

select * from Employee;

//Employee names in lowercase
SELECT LOWER(NAME) AS NameInLowerCase
FROM Employee
WHERE SALARY IS NULL

//Creating table Studentdetails
CREATE TABLE Studentdetails 
(
RegisterNo INT PRIMARY KEY,
Name VARCHAR(30),
Age INT,
Qualification VARCHAR(50),
MobileNo VARCHAR(15),
Mail_id VARCHAR(30),
Location VARCHAR(255),
Gender CHAR(1)
);

INSERT INTO Studentdetails VALUES 
(2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi',  22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha',  25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'SaiSaran',  21, 'B.A', '7890345678', 'saran@gmail.com', 'Madurai', 'F'),
(7, 'Tom',  23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune', 'M')
 
//Displaying count of employees by gender
SELECT Gender, COUNT(*) AS CountOfEmployees
FROM Studentdetails
GROUP BY Gender

