create database SQLandADO;

CREATE TABLE Coursedetails
(
C_id VARCHAR(10),
C_Name VARCHAR(25),
Start_date DATE,
End_date DATE,
Fee FLOAT
);

INSERT INTO Coursedetails VALUES
('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
('DV004', 'DataVisualization', '2018-03-01', '2018-04-15', 15000),
('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);

SELECT * FROM Coursedetails;

--Function
CREATE FUNCTION CourseDuration(@start_date DATE, @end_date DATE)
RETURNS INT
AS
BEGIN
RETURN DATEDIFF(DAY, @start_date, @end_date);
END;

SELECT dbo.CourseDuration('2018-02-01', '2018-02-28') AS DurationInDays;

CREATE TABLE T_CourseInfo 
(
C_Name VARCHAR(25),
Start_date DATE
);

--Trigger
CREATE TRIGGER DisplayDetails
ON Coursedetails
AFTER INSERT
AS
BEGIN
INSERT INTO T_CourseInfo (C_Name, Start_date)
SELECT C_Name, Start_date
FROM inserted;
END;

INSERT INTO Coursedetails VALUES
('RF201', 'DataMining', '2018-04-12', '2018-05-15', 18000);

SELECT * FROM T_CourseInfo;

--Procedure
CREATE TABLE ProductDetails
(
ProductId INT,
ProductName VARCHAR(25),
Price FLOAT,
DiscountedPrice FLOAT
);


CREATE PROCEDURE InsertProdDetails
@ProductName VARCHAR(25),
@Price FLOAT,
@GeneratedProductID INT OUTPUT,
@DiscountedPrice FLOAT OUTPUT
AS
BEGIN
SELECT @GeneratedProductID = COALESCE(MAX(ProductId), 0) + 1 FROM ProductDetails;
SET @DiscountedPrice = @Price * 0.9;
INSERT INTO ProductDetails(ProductId, ProductName, Price, DiscountedPrice)
VALUES (@GeneratedProductID, @ProductName, @Price, @DiscountedPrice);
END;

EXEC InsertProdDetails 
@ProductName = 'Fan', 
@Price = 5000,
@GeneratedProductID = @GeneratedProductID OUTPUT,
@DiscountedPrice = @DiscountedPrice OUTPUT;