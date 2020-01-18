CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_add_employee`(
in employee_in json
)
BEGIN

declare employeeID int default 0;

insert into `Employees` (
	`FirstName`,
	`LastName`,
   `Gender`,
   `Salary`
) values (
	JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."FirstName"')),
    JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."LastName"')),
    JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."Gender"')),
    JSON_UNQUOTE(JSON_EXTRACT(employee_in , '$."Salary"'))
);

set employeeID = LAST_INSERT_ID();

select employeeID;

END