/*********************
* saveAuthors
*********************/
declare @sql nvarchar(max)
if Exists (select * from sys.objects where object_id = object_id(N'[dbo].[saveAuthors]') and OBJECTPROPERTY(object_id, N'IsProcedure') = 1)
BEGIN
  set @sql = 'ALTER 'END
ELSE
BEGIN 
  set @sql = 'CREATE '
END
set @sql = @sql + N' PROCEDURE [dbo].[saveAuthors]
  (
		@firstname nvarchar(50),
		@lastname nvarchar(50),
		@changedAt datetime2,
		@changedBy nvarchar(50),
		@createdAt datetime2,
		@createdBy nvarchar(50),
		@id int  )
AS
  SET NOCount ON
IF @id > 0
  BEGIN

    UPDATE [dbo].[Authors]
    SET
		[Firstname] = @firstname,
		[Lastname] = @lastname,
		[ChangedAt] = @changedAt,
		[ChangedBy] = @changedBy,
		[CreatedAt] = @createdAt,
		[CreatedBy] = @createdBy	  WHERE Id = @id

    SELECT @id

  END
  ELSE
  BEGIN

    INSERT INTO [dbo].[Authors]
    (
[Firstname],
[Lastname],
[ChangedAt],
[ChangedBy],
[CreatedAt],
[CreatedBy]
    )
    VALUES
    (
@firstname,
@lastname,
@changedAt,
@changedBy,
@createdAt,
@createdBy    )
SELECT SCOPE_IDENTITY()
  END
'
exec(@sql)
GO
GRANT  EXECUTE  ON dbo.saveAuthors TO [FRONTEND]
GO
