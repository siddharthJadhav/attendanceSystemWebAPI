CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_update_employee_detail`(
in employee_in json
)
BEGIN

declare employeeID int default 0;

update Employees set
	FirstName = JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."FirstName"')),
    LastName = JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."LastName"')),
    Gender = JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."Gender"')),
    Salary = JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."Salary"'))
where ID = JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."ID"'));

set employeeID = LAST_INSERT_ID();

select employeeID;

END