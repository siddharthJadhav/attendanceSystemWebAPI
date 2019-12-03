create database EmployeeDB;

use EmployeeDB;

Create table Employees
(
     ID int primary key auto_increment,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int
);

INSERT INTO `EmployeeDB`.`Employees` (`FirstName`, `LastName`, `Gender`, `Salary`) VALUES ('Mark', 'Hastings', 'Male', 60000);
INSERT INTO `EmployeeDB`.`Employees` (`FirstName`, `LastName`, `Gender`, `Salary`) VALUES ('Steve', 'Pound', 'Male', 45000);
INSERT INTO `EmployeeDB`.`Employees` (`FirstName`, `LastName`, `Gender`, `Salary`) VALUES ('Ben', 'Hoskins', 'Male', 70000);
INSERT INTO `EmployeeDB`.`Employees` (`FirstName`, `LastName`, `Gender`, `Salary`) VALUES ('Philip', 'Hastings', 'Male', 45000);
INSERT INTO `EmployeeDB`.`Employees` (`FirstName`, `LastName`, `Gender`, `Salary`) VALUES ('Mary', 'Lambeth', 'Female', 30000);
INSERT INTO `EmployeeDB`.`Employees` (`FirstName`, `LastName`, `Gender`, `Salary`) VALUES ('Valarie', 'Vikings', 'Female', 35000);
INSERT INTO `EmployeeDB`.`Employees` (`FirstName`, `LastName`, `Gender`, `Salary`) VALUES ('John', 'Stanmore', 'Male', 80000);

select * from Employees;


