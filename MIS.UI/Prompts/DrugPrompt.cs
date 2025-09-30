using MIS.Core.InputModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.UI.Prompts
{
    public class DrugPrompt
    {
        public static DrugInputModel PromptDrugInput()
        {
            var d = new DrugInputModel();
            Console.Write("Название: "); d.Name = Console.ReadLine() ?? "";
            Console.Write("Доза (число): "); d.Dose = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
            Console.Write("Единицы (мг, мл …): "); d.Units = Console.ReadLine() ?? "";
            Console.Write("Комментарий (опционально): "); d.Comment = Console.ReadLine();
            return d;
        }
    }
}
