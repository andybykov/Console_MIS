namespace MIS.Core.InputModels
{
    public class PatientInputModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Diagnosis { get; set; }
        public string Gender { get; set; }

        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly? DepartureDate { get; set; }    
        
    }
}
