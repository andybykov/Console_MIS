using MIS.Core.OutputModels;

namespace MIS.UI.Prints
{
    public class PrintPatients
    {
        public static void PrintPatient(PatientOutputModel p)
        {
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"ФИО: {p.Name}");
            Console.WriteLine($"Возраст: {p.Age}");
            Console.WriteLine($"Рост: {p.Height} см");
            Console.WriteLine($"Вес: {p.Weight} кг");
            Console.WriteLine($"Диагноз: {p.Diagnosis}");
            Console.WriteLine($"Дата поступления: {p.ArrivalDate}");
            Console.WriteLine($"Дата выписки: {(p.DepartureDate.HasValue ? p.DepartureDate.Value.ToString() : "не указана")}");
            Console.WriteLine($"Пол: {p.Gender}");
        }
    }
}
