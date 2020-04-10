CREATE PROCEDURE [tests].[CheckIdentityColumns]
AS
	DECLARE @TblPrimaryKeyIsIdentity TABLE
	(
		[IndexName] NVARCHAR(128) NOT NULL,
		[TableName] NVARCHAR(128) NOT NULL,
		[ColumnName] NVARCHAR(128) NOT NULL,
		[identity] BIT NOT NULL,
		[Msg] VARCHAR(24) NULL
	);

	BEGIN

		INSERT @TblPrimaryKeyIsIdentity
		(
			IndexName,
			TableName,
			ColumnName,
			[identity],
			Msg
		)
		SELECT i.name AS IndexName,
			   OBJECT_NAME(ic.object_id) AS TableName,
			   COL_NAME(ic.object_id, ic.column_id) AS ColumnName,
			   (
				   SELECT  is_identity
				   FROM sys.columns c
					   INNER JOIN sys.tables t
						   ON c.object_id = t.object_id
				   WHERE c.name = COL_NAME(ic.object_id, ic.column_id)
						 AND t.name = OBJECT_NAME(ic.object_id)
			   ) AS 'identity',
			   'Primary Key Not Identity' AS Msg
		FROM sys.indexes AS i
			INNER JOIN sys.index_columns AS ic
				ON i.object_id = ic.object_id
				   AND i.index_id = ic.index_id
		WHERE i.is_primary_key = 1
			  AND OBJECT_NAME(ic.object_id) <> '__RefactorLog'
		ORDER BY OBJECT_NAME(ic.object_id);
	END;

	SELECT IndexName,
		   TableName,
		   ColumnName,
		   [identity],
		   Msg
	FROM @TblPrimaryKeyIsIdentity WHERE [identity] <> 1; 


RETURN 0
