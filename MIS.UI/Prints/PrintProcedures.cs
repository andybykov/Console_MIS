using MIS.Core.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
