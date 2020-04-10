CREATE PROCEDURE [tests].[CheckDefaultValues]
AS
	DECLARE @TblColHasDefaultAndIsNullable TABLE
	(
		[Table Name] NVARCHAR(128) NOT NULL,
		[Column Name] NVARCHAR(128) NOT NULL,
		[Default Value] NVARCHAR(4000) NOT NULL,
		[isnullable] INT NOT NULL
	);


	INSERT INTO @TblColHasDefaultAndIsNullable
	(
		[Table Name],
		[Column Name],
		[Default Value],
		isnullable
	)
	SELECT SO.name AS [Table Name],
		   SC.name AS [Column Name],
		   SM.text AS [Default Value],
		   SC.isnullable
	FROM dbo.sysobjects SO
		INNER JOIN dbo.syscolumns SC
			ON SO.id = SC.id
		LEFT JOIN dbo.syscomments SM
			ON SC.cdefault = SM.id
	WHERE SO.xtype = 'U'
		  AND SM.text IS NOT NULL
		  AND SC.isnullable = 1
	ORDER BY SO.[name],
			 SC.colid;


	SELECT [Table Name],
		   [Column Name],
		   [Default Value],
		   isnullable
	FROM @TblColHasDefaultAndIsNullable;
RETURN 0
