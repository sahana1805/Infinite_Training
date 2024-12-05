create database AssignmentFour

//Question 1 - Factorial

DECLARE @InputNum INT = 11;
DECLARE @Factorial INT = 1;
DECLARE @Counter INT = 1;

WHILE @Counter <= @InputNum
BEGIN
SET @Factorial = @Factorial * @Counter;
SET @Counter = @Counter + 1;
END

PRINT 'Factorial of ' + CAST(@InputNum AS VARCHAR(20)) + ': ' + CAST(@Factorial AS VARCHAR(20));

//Question 2 - Multiplication Table

CREATE OR ALTER PROC MultiplicationTable
@num INT
AS
BEGIN
DECLARE @multiplier INT = 1;
DECLARE @product INT;

WHILE @multiplier <= 10
BEGIN
SET @product = @num * @multiplier;
PRINT CONCAT(@num, ' * ', @multiplier, ' = ', @product);
SET @multiplier = @multiplier + 1;
END
END;

EXEC MultiplicationTable @num = 17;

//Question 3 - Status of Student

CREATE TABLE students 
(
Sid INT PRIMARY KEY,
Sname VARCHAR(50)
);
 
INSERT INTO students VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');
 
CREATE TABLE marks 
(
Mid INT PRIMARY KEY,
Sid INT,
Score INT,
FOREIGN KEY (Sid) REFERENCES students(Sid)
);
 
INSERT INTO marks VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

CREATE FUNCTION GetStatus(@score INT)
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @Status VARCHAR(10); 
IF @score >= 50 
SET @Status = 'Pass';
ELSE
SET @Status = 'Fail'; 
RETURN @Status; 
END; 

SELECT s.Sid, s.Sname, m.Score, dbo.GetStatus (m.Score) AS Status
FROM 
students s
JOIN 
marks m
ON 
s.Sid = m.Sid
ORDER BY 
s.Sid; 
