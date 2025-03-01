create database AssignmentOne

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
SELECT * FROM EMP
WHERE ename LIKE 'A%';

//Question2
SELECT * FROM EMP
WHERE mgr_id IS NULL;

//Question3
SELECT ename, empno, sal FROM EMP
WHERE SAL BETWEEN 1200 AND 1400;

//Question4
//Before pay rise
SELECT empno, ename, sal FROM EMP 
WHERE deptno = 20;

UPDATE EMP SET sal = sal*1.10 
WHERE deptno = 20;

//After pay rise
SELECT empno, ename, sal FROM EMP 
WHERE deptno = 20;

//Question5
SELECT COUNT(*) AS CountOfClerks FROM EMP 
WHERE job = 'CLERK'

//Question6
SELECT job, AVG(sal) AS AvgSalary, COUNT(*) AS CountOfEmployees 
FROM EMP 
GROUP BY job;

//Question7
//Lowest
SELECT * FROM EMP 
WHERE sal = (SELECT MIN(sal) FROM EMP);

//Highest
SELECT * FROM EMP 
WHERE sal = (SELECT MAX(sal) FROM EMP);

//Question8
SELECT * FROM DEPT 
WHERE deptno NOT IN (SELECT DISTINCT deptno FROM EMP);

//Question9
SELECT ename, sal FROM EMP
WHERE job = 'ANALYST' AND sal > 1200 AND deptno = 20
ORDER BY ename ASC;

//Question10
SELECT d.dname, d.deptno, SUM(e.sal) AS TotalSalary
FROM DEPT d
LEFT JOIN EMP e ON d.deptno = e.deptno
GROUP BY d.dname, d.deptno;

//Question11
SELECT ename, sal FROM EMP 
WHERE ename IN ('MILLER', 'SMITH');

//Question12
SELECT empno, ename FROM EMP
WHERE ename LIKE 'A%' OR ename LIKE 'M%';

//Question13
SELECT empno, ename, sal*12 AS YearlySalary FROM EMP
WHERE ename = 'SMITH';

//Question14
SELECT ename, sal FROM EMP
WHERE SAL NOT BETWEEN 1500 AND 2850;

//Question15
SELECT e1.ename, COUNT(e2.empno) AS NumberOfReports
FROM EMP e1
JOIN EMP e2 ON e1.empno = e2.mgr_id
GROUP BY e1.ename
HAVING COUNT(e2.empno) > 2;