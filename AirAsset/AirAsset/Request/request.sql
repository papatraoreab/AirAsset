select * from Moyens
select * from Exemplaires
select * from Files
select * from AspNetRoles -- roles
select * from AspNetUsers --users
select * from AspNetUserClaims
select * from AspNetUserLogins
select * from AspNetUserRoles -- users role
select * from __MigrationHistory
select* from Exemplaries
select* from Assets

truncate table  Assets

-- select 

select moyenCODE, exemplaireCODE from exemplaires,moyens 

truncate table __MigrationHistory

delete from __MigrationHistory where MigrationId='parameter here'

/*
truncate table Moyens => impossible
delete from Moyens
select * from Moyens

DBCC CHECKIDENT (Moyens, RESEED,0)

truncate table Exemplaires
delete from Exemplaires

truncate table Exemplaries
*/

/*
drop table EntrepotLignes
drop table EntrepotLignes
drop table Moyens
delete from Moyens
drop table Exemplaires
drop table Exemplaries
drop table Programmes
drop table Files
drop table AspNetRoles
drop table AspNetUsers
drop table AspNetUserClaims
drop table AspNetUserLogins
drop table AspNetUserRoles
drop table __MigrationHistory
*/	

/*
update Exemplaires set moyenCODE ='XXY000-1' where exemplaireID=1

update Moyens set type='Ferrure' where moyenID=2

select* from AspNetUsers
update AspNetUsers set UserName ='username' where Id='id'
truncate table AspNetUsers=> impossible
delete from AspNetUsers
select MAX(id) from AspNetUsers

*/


drop table Secteurs

select quantite, designation from Exemplaires where exemplaireCODE='AL1006'

select * from TypeMoyens

insert into Localisations values ('K33')
truncate table Secteurs

select * from Files