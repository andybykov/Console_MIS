using MIS.Core.OutputModels;

namespace MIS.UI.Prints
{
    public class PrintTreatLists
    {
        public static void PrintTreatment(TreatmentListOutputModel t)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Id листа: {t.Id}");
            Console.WriteLine($"Дата: {t.CurrentDate}");
            Console.WriteLine($"Врач: {t.DoctorName} (Id={t.DoctorId})");
            Console.WriteLine($"Пациент: {t.PatientName} (Id={t.PatientId})");
            if (!string.IsNullOrWhiteSpace(t.ProcedureName))
                Console.WriteLine($"Процедура: {t.ProcedureName} (Id={t.ProcedureId})");
            if (!string.IsNullOrWhiteSpace(t.DrugName))
                Console.WriteLine($"Препарат: {t.DrugName} – {t.DrugDose}{t.DrugUnits} ({t.DrugComment})");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
