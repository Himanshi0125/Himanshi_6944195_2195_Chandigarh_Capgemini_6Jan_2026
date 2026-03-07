-- create database insurancedb;
-- GO
-- use insurancedb
-- GO

-- create table address_details(
--     address_id int primary key,
--     h_no varchar(6),
--     city varchar(50),
--     addressline1 varchar(50),
--     state varchar(50),
--     pin varchar(50)
-- );
-- create table user_details(
--     user_id int primary key,
--     firstname varchar(50),
--     lastname varchar(50),
--     email varchar(50),
--     mobileno varchar(50),
--     address_id int references address_details(address_id),
--     dob date
-- );
-- create table ref_policy_types(
--     policy_type_code varchar(10) primary key,
--     policy_type_name varchar(50)
-- );
-- create table policy_sub_types(
--     policy_type_id varchar(10) primary key,
--     policy_type_code varchar(10) references ref_policy_types(policy_type_code),
--     description varchar(50),
--     yearsofpayements int,
--     amount float,
--     maturityperiod int,
--     maturityamount float,
--     validity int
-- );
-- create table user_policies(
--     policy_no varchar(20) primary key,
--     user_id int references user_details(user_id),
--     date_registered date,
--     policy_type_id varchar(10) references policy_sub_types(policy_type_id) 
-- );
-- create table policy_payments(
--     receipno int primary key,
--     user_id int references user_details(user_id),
--     policy_no varchar(20) references user_policies(policy_no),
--     dateofpayment DATETIME,
--     amount float,
--     fine float
-- );


-- insert into address_details values(1,'6-21','hyderabad','kphb','andhrapradesh',1254);
-- insert into address_details values(2,'7-81','chennai','seruseri','tamilnadu',16354);
-- insert into address_details values(3,'3-71','lucknow','street','uttarpradesh',86451);
-- insert into address_details values(4,'4-81','mumbai','iroli','maharashtra',51246);
-- insert into address_details values(5,'5-81','bangalore','mgroad','karnataka',125465);
-- insert into address_details values(6,'6-81','ahamadabad','street2','gujarat',125423);
-- insert into address_details values(7,'9-21','chennai','sholinganur','tamilnadu',654286);
-- insert into user_details values(1111,'raju','reddy','raju@gmail.com','9854261456',4,'1986-4-11');
-- insert into user_details values(2222,'vamsi','krishna','vamsi@gmail.com','9854261463',1,'1990-4-11');
-- insert into user_details values(3333,'naveen','reddy','naveen@gmail.com','9854261496',4,'1985-3-14');
-- insert into user_details values(4444,'raghava','rao','raghava@gmail.com','9854261412',4,'1985-9-21');
-- insert into user_details values(5555,'harsha','vardhan','harsha@gmail.com','9854261445',4,'1992-10-11');
-- insert into ref_policy_types values('58934','car');
-- insert into ref_policy_types values('58539','home');
-- insert into ref_policy_types values('58683','life');
-- insert into policy_sub_types values('6893','58934','theft',1,5000,null,200000,1);
-- insert into policy_sub_types values('6894','58934','accident',1,20000,null,200000,3);
-- insert into policy_sub_types values('6895','58539','fire',1,50000,null,500000,3);
-- insert into policy_sub_types values('6896','58683','anandhlife',7,50000,15,1500000,null);
-- insert into policy_sub_types values('6897','58683','sukhlife',10,5000,13,300000,null);
-- insert into user_policies values('689314',1111,'1994-4-18','6896');
-- insert into user_policies values('689316',1111,'2012-5-18','6895');
-- insert into user_policies values('689317',1111,'2012-6-20','6894');
-- insert into user_policies values('689318',2222,'2012-6-21','6894');
-- insert into user_policies values('689320',3333,'2012-6-18','6894');
-- insert into user_policies values('689420',4444,'2012-4-09','6896');
-- insert into policy_payments values(121,4444,'689420','2012-4-09',50000,null);
-- insert into policy_payments values(345,4444,'689420','2013-4-09',50000,null);
-- insert into policy_payments values(300,1111,'689317','2012-6-20',20000,null);
-- insert into policy_payments values(225,1111,'689316','2012-5-18',20000,null);
-- insert into policy_payments values(227,1111,'689314','1994-4-18',50000,null);
-- insert into policy_payments values(100,1111,'689314','1995-4-10',50000,null);
-- insert into policy_payments values(128,1111,'689314','1996-4-11',50000,null);
-- insert into policy_payments values(96,1111,'689314','1997-4-18',50000,200);
-- insert into policy_payments values(101,1111,'689314','1998-4-09',50000,null);
-- insert into policy_payments values(105,1111,'689314','1999-4-08',50000,null);
-- insert into policy_payments values(120,1111,'689314','2000-4-05',50000,null);
-- insert into policy_payments values(367,2222,'689318','2012-6-21',20000,null);
-- insert into policy_payments values(298,3333,'689320','2012-6-18',20000,null);


-- 1
SELECT pst.policy_type_id, rpt.policy_type_name, pst.description
FROM policy_sub_types pst
JOIN ref_policy_types rpt 
ON pst.policy_type_code = rpt.policy_type_code
WHERE rpt.policy_type_name = 'car';

-- 2
SELECT policy_type_code, COUNT(*) AS NO_OF_POLICIES
FROM policy_sub_types
GROUP BY policy_type_code;


-- 3
SELECT u.user_id, u.firstname, u.lastname, u.email, u.mobileno
FROM user_details u
JOIN address_details a ON u.address_id = a.address_id
WHERE a.city = 'chennai';


-- 4
SELECT DISTINCT u.user_id, u.firstname + ' ' + u.lastname AS USER_NAME, u.email, u.mobileno
FROM user_details u
JOIN user_policies up ON u.user_id = up.user_id
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt ON pst.policy_type_code = rpt.policy_type_code
WHERE rpt.policy_type_name = 'car';

-- 5
SELECT DISTINCT u.user_id, u.firstname, u.lastname
FROM user_details u
JOIN user_policies up ON u.user_id = up.user_id
JOIN policy_sub_types pst ON up.policy_type_id = pst.policy_type_id
JOIN ref_policy_types rpt ON pst.policy_type_code = rpt.policy_type_code
WHERE rpt.policy_type_name = 'car'
AND u.user_id NOT IN (
    SELECT u2.user_id FROM user_details u2
    JOIN user_policies up2 ON u2.user_id = up2.user_id
    JOIN policy_sub_types pst2 ON up2.policy_type_id = pst2.policy_type_id
    JOIN ref_policy_types rpt2 ON pst2.policy_type_code = rpt2.policy_type_code
    WHERE rpt2.policy_type_name = 'home'
);
