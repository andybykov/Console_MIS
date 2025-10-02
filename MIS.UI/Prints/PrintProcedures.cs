using MIS.Core.OutputModels;

namespace MIS.UI.Prints
{
    public class PrintProcedures
    {
        public static void PrintProcedure(ProcedureOutputModel p)
        {
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"Название: {p.Name}");
            Console.WriteLine($"Комментарий: {p.Comment}");
        }
    }
}
