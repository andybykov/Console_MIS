// File: MIS.DAL.Queries.TreatmentListQuery.cs
namespace MIS.DAL.Queries;

public static class TreatmentListQuery
{
    private const string Tbl = "public.\"Treatment_list\"";
    private const string Pd = "public.\"Patient_Doctor\"";
    private const string P = "public.\"Patient\"";
    private const string D = "public.\"Doctor\"";
    private const string Drg = "public.\"Drug\"";
    private const string Pr = "public.\"Procedure\"";

    
    public const string AddTreatmentList =
        $"""
         INSERT INTO {Tbl} ("CurrentDate", "Procedure", "Drug", "PatientDoctorId")
         VALUES (@date, @procId, @drugId, @pdId)
         RETURNING "Id";
         """;

    
    public const string GetTreatmentListById =
        $"""
         SELECT t."Id",
                t."CurrentDate",
                t."Procedure"      AS ProcedureId,
                pr."Name"          AS ProcedureName,
                t."Drug"           AS DrugId,
                dr."Name"          AS DrugName,
                dr."Dose"          AS DrugDose,
                dr."Units"         AS DrugUnits,
                dr."Comment"       AS DrugComment,
                t."PatientDoctorId",
                pat."Id"           AS PatientId,
                pat."First_name"   || ' ' || pat."Last_name" AS PatientName,
                doc."Id"           AS DoctorId,
                doc."First_name"   || ' ' || doc."Last_name" AS DoctorName
         FROM {Tbl} t
         LEFT JOIN {Pr}  pr  ON pr."Id"  = t."Procedure"
         LEFT JOIN {Drg} dr  ON dr."Id"  = t."Drug"
         INNER JOIN {Pd} pd  ON pd."Id"  = t."PatientDoctorId"
         INNER JOIN {P}  pat ON pat."Id" = pd."PatientId"
         INNER JOIN {D}  doc ON doc."Id" = pd."DoctorId"
         WHERE t."Id" = @id;
         """;

    
    public const string GetAllTreatmentLists =
        $"""
         SELECT t."Id",
                t."CurrentDate",
                t."Procedure"      AS ProcedureId,
                pr."Name"          AS ProcedureName,
                t."Drug"           AS DrugId,
                dr."Name"          AS DrugName,
                dr."Dose"          AS DrugDose,
                dr."Units"         AS DrugUnits,
                dr."Comment"       AS DrugComment,
                t."PatientDoctorId",
                pat."Id"           AS PatientId,
                pat."First_name"   || ' ' || pat."Last_name" AS PatientName,
                doc."Id"           AS DoctorId,
                doc."First_name"   || ' ' || doc."Last_name" AS DoctorName
         FROM {Tbl} t
         LEFT JOIN {Pr}  pr  ON pr."Id"  = t."Procedure"
         LEFT JOIN {Drg} dr  ON dr."Id"  = t."Drug"
         INNER JOIN {Pd} pd  ON pd."Id"  = t."PatientDoctorId"
         INNER JOIN {P}  pat ON pat."Id" = pd."PatientId"
         INNER JOIN {D}  doc ON doc."Id" = pd."DoctorId"
         ORDER BY t."CurrentDate" DESC, t."Id";
         """;

    
    public const string UpdateTreatmentList =
        $"""
         UPDATE {Tbl}
         SET "CurrentDate"   = @date,
             "Procedure"     = @procId,
             "Drug"          = @drugId,
             "PatientDoctorId" = @pdId
         WHERE "Id" = @id;
         """;

    
    public const string DeleteTreatmentList =
        $"""
         DELETE FROM {Tbl}
         WHERE "Id" = @id;
         """;

    /* все листы одного врача */
    public const string GetAllTreatmentListsByDoctorId =
        """
         SELECT t."Id",
                t."CurrentDate",
                t."Procedure"      AS ProcedureId,
                pr."Name"          AS ProcedureName,
                t."Drug"           AS DrugId,
                dr."Name"          AS DrugName,
                dr."Dose"          AS DrugDose,
                dr."Units"         AS DrugUnits,
                dr."Comment"       AS DrugComment,
                t."PatientDoctorId",
                pat."Id"           AS PatientId,
                pat."First_name"   || ' ' || pat."Last_name" AS PatientName,
                doc."Id"           AS DoctorId,
                doc."First_name"   || ' ' || doc."Last_name" AS DoctorName
         FROM public."Treatment_list" t
         LEFT JOIN public."Procedure"  pr  ON pr."Id"  = t."Procedure"
         LEFT JOIN public."Drug"       dr  ON dr."Id"  = t."Drug"
         INNER JOIN public."Patient_Doctor" pd ON pd."Id" = t."PatientDoctorId"
         INNER JOIN public."Patient"  pat ON pat."Id" = pd."PatientId"
         INNER JOIN public."Doctor"   doc ON doc."Id" = pd."DoctorId"
         WHERE pd."DoctorId" = @doctorId
         ORDER BY t."CurrentDate" DESC, t."Id";
         """;

    /* все листы одного пациента */
    public const string GetAllTreatmentListsByPatientId =
        """
         SELECT t."Id",
                t."CurrentDate",
                t."Procedure"      AS ProcedureId,
                pr."Name"          AS ProcedureName,
                t."Drug"           AS DrugId,
                dr."Name"          AS DrugName,
                dr."Dose"          AS DrugDose,
                dr."Units"         AS DrugUnits,
                dr."Comment"       AS DrugComment,
                t."PatientDoctorId",
                pat."Id"           AS PatientId,
                pat."First_name"   || ' ' || pat."Last_name" AS PatientName,
                doc."Id"           AS DoctorId,
                doc."First_name"   || ' ' || doc."Last_name" AS DoctorName
         FROM public."Treatment_list" t
         LEFT JOIN public."Procedure"  pr  ON pr."Id"  = t."Procedure"
         LEFT JOIN public."Drug"       dr  ON dr."Id"  = t."Drug"
         INNER JOIN public."Patient_Doctor" pd ON pd."Id" = t."PatientDoctorId"
         INNER JOIN public."Patient"  pat ON pat."Id" = pd."PatientId"
         INNER JOIN public."Doctor"   doc ON doc."Id" = pd."DoctorId"
         WHERE pat."Id" = @patientId
         ORDER BY t."CurrentDate" DESC, t."Id";
         """;
}
