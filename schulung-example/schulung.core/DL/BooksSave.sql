/*********************
* saveBooks
*********************/
declare @sql nvarchar(max)
if Exists (select * from sys.objects where object_id = object_id(N'[dbo].[saveBooks]') and OBJECTPROPERTY(object_id, N'IsProcedure') = 1)
BEGIN
  set @sql = 'ALTER 'END
ELSE
BEGIN 
  set @sql = 'CREATE '
END
set @sql = @sql + N' PROCEDURE [dbo].[saveBooks]
  (
		@authorId int,
		@changedAt datetime2,
		@changedBy nvarchar(50),
		@createdAt datetime2,
		@createdBy nvarchar(50),
		@description nvarchar(MAX),
		@isbn nvarchar(20),
		@title nvarchar(100),
		@id int  )
AS
  SET NOCount ON
IF @id > 0
  BEGIN

    UPDATE [dbo].[Books]
    SET
		[AuthorId] = @authorId,
		[ChangedAt] = @changedAt,
		[ChangedBy] = @changedBy,
		[CreatedAt] = @createdAt,
		[CreatedBy] = @createdBy,
		[Description] = @description,
		[Isbn] = @isbn,
		[Title] = @title	  WHERE Id = @id

    SELECT @id

  END
  ELSE
  BEGIN

    INSERT INTO [dbo].[Books]
    (
[AuthorId],
[ChangedAt],
[ChangedBy],
[CreatedAt],
[CreatedBy],
[Description],
[Isbn],
[Title]
    )
    VALUES
    (
@authorId,
@changedAt,
@changedBy,
@createdAt,
@createdBy,
@description,
@isbn,
@title    )
SELECT SCOPE_IDENTITY()
  END
'
exec(@sql)
GO
GRANT  EXECUTE  ON dbo.saveBooks TO [FRONTEND]
GO
