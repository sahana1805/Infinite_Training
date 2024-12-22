CREATE DATABASE RailwayDB;

use RailwayDB;

--Trains Table
CREATE TABLE Trains 
(
TrainNo INT PRIMARY KEY,
TrainName VARCHAR(100) NOT NULL,
Origin VARCHAR(100) NOT NULL,
Destination VARCHAR(100) NOT NULL,
Status VARCHAR(10) NOT NULL,
IsDeleted BIT NOT NULL DEFAULT 0
);

--Procedure to insert data into Trains table
CREATE OR ALTER PROCEDURE AddTrain
@TrainNo INT,
@TrainName VARCHAR(100),
@Origin VARCHAR(100),
@Destination VARCHAR(100),
@Status VARCHAR(10)
AS
BEGIN
INSERT INTO Trains(TrainNo, TrainName, Origin, Destination, Status)
VALUES (@TrainNo, @TrainName, @Origin, @Destination, @Status);
END;

--TrainClass Table
CREATE TABLE TrainClass
(
ClassID INT PRIMARY KEY IDENTITY(45,15),
TrainNo INT, 
ClassType VARCHAR(20) NOT NULL, -- First/Second/Sleeper
TotalBerths INT NOT NULL,
AvailableBerths INT NOT NULL,
FOREIGN KEY (TrainNo) REFERENCES Trains(TrainNo)
);

--Procedure to insert data into TrainClass table
CREATE OR ALTER PROCEDURE AddTrainClass
@TrainNo INT,
@ClassType VARCHAR(20),
@TotalBerths INT,
@AvailableBerths INT
AS
BEGIN
INSERT INTO TrainClass(TrainNo, ClassType, TotalBerths, AvailableBerths)
VALUES (@TrainNo, @ClassType, @TotalBerths, @AvailableBerths);
END;

--Bookings Table
CREATE TABLE Bookings 
(
BookingID INT PRIMARY KEY IDENTITY(1,1),
UserID VARCHAR(10),
TrainNo INT,
ClassID INT,
BerthsBooked INT,
BookingDate DATETIME DEFAULT GETDATE(),
Status VARCHAR(20) DEFAULT 'Booked',
FOREIGN KEY (UserID) REFERENCES Users(UserID),
FOREIGN KEY (TrainNo) REFERENCES Trains(TrainNo),
FOREIGN KEY (ClassID) REFERENCES TrainClass(ClassID)
);

--Procedure to insert data into Bookings table
CREATE OR ALTER PROCEDURE Booking
@UserID VARCHAR(10),
@TrainNo INT,
@ClassID INT,
@BerthsBooked INT,
@BookingDate DATETIME
AS
BEGIN
INSERT INTO Bookings(UserID, TrainNo, ClassID, BerthsBooked, BookingDate)
VALUES (@UserID, @TrainNo, @ClassID, @BerthsBooked, @BookingDate);
END;

--Admin Table
CREATE TABLE Admins
(
AdminID VARCHAR(10) PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Password VARCHAR(20) NOT NULL
);

INSERT INTO Admins VALUES
('Admin123', 'Admin', 'p@ssword');

--User Table
CREATE TABLE Users
(
UserID VARCHAR(10) PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Password VARCHAR(20) NOT NULL
);

--Commands
SELECT * FROM Trains;
SELECT * FROM TrainClass;

--Bookings Table
--SELECT * FROM BOOKINGS;
SELECT b.BookingID, u.Name, tc.TrainNo, tc.classtype, b.BerthsBooked, b.Status, b.BookingDate from Bookings b, Users u, TrainClass tc where b.UserID=u.UserID AND b.ClassID = tc.ClassID;

SELECT * FROM Admins;
SELECT * FROM Users;

--DROP PROCEDURE AddTrain;
--DROP PROCEDURE AddTrainClass;
--DROP PROCEDURE Booking;
--DROP TABLE Trains;
--DROP TABLE TrainClass;
--DROP TABLE Bookings;
--DROP TABLE Admins;
--DROP TABLE Users;









