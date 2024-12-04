create database Assessment

CREATE TABLE DEPT 
(
deptno INT PRIMARY KEY,
dname VARCHAR(50),
loc VARCHAR(50)
);

INSERT INTO DEPT VALUES 
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

SELECT * FROM DEPT;

CREATE TABLE EMP 
(
empno INT PRIMARY KEY,
ename VARCHAR(50),
job VARCHAR(50),
mgr_id INT,
hiredate DATE,
sal DECIMAL(10, 2),
comm DECIMAL(10, 2),
deptno INT,
FOREIGN KEY (deptno) REFERENCES DEPT(deptno),
);

INSERT INTO EMP VALUES 
(7369, 'SMITH', 'CLERK', 7902, '2023-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '2023-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '2019-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '2020-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '2012-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '2021-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '2022-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '2019-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '2019-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '2017-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '2024-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '2019-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '2014-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '2016-01-23', 1300, NULL, 10);

SELECT * FROM EMP;

//Display birthday
SELECT DATENAME(WEEKDAY, '2000-05-18') AS DayOfBirth

//Age in days
SELECT DATEDIFF(DAY, '2000-05-18', GETDATE()) AS AgeInDays

//Employees who joined 5 years back
SELECT * FROM EMP
WHERE HIREDATE < DATEADD(YEAR, -5, GETDATE())

//Procedure
CREATE OR ALTER PROCEDURE UpdateSalary
AS
BEGIN
UPDATE EMP
SET sal = sal + 500
WHERE deptno = 30 AND sal < 1500;
END;

exec UpdateSalary;

SELECT * FROM EMP;

//Transaction

BEGIN TRANSACTION; 

CREATE TABLE Employee 
(
empno INT PRIMARY KEY,
ename VARCHAR(50),
sal DECIMAL(10, 2),
doj DATE
);

//Insert 3 rows
INSERT INTO Employee VALUES
(1, 'Chuck', 5000, '2012-06-18'),
(2, 'Serena', 7000, '2014-02-05'),
(3, 'Lily', 9000, '2019-08-02');

SELECT * FROM Employee;

//Update 2nd row salary
UPDATE Employee
SET sal = sal * 1.15
WHERE empno = 2;

SELECT * FROM Employee

//Delete first row
BEGIN TRANSACTION;

DELETE FROM Employee
WHERE empno = 1;

ROLLBACK;

SELECT * FROM Employee

//Function
CREATE FUNCTION CalculateBonus (@DeptNo INT, @Salary DECIMAL(10, 2))
RETURNS DECIMAL(10, 2)
AS
BEGIN
DECLARE @Bonus DECIMAL(10, 2);
IF @DeptNo = 10
SET @Bonus = @Salary * 0.15;
ELSE IF @DeptNo = 20
SET @Bonus = @Salary * 0.20;
ELSE
SET @Bonus = @Salary * 0.05;
RETURN @Bonus;
END;

//Dept10 bonus
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM EMP
WHERE deptno = 10;

//Dept20 bonus
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM EMP
WHERE deptno = 20;

//Other employee bonus
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM EMP
WHERE deptno NOT IN (10, 20);


