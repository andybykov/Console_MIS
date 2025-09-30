using MIS.BLL;
using MIS.UI.Prints;
using MIS.UI.Prompts;

namespace MIS.UI.Menus
{
   public class DrugMenu
    {
        private static readonly DrugManager _drugMgr = new();

        //  Препараты
        public static void ShowDrugMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Препараты ---");
                Console.WriteLine("1 – Показать все");
                Console.WriteLine("2 – По Id");
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
                            foreach (var d in _drugMgr.GetAllDrugs())
                                Console.WriteLine($"{d.Id}: {d.Name} – {d.Dose}{d.Units} ({d.Comment})");
                            break;

                        case "2":
                            Console.Write("Id препарата: ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                                PrintDrugs.PrintDrug(_drugMgr.GetDrugById(id));
                            else
                                Console.WriteLine("Некорректный Id");
                            break;

                        case "3":
                            var newDrug = DrugPrompt.PromptDrugInput();
                            _drugMgr.AddDrug(newDrug);
                            Console.WriteLine("Препарат добавлен");
                            break;

                        case "4":
                            Console.Write("Id препарата для обновления: ");
                            if (int.TryParse(Console.ReadLine(), out int updId))
                            {
                                var upd = DrugPrompt.PromptDrugInput();
                                upd.Id = updId; // Id нужен только для UPDATE
                                _drugMgr.UpdateDrug(upd);
                                Console.WriteLine("Обновлено");
                            }
                            else
                                Console.WriteLine("Некорректный Id");
                            break;

                        case "5":
                            Console.Write("Id препарата для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int delId))
                            {
                                _drugMgr.DeleteDrugById(delId);
                                Console.WriteLine("Препарат удалён");
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
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
