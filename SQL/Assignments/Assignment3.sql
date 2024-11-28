create database AssignmentThree

CREATE TABLE DEPT 
(
deptno INT PRIMARY KEY,
dname VARCHAR(50),
loc VARCHAR(50)
);


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

INSERT INTO DEPT VALUES 
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

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

SELECT * FROM DEPT;

SELECT * FROM EMP;

//Question1
SELECT empno, ename FROM EMP 
WHERE job = 'MANAGER';

//Question2
SELECT ename, sal FROM EMP
WHERE sal > 1000;

//Question3
SELECT ename, sal FROM EMP
WHERE ename != 'JAMES';

//Question4
SELECT * FROM EMP
WHERE ename LIKE 'S%';

//Question5
SELECT * FROM EMP
WHERE ename LIKE '%A%';

//Question6
SELECT * FROM EMP
WHERE ename LIKE '__L%';

//Question7
SELECT ename, sal, sal/30 AS DailySalary FROM EMP
WHERE ename = 'JONES';

//Question8
SELECT SUM(sal) as TotalMonthlySalary FROM EMP;

//Question9
SELECT AVG(sal*12) as AvgAnnualSalary FROM EMP;

//Question10
SELECT ename, job, sal, deptno FROM EMP 
WHERE deptno = 30 AND job != 'SALESMAN';

//Question11
SELECT DISTINCT deptno FROM EMP;

//Question12
SELECT ename AS Employee, sal AS MonthlySalary FROM EMP
WHERE sal > 1500 AND (deptno = 10 OR deptno = 30);

//Question13
SELECT ename, job, sal FROM EMP 
WHERE (job = 'MANAGER' OR job = 'ANALYST') AND sal NOT IN (1000, 3000, 5000);

//Question14
SELECT ename, sal, comm FROM EMP 
WHERE comm > sal * 1.10;

//Question15
SELECT ename FROM EMP 
WHERE ename LIKE '%L%L%' AND (deptno = 30 OR mgr_id = 7782);

//Question16
//Employees with experience >30 & <40 years
SELECT ename FROM EMP 
WHERE DATEDIFF(yy, hiredate, GETDATE()) BETWEEN 31 AND 39;

//Count of employees
SELECT COUNT(*) AS CountOfEmployees FROM EMP 
WHERE DATEDIFF(yy, hiredate, GETDATE()) BETWEEN 31 AND 39;

//Question17
SELECT d.dname, e.ename FROM DEPT d 
JOIN EMP e ON d.deptno = e.deptno 
ORDER BY d.dname ASC, e.ename DESC;

//Question18
SELECT ename,
DATEDIFF(YEAR, HIREDATE, GETDATE()) AS YearsOfExperience
FROM EMP
WHERE ename = 'MILLER';
