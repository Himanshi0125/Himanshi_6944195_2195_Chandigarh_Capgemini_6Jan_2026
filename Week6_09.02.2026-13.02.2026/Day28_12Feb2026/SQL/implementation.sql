-- Create database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'sales_db') CREATE DATABASE sales_db;
GO
USE sales_db;
GO

-- Create SALESPEOPLE table
CREATE TABLE SALESPEOPLE (
    SNUM INT PRIMARY KEY,
    SNAME VARCHAR(50),
    CITY VARCHAR(50),
    COMM DECIMAL(5,2)
);

-- Insert data into SALESPEOPLE
INSERT INTO SALESPEOPLE VALUES
(1001, 'Peel', 'London', 12.00),
(1002, 'Serres', 'San Jose', 13.00),
(1004, 'Motika', 'London', 11.00),
(1007, 'Rafkin', 'Barcelona', 15.00),
(1003, 'Axelrod', 'New york', 1.00);

-- Create CUST table
CREATE TABLE CUST (
    CNUM INT PRIMARY KEY,
    CNAME VARCHAR(50),
    CITY VARCHAR(50),
    RATING INT,
    SNUM INT
);

-- Insert data into CUST
INSERT INTO CUST VALUES
(2001, 'Hoffman', 'London', 100, 1001),
(2002, 'Giovanne', 'Rome', 200, 1003),
(2003, 'Liu', 'San Jose', 300, 1002),
(2004, 'Grass', 'Brelin', 100, 1002),
(2006, 'Clemens', 'London', 300, 1007),
(2007, 'Pereira', 'Rome', 100, 1004);

-- Create ORDERS table
CREATE TABLE ORDERS (
    ONUM INT PRIMARY KEY,
    AMT DECIMAL(10,2),
    ODATE DATE,
    CNUM INT,
    SNUM INT
);

-- Insert data into ORDERS
INSERT INTO ORDERS VALUES
(3001, 18.69, '1994-10-03', 2008, 1007),
(3003, 767.19, '1994-10-03', 2001, 1001),
(3002, 1900.10, '1994-10-03', 2007, 1004),
(3005, 5160.45, '1994-10-03', 2003, 1002),
(3006, 1098.16, '1994-10-04', 2008, 1007),
(3009, 1713.23, '1994-10-04', 2002, 1003),
(3007, 75.75, '1994-10-05', 2004, 1002),
(3008, 4723.00, '1994-10-05', 2006, 1001),
(3010, 1309.95, '1994-10-06', 2004, 1002),
(3011, 9891.88, '1994-10-06', 2006, 1001);

-- Queries

-- 1. Display snum,sname,city and comm of all salespeople.
SELECT SNUM, SNAME, CITY, COMM FROM SALESPEOPLE;

-- 2. Display all snum without duplicates from all orders.
SELECT DISTINCT SNUM FROM ORDERS;

-- 3. Display names and commissions of all salespeople in london.
SELECT SNAME, COMM FROM SALESPEOPLE WHERE CITY = 'London';

-- 4. All customers with rating of 100.
SELECT * FROM CUST WHERE RATING = 100;

-- 5. Produce orderno, amount and date form all rows in the order table.
SELECT ONUM, AMT, ODATE FROM ORDERS;

-- 6. All customers in San Jose, who have rating more than 200.
SELECT * FROM CUST WHERE CITY = 'San Jose' AND RATING > 200;

-- 7. All customers who were either located in San Jose or had a rating above 200.
SELECT * FROM CUST WHERE CITY = 'San Jose' OR RATING > 200;

-- 8. All orders for more than $1000.
SELECT * FROM ORDERS WHERE AMT > 1000;

-- 9. Names and citires of all salespeople in london with commission above 0.10.
SELECT SNAME, CITY FROM SALESPEOPLE WHERE CITY = 'London' AND COMM > 10.00;

-- 10. All customers excluding those with rating <= 100 unless they are located in Rome.
SELECT * FROM CUST WHERE RATING > 100 OR CITY = 'Rome';

-- 11. All salespeople either in Barcelona or in london.
SELECT * FROM SALESPEOPLE WHERE CITY IN ('Barcelona', 'London');

-- 12. All salespeople with commission between 0.10 and 0.12. (Boundary values should be excluded)
SELECT * FROM SALESPEOPLE WHERE COMM > 10.00 AND COMM < 12.00;