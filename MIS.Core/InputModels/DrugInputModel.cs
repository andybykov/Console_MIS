namespace MIS.Core.InputModels
{
    public class DrugInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Dose { get; set; }

        public string Units { get; set; }

        public string Comment { get; set; }
    }
}
