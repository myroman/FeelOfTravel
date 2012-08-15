SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_ChangeAboutPageContent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_ChangeAboutPageContent]
GO

CREATE PROCEDURE sp_ChangeAboutPageContent
	@NewContentText varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from dbo.tbAboutPage
    insert into dbo.tbAboutPage ([text]) values(@NewContentText)
END
GO
