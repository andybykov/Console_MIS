using MIS.BLL;
using MIS.UI.Prompts;


namespace MIS.UI.Menus

{
    public class DoctorMenu
    {
        private static readonly DoctorManager _doctorMgr = new();
        // Врачи
        public static void ShowDoctorMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Врачи ---");
                Console.WriteLine("1 – Показать всех");
                Console.WriteLine("2 – Показать по Id");
                Console.WriteLine("3 – Добавить");
                Console.WriteLine("4 – Обновить");
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
                            foreach (var d in _doctorMgr.GetAllDoctors())
                                Console.WriteLine($"{d.Id}: {d.FullName}");
                            break;

                        case "2":
                            Console.Write("Id врача: ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                                Console.WriteLine(_doctorMgr.GetDoctorById(id).FullName);
                            else
                                Console.WriteLine("Неверный Id");
                            break;

                        case "3":
                            var newDoc = DoctorPrompt.PromptDoctorInput();
                            _doctorMgr.AddDoctor(newDoc);
                            Console.WriteLine("Врач добавлен");
                            break;

                        case "4":
                            Console.Write("Id врача для изменения: ");
                            if (int.TryParse(Console.ReadLine(), out int updId))
                            {
                                var updDoc = DoctorPrompt.PromptDoctorInput();
                                // UpdateDoctor принимает только InputModel 
                                _doctorMgr.UpdateDoctor(updDoc);
                                Console.WriteLine("Обновлено");
                            }
                            else
                                Console.WriteLine("Неверный Id");
                            break;

                        case "5":
                            Console.Write("Id врача для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int delId))
                            {
                                _doctorMgr.DeleteDoctorById(delId);
                                Console.WriteLine("Врач удалён");
                            }
                            else
                                Console.WriteLine("Неверный Id");
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

                Console.WriteLine("\n--- Нажмите любую клавишу для продолжения ---");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
