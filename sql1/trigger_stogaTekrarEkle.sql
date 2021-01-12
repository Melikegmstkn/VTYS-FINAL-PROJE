CREATE TRIGGER trigger_sildigindeekler
on SatisListesis
after delete as
begin 
declare @barkodNo int
declare @yenimiktar int
declare @miktar int
select @barkodNo=barkodNo, @miktar=urunAdet from deleted
update Stoks set urunMiktar=urunMiktar+(@miktar) where barkodNo=@barkodNo

end