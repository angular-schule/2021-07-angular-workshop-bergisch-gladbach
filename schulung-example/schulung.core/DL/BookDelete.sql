/*********************
* deleteBooks
*********************/
declare @sql nvarchar(max)
if Exists (select * from sys.objects where object_id = object_id(N'[dbo].[deleteBooks]') and OBJECTPROPERTY(object_id, N'IsProcedure') = 1)
BEGIN
  set @sql = 'ALTER '
END
ELSE
BEGIN 
  set @sql = 'CREATE '
END
set @sql = @sql + N' PROCEDURE dbo.deleteBooks
  (
    @id int
  )
AS
  SET NOCount ON
  
  DELETE FROM [dbo].[Books]
	  WHERE Id = @id
'
exec(@sql)
GO
GRANT  EXECUTE  ON dbo.deleteBooks TO [FRONTEND]
GO
