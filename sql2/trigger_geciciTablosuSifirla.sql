CREATE TRIGGER tabloSifirla
on Satists
after insert as
begin 
TRUNCATE TABLE gecicis

end