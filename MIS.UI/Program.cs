using MIS.UI.Menus;

namespace MIS.UI
{
    internal static class Program
    {
        static void Main()
        {
            while (true)
            {
                MainMenu.ShowMainMenu();
                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1": DoctorMenu.ShowDoctorMenu(); break;
                    case "2": PatientMenu.ShowPatientMenu(); break;
                    case "3": DrugMenu.ShowDrugMenu(); break;
                    case "4": ProcedureMenu.ShowProcedureMenu(); break;
                    case "5": TreatListMenu.ShowTreatmentListMenu(); break;
                    case "0": return;
                    default: Console.WriteLine("Попробуте еще раз"); break;
                }
            }
        }
    }
}
