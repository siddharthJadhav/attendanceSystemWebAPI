CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_add_employee`(
in employee_in json,
in contact_info_in json
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

if ( employeeID != 0 and json_length(contact_info_in) > 0  ) then 

set @counter = 0;

while  json_length(contact_info_in) > @counter do

set @contactInfo = JSON_UNQUOTE(JSON_EXTRACT(contact_info_in, concat( '$[', @counter , ']')));

insert into `ContactInfo` (
    `UserID`,
    `Type`,
    `Value`
) values (
	employeeID,
	JSON_UNQUOTE(JSON_EXTRACT(@contactInfo, '$."Type"')),
	JSON_UNQUOTE(JSON_EXTRACT(@contactInfo, '$."Value"'))
);

set @counter = @counter + 1;

end while;

end if;

select employeeID;

END