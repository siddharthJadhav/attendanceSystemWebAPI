CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_delete_employee`(
in id_in int
)
BEGIN

delete from Employees 
where ID = id_in;

select id_in;

END