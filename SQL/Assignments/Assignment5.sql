create database AssignmentFive

//Question 1 - Generate PaySlip

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
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

CREATE OR ALTER PROCEDURE PaySlip @empId INT
AS
BEGIN
DECLARE @Salary FLOAT
DECLARE @HRA FLOAT
DECLARE @DA FLOAT
DECLARE @PF FLOAT
DECLARE @IT FLOAT
DECLARE @Deductions FLOAT
DECLARE @GrossSalary FLOAT
DECLARE @NetSalary FLOAT

SELECT @Salary = sal
FROM EMP
WHERE empno = @empId

SET @HRA = @Salary * 0.10
SET @DA = @Salary * 0.20
SET @PF = @Salary * 0.08
SET @IT = @Salary * 0.05
   
SET @Deductions = @PF + @IT
SET @GrossSalary = @Salary + @HRA + @DA
SET @NetSalary = @GrossSalary - @Deductions

PRINT 'Employee Payslip for Employee: ' + CAST(@empId AS VARCHAR(10))
PRINT 'Basic Salary: ' + CAST(@Salary AS VARCHAR(20))
PRINT 'HRA: ' + CAST(@HRA AS VARCHAR(20))
PRINT 'DA: ' + CAST(@DA AS VARCHAR(20))
PRINT 'PF: ' + CAST(@PF AS VARCHAR(20))
PRINT 'IT: ' + CAST(@IT AS VARCHAR(20))
PRINT 'Total Deductions: ' + CAST(@Deductions AS VARCHAR(20))
PRINT 'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR(20))
PRINT 'Net Salary: ' + CAST(@NetSalary AS VARCHAR(20))
END


EXEC PaySlip @empId = 7788;

//Question 2 - General Holidays

CREATE TABLE Holiday 
(
holiday_date DATE PRIMARY KEY,
Holiday_name VARCHAR(100)
);

INSERT INTO Holiday VALUES 
('2025-01-01', 'New Year'),
('2025-05-01', 'Labour Day'),
('2025-10-21', 'Diwali'),
('2025-12-25', 'Christmas')
    
CREATE OR ALTER TRIGGER RestrictDMOnHolidays
ON EMP
INSTEAD OF INSERT, UPDATE, DELETE
AS
BEGIN
DECLARE @IsHoliday BIT;
DECLARE @HolidayName VARCHAR(100);

SELECT TOP 1 @HolidayName = Holiday_name
FROM Holiday
WHERE holiday_date = CONVERT(DATE, GETDATE());

IF @HolidayName IS NOT NULL
BEGIN
RAISERROR('Due to %s, you cannot manipulate data', 16, 1, @HolidayName);
END

ELSE
BEGIN
PRINT 'Data manipulation is allowed on non-holiday dates';

UPDATE Emp SET ename = 'SAM' WHERE ename = 'SMITH';
END

END;
SELECT * FROM EMP;