namespace MIS.Core.OutputModels;

public  class TreatmentListOutputModel
{
    public int Id { get; set; }

    public DateOnly CurrentDate { get; set; }

    public int? ProcedureId { get; set; }
    public string? ProcedureName { get; set; }

    public int? DrugId { get; set; }
    public string? DrugName { get; set; }
    public double? DrugDose { get; set; }
    public string? DrugUnits { get; set; }
    public string? DrugComment { get; set; }

    public int PatientDoctorId { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; } //= string.Empty;
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } //= string.Empty;
}
