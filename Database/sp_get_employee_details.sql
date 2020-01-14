CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_get_employee_details`(
in employeeId int
)
BEGIN

SELECT `Employees`.`ID`,
    `Employees`.`FirstName`,
    `Employees`.`LastName`,
    `Employees`.`Gender`,
    `Employees`.`Salary`
FROM  `Employees`;


END