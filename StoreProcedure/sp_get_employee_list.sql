CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_get_employee_list`(
in FirstName_in varchar(20),
in LastName_in varchar(20),
in Gender_in varchar(20),
in salary_in int,
in SalrySort_in varchar(20) 
)
BEGIN

select ID,
   FirstName,
   LastName,
   Gender,
   Salary
   from Employees
   where (length(FirstName_in)=0 or FirstName like concat('%',FirstName_in,'%'))
   And (length(LastName_in)=0 or LastName like concat('%', LastName_in, '%'))
   And (length(Gender_in)=0 or Gender like concat('%', Gender_in, '%'))
   And ((salary_in=0 or length(SalrySort_in) = 0) or
   (
        (CASE WHEN SalrySort_in = 'greaterthan' THEN Salary > salary_in END)
            OR
        (CASE WHEN SalrySort_in = 'lessthan' THEN Salary < salary_in END)
            OR
        (CASE WHEN SalrySort_in = 'equals' THEN Salary = salary_in END)
    ));

END