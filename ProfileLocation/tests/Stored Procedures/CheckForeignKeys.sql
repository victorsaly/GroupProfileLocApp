CREATE PROCEDURE [tests].[CheckForeignKeys]
AS
	 IF OBJECT_ID('tempdb..#TblMissingForeignKeys') IS NOT NULL
        DROP TABLE #TblMissingForeignKeys;

	DECLARE @ColumnList AS TABLE
    (
        TableName VARCHAR(255) NOT NULL,
        ColumnName VARCHAR(255) NOT NULL,
        PKTableName VARCHAR(255),
        PKColumnName VARCHAR(255),
        HasForeignKey BIT NOT NULL
    );


    INSERT INTO @ColumnList
    (
        TableName,
        ColumnName,
        PKTableName,
        PKColumnName,
        HasForeignKey
    )
    SELECT t.name AS TableName,
           c.name AS ColumnName,
           NULL AS PKTableName,
           NULL AS PKColumnName,
           CASE
               WHEN f1.parent_object_id IS NOT NULL THEN
                   1
               WHEN f2.referenced_object_id IS NOT NULL THEN
                   1
               ELSE
                   0
           END AS HasForeignKey
    FROM sys.tables AS t
        JOIN sys.columns AS c
            ON c.object_id = t.object_id
        JOIN sys.types AS y
            ON c.system_type_id = y.system_type_id
        LEFT JOIN sys.foreign_key_columns AS f1
            ON f1.parent_object_id = t.object_id
               AND f1.parent_column_id = c.column_id
        LEFT JOIN sys.foreign_key_columns AS f2
            ON f2.referenced_object_id = t.object_id
               AND f2.referenced_column_id = c.column_id
    WHERE t.is_ms_shipped = 0
          AND y.name IN ( 'bigint', 'int', 'smallint', 'tinyint', 'uniqueidentifier' );


    SELECT TableName,
           ColumnName,
           PKTableName,
           PKColumnName
    INTO #TblMissingForeignKeys
    FROM @ColumnList
    WHERE HasForeignKey = 0
          AND ColumnName IN
              (
                  SELECT ColumnName
                  FROM @ColumnList
                  GROUP BY ColumnName
                  HAVING COUNT(*) > 1
              )
          AND ColumnName NOT IN ( 'GUID', 'ID', 'SortOrder' )
          AND ColumnName NOT LIKE '%qty%'
    ORDER BY ColumnName,
             TableName;



	SELECT * FROM #TblMissingForeignKeys
    
RETURN 0
