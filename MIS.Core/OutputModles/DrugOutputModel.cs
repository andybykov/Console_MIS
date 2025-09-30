namespace MIS.Core.OutputModels
{
    public class DrugOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Dose { get; set; }
        public string Units { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
