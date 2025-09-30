namespace MIS.Core.Dtos
{
    public class DrugDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required double Dose { get; set; }

        public required string Units { get; set; }

        public required string Comment { get; set; }
    }
    
}
