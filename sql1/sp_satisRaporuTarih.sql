USE [finalproje22]
GO
/****** Object:  StoredProcedure [dbo].[OrnekSP4]    Script Date: 11.01.2021 23:51:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[OrnekSP4]
    @tarih1 [datetime],
    @tarih2 [datetime]
AS
BEGIN
    
    Select * from Satists where tarih between @tarih1 and @tarih2
    
END