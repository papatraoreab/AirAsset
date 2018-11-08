select * from Moyens
select * from Exemplaires
select * from Files
select * from AspNetRoles
select * from AspNetUsers
select * from AspNetUserClaims
select * from AspNetUserLogins
select * from AspNetUserRoles
select * from __MigrationHistory

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

update AspNetUsers set UserName ='papa.traore.external@airbus.com' where Id='ab89792c-1113-4c21-bce6-2a74be29f650'
*/

