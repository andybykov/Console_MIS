namespace MIS.Core.OutputModels;

public class PatientOutputModel
{
    public int Id { get; set; }
    public int Age { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public required string Diagnosis { get; set; }//= string.Empty;
    public DateOnly ArrivalDate { get; set; }
    public DateOnly? DepartureDate { get; set; }   // nullable – может быть NULL в БД
    public required string Name { get; set; }//= string.Empty;
    public required string Gender { get; set; }// = string.Empty; // "male" / "female"
}
