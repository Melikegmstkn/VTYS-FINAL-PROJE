USE [finalproje22]
GO
/****** Object:  StoredProcedure [dbo].[sp_cokSatanUrunler]    Script Date: 11.01.2021 23:51:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_cokSatanUrunler]
AS
BEGIN
    
    select sum(urunAdet) AS Adet,urunAdı
    from SatisListesis
    group by urunAdı
    
END