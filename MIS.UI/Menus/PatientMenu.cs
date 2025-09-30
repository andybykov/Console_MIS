using MIS.BLL;
using MIS.UI.Prints;
using MIS.UI.Prompts;


namespace MIS.UI.Menus
{
    public class PatientMenu
    {
        private static readonly PatientManager _patientMgr = new();
        // Пациенты
        public static void ShowPatientMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Пациенты ---");
                Console.WriteLine("1 – Показать всех");
                Console.WriteLine("2 – По Id");
                Console.WriteLine("3 – Добавить");
                Console.WriteLine("4 – Обновить ФИО");
                Console.WriteLine("5 – Удалить");
                Console.WriteLine("0 – Назад");
                Console.Write("Выберите действие: ");

                var cmd = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (cmd)
                    {
                        case "1":
                            foreach (var p in _patientMgr.GetAllPatients())
                                Console.WriteLine($"{p.Id}: {p.Name} (Возраст {p.Age})");
                            break;

                        case "2":
                            Console.Write("Id пациента: ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                                PrintPatients.PrintPatient(_patientMgr.GetPatientById(id));
                            else
                                Console.WriteLine("Некорректный Id");
                            break;

                        case "3":
                            var newPat = PatientPrompt.PromptPatientInput();
                            _patientMgr.AddPatient(newPat);
                            Console.WriteLine("Пациент добавлен");
                            break;

                        case "4":
                            Console.Write("Id пациента для изменения ФИО: ");
                            if (int.TryParse(Console.ReadLine(), out int updId))
                            {
                                var updPat = PatientPrompt.PromptPatientInput();
                                _patientMgr.UpdatePatientName(updId, updPat);
                                Console.WriteLine("Обновлено");
                            }
                            else
                                Console.WriteLine("Некорректный Id");
                            break;

                        case "5":
                            Console.Write("Id пациента для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int delId))
                            {
                                _patientMgr.DeletePatientById(delId);
                                Console.WriteLine("Пациент удалён");
                            }
                            else
                                Console.WriteLine("Некорректный Id");
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Неверный пункт");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine("\n--- Нажмите любую клавишу ---");
                Console.ReadKey(); //ждем нажатия клавиши
                Console.Clear();
            }
        }
    }
}
