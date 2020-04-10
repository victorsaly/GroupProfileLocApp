CREATE PROCEDURE [tests].[CheckPrimaryKeys]
AS
BEGIN

    DECLARE @TblPrimaryKeyExist TABLE
    (
        [SchemaName] sysname NOT NULL,
        [TableName] sysname NOT NULL,
        [Msg] VARCHAR(128) NULL
    );

    BEGIN

        INSERT @TblPrimaryKeyExist
        (
            SchemaName,
            TableName,
            Msg
        )
        SELECT SCHEMA_NAME(tab.schema_id) AS [SchemaName],
               tab.[name] AS TableName,
               'No Primary Key' AS Msg
        FROM [sys].[tables] tab
            LEFT OUTER JOIN sys.indexes pk
                ON tab.object_id = pk.object_id
                   AND pk.is_primary_key = 1
        WHERE pk.object_id IS NULL
        ORDER BY SCHEMA_NAME(tab.schema_id),
                 tab.[name];
    END;

    SELECT SchemaName,
            TableName,
            Msg FROM @TblPrimaryKeyExist;


    RETURN 0;
END;


