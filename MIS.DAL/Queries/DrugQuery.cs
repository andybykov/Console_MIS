namespace MIS.DAL.Queries
{
    public class DrugQuery
    {
        private const string CurrentTable = "public.\"Drug\"";

        public const string AddDrug =
            $"""
            INSERT INTO {CurrentTable} (
            "Name", "Dose", "Units", "Comment")
            VALUES (@name, @dose, @units, @comment)
            RETURNING "Id";
            """;

        public const string GetDrugById =
           $"""
            SELECT "Id", "Name", "Dose", "Units", "Comment"
            FROM {CurrentTable}
            WHERE "Id"=@id;
            """;

        public const string GetAllDrugs =
            $"""
            SELECT "Id", "Name", "Dose", "Units", "Comment"
            FROM {CurrentTable};
            """;

        public const string UpdateDrug =
            $"""
            UPDATE {CurrentTable}
            SET "Name"=@name, "Dose"=@dose, "Units"=@units, "Comment"=@comment
            WHERE "Id"=@id;
            """;

        public const string DeleteDrugById =
            $"""
            DELETE FROM {CurrentTable}
            WHERE "Id"=@id;
            """;
    }
}

