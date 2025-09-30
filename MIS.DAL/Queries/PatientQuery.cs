namespace MIS.DAL.Queries
{
    public class PatientQuery
    {
        private const string CurrentTable = "public.\"Patient\"";

       
        public const string AddPatient =
            $"""
             INSERT INTO {CurrentTable} (
                 "Age",
                 "Height",
                 "Weight",
                 "Diagnosis",
                 "Arrival_date",
                 "Departure_date",
                 "First_name",
                 "Last_name",
                 "Gender"
             )
             VALUES (
                 @age,
                 @height,
                 @weight,
                 @diagnosis,
                 @arrival_date,
                 @departure_date,
                 @first_name,
                 @last_name,
                 @gender
             )
             RETURNING "Id";
             """;

        
        public const string GetPatientById =
            $"""
             SELECT 
                 "Id" 
                 "Age",
                 "Height",
                 "Weight",
                 "Diagnosis",
                 "Arrival_date",
                 "Departure_date",
                 "First_name",
                 "Last_name",
                 "Gender"
             FROM {CurrentTable}
             WHERE "Id" = @id;
             """;

        public const string GetAllPatients =
            $"""
             SELECT 
                 "Id",
                 "Age",
                 "Height",
                 "Weight",
                 "Diagnosis",
                 "Arrival_date",
                 "Departure_date",
                 "First_name",
                 "Last_name",
                 "Gender"
             FROM {CurrentTable};
             """;

        
        public const string UpdatePatientName =
            $"""
             UPDATE {CurrentTable}
             SET 
                 "First_name" = @first_name,
                 "Last_name"  = @last_name
             WHERE "Id" = @id;
             """;

        
        public const string UpdatePatientAge =
            $"""
             UPDATE {CurrentTable}
             SET "Age" = @age
             WHERE "Id" = @id;
             """;

        
        public const string UpdatePatientHeight =
            $"""
             UPDATE {CurrentTable}
             SET "Height" = @height
             WHERE "Id" = @id;
             """;

        
        public const string UpdatePatientWeight =
            $"""
             UPDATE {CurrentTable}
             SET "Weight" = @weight
             WHERE "Id" = @id;
             """;

        
        public const string UpdatePatientDiagnosis =
            $"""
             UPDATE {CurrentTable}
             SET "Diagnosis" = @diagnosis
             WHERE "Id" = @id;
             """;

        
        public const string UpdatePatientArrival =
            $"""
             UPDATE {CurrentTable}
             SET "Arrival_date" = @arrival_date
             WHERE "Id" = @id;
             """;

        
        public const string UpdatePatientDeparture =
            $"""
             UPDATE {CurrentTable}
             SET "Departure_date" = @departure_date
             WHERE "Id" = @id;
             """;

     
        public const string UpdatePatientGender =
            $"""
             UPDATE {CurrentTable}
             SET "Gender" = @gender
             WHERE "Id" = @id;
             """;

        
        public const string DeletePatientById =
            $"""
             DELETE FROM {CurrentTable}
             WHERE "Id" = @id;
             """;
    }
}