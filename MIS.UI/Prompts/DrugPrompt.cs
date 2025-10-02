using MIS.Core.InputModels;
using System.Globalization;

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
