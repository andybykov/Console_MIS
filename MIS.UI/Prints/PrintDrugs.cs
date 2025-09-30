using MIS.Core.OutputModels;


namespace MIS.UI.Prints
{
    public class PrintDrugs
    {
        public static void PrintDrug(DrugOutputModel d)
        {
            Console.WriteLine($"Id: {d.Id}");
            Console.WriteLine($"Название: {d.Name}");
            Console.WriteLine($"Доза: {d.Dose} {d.Units}");
            Console.WriteLine($"Комментарий: {d.Comment}");
        }
    }
}
