-- table Exemplaires
select * from Exemplaires

-- return current Identity Value
DBCC checkident('Exemplaires', noreseed)  

-- return the current Identity Value to maximum value
DBCC checkident('Exemplaires', 4) 



-- table Moyens
select * from Moyens

-- return current Identity Value
DBCC checkident('Moyens', noreseed)  

-- return the current Identity Value to maximum value
DBCC checkident('Moyens', 4) 