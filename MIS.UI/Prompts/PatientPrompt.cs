using MIS.Core.InputModels;
using System.Globalization;

namespace MIS.UI.Prompts
{
    public class PatientPrompt
    {
        public static PatientInputModel PromptPatientInput()
        {
            var p = new PatientInputModel();
            Console.Write("Имя: "); p.FirstName = Console.ReadLine() ?? "";
            Console.Write("Фамилия: "); p.LastName = Console.ReadLine() ?? "";
            Console.Write("Пол: "); p.Gender = Console.ReadLine() ?? "";
            Console.Write("Возраст: "); p.Age = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Рост: "); p.Height = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
            Console.Write("Вес: "); p.Weight = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
            Console.Write("Диагноз: "); p.Diagnosis = Console.ReadLine() ?? "";
            Console.Write("Дата поступления (yyyy-MM-dd): ");
            p.ArrivalDate = DateOnly.Parse(Console.ReadLine() ?? DateTime.Today.ToString("yyyy-MM-dd"));
            Console.Write("Дата выписки: ");

            var dep = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dep))
                p.DepartureDate = DateOnly.Parse(dep);

            return p;
        }
    }
}
