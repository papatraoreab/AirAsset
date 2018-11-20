select * from Moyens
select * from Exemplaires
select * from Files
select * from AspNetRoles -- roles
select * from AspNetUsers --users
select * from AspNetUserClaims
select * from AspNetUserLogins
select * from AspNetUserRoles -- users role
select * from __MigrationHistory



-- select 

select moyenCODE, exemplaireCODE from exemplaires,moyens 

delete from __MigrationHistory where MigrationId='parameter here'

/*
truncate table Moyens => impossible
delete from Moyens

DBCC CHECKIDENT (Moyens, RESEED,0)

truncate table Exemplaires
*/

/*
drop table Moyens
drop table Exemplaires
drop table Files
drop table AspNetRoles
drop table AspNetUserClaims
drop table AspNetUserLogins
drop table AspNetUserRoles
drop table __MigrationHistory
*/	

/*
update Exemplaires set moyenCODE ='XXY000-1' where exemplaireID=1


select* from AspNetUsers
update AspNetUsers set UserName ='username' where Id='id'
truncate table AspNetUsers=> impossible
delete from AspNetUsers
select MAX(id) from AspNetUsers

*/



select quantite, designation from Exemplaires where exemplaireCODE='AL1006'