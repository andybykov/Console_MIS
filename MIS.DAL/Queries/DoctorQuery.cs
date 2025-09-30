namespace MIS.DAL.Queries
{
    public class DoctorQuery
    {
        private const string CurrentTable = "public.\"Doctor\"";

        public const string AddDoctor =
            $"""
             INSERT INTO {CurrentTable} ("First_name", "Last_name")
             VALUES (@first_name, @last_name)
             RETURNING "Id";
             """;

        public const string GetDoctorById =
            $"""
             SELECT "Id", "First_name", "Last_name"
             FROM {CurrentTable}
             WHERE "Id" = @id;
             """;

        public const string GetAllDoctors =
            $"""
             SELECT "Id", "First_name", "Last_name"
             FROM {CurrentTable};
             """;

        public const string UpdateDoctor =
            $"""
             UPDATE {CurrentTable}
             SET "First_name" = @first_name,
                 "Last_name"  = @last_name
             WHERE "Id" = @id;
             """;

        public const string DeleteDoctorById =
            $"""
             DELETE FROM {CurrentTable}
             WHERE "Id" = @id;
             """;
    }
}