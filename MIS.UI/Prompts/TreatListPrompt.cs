using MIS.Core.InputModels;


namespace MIS.UI.Prompts
{
    public class TreatListPrompt
    {
        public static TreatmentListInputModel PromptTreatmentListInput()
        {
            Console.Write("Введите Id пациента: ");
            var PatientId = Console.ReadLine();
            int.TryParse(PatientId, out int patId);
            //Console.WriteLine($"[Prompt] PatientId parsed = {patId}");

            Console.Write("Введите Id врача: ");
            var DoctorId = Console.ReadLine();
            int.TryParse(DoctorId, out int docId);
            //Console.WriteLine($"[Prompt] DoctorId parsed = {docId}");

            return new TreatmentListInputModel
            {
                PatientId = patId,
                DoctorId = docId
            };
        }

        public static TreatmentListInputModel PromptAddTreatmentListInput()
        {
            Console.Write("Введите Id пациента: ");
            int.TryParse(Console.ReadLine(), out int patId);    

            Console.Write("Введите Id врача: ");
            int.TryParse(Console.ReadLine(), out int docId);

            Console.Write("Введите Id процедуры: ");
            int? procId = null;
            if (int.TryParse(Console.ReadLine(), out int p)) procId = p;

            Console.Write("Введите Id препарата: ");
            int? drugId = null;
            if (int.TryParse(Console.ReadLine(), out int d)) drugId = d;

            Console.Write("Введите дату (yyyy-MM-dd): ");
            var dateRaw = Console.ReadLine();
            var currentDate = DateOnly.TryParse(dateRaw, out var dt)
                ? dt
                : DateOnly.FromDateTime(DateTime.Today);


            return new TreatmentListInputModel
            {
                PatientId = patId,
                DoctorId = docId,
                ProcedureId = procId,
                DrugId = drugId,
                CurrentDate = currentDate,
                PatientDoctorId = 0 // заполним в TreatmentListManager
            };
        }
    }
}
