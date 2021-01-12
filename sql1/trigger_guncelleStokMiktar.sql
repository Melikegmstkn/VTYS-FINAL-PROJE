CREATE TRIGGER trigger_guncelle
on SatisListesis
after insert as
begin 
declare @barkodNo int
declare @yenimiktar int
declare @miktar int
select @barkodNo=barkodNo, @miktar=urunAdet from inserted
update Stoks set urunMiktar=urunMiktar-(@miktar) where barkodNo=@barkodNo

end