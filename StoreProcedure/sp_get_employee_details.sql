CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_get_employee_details`(
in employeeId int
)
BEGIN

SELECT  ID,
   FirstName,
   LastName,
   Gender,
   Salary
FROM  Employees 
where  ID = employeeId;

select ID,
	UserID,
    `Type`,
    `Value`
    from contactinfo 
where UserID = employeeId;

END