namespace MIS.Core.Dtos;

public class TreatmentListDto
{
    public required int Id { get; set; }

    public required DateOnly CurrentDate { get; set; }

    public int? ProcedureId { get; set; }
    public string? ProcedureName { get; set; }

    public int? DrugId { get; set; }
    public string? DrugName { get; set; }
    public double? DrugDose { get; set; }
    public string? DrugUnits { get; set; }
    public string? DrugComment { get; set; }

    public required int PatientDoctorId { get; set; }
    public required int PatientId { get; set; }
    public required string PatientName { get; set; } //= string.Empty;
    public required int DoctorId { get; set; }
    public required string DoctorName { get; set; } //= string.Empty;

}