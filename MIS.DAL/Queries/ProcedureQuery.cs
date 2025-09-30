namespace MIS.DAL.Queries;

public static class ProcedureQuery
{
    private const string CurrentTable = "public.\"Procedure\"";

    public const string AddProcedure =
        $"""
         INSERT INTO {CurrentTable} ("Name", "Comment")
         VALUES (@name, @comment)
         RETURNING "Id";
         """;

    public const string GetProcedureById =
        $"""
         SELECT "Id", "Name", "Comment"
         FROM {CurrentTable}
         WHERE "Id" = @id;
         """;

    public const string GetAllProcedures =
        $"""
         SELECT "Id", "Name", "Comment"
         FROM {CurrentTable}
         ORDER BY "Name";
         """;

    public const string UpdateProcedure =
        $"""
         UPDATE {CurrentTable}
         SET "Name"    = @name,
             "Comment" = @comment
         WHERE "Id"    = @id;
         """;

    public const string DeleteProcedure =
        $"""
         DELETE FROM {CurrentTable}
         WHERE "Id" = @id;
         """;
}