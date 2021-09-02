
----- DO -----
Declare 
@novo varchar(4) = '9876',
@id int = 48

update Regras 
set Rules = (select rules from Regras where Opereadora = @id) + ',' + @novo
where Opereadora = @id

----- UNDO -----
Declare 
@novo varchar(4) = '9876',
@id int = 48
update Regras 
set Rules = REPLACE((select rules from Regras where Opereadora =  @id), ',' + @novo, '')
where Opereadora =  @id