using MIS.BLL;
using MIS.UI.Prints;
using MIS.UI.Prompts;


namespace MIS.UI.Menus
{
    public class ProcedureMenu
    {
        private static readonly ProcedureManager _procMgr = new();

        //  Процедуры
        public static void ShowProcedureMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Процедуры ---");
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
                            foreach (var p in _procMgr.GetAllProcedures())
                                Console.WriteLine($"{p.Id}: {p.Name} ({p.Comment})");
                            break;

                        case "2":
                            Console.Write("Id процедуры: ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                                PrintProcedures.PrintProcedure(_procMgr.GetProcedureById(id));
                            else
                                Console.WriteLine("Некорректный Id");
                            break;

                        case "3":
                            var newProc = ProcedurePrompt.PromptProcedureInput();
                            _procMgr.AddProcedure(newProc);
                            Console.WriteLine("Процедура добавлена");
                            break;

                        case "4":
                            Console.Write("Id процедуры для изменения: ");
                            if (int.TryParse(Console.ReadLine(), out int updId))
                            {
                                var upd = ProcedurePrompt.PromptProcedureInput();
                                _procMgr.UpdateProcedure(updId, upd);
                                Console.WriteLine("Обновлено");
                            }
                            else
                                Console.WriteLine("Некорректный Id");
                            break;

                        case "5":
                            Console.Write("Id процедуры для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int delId))
                            {
                                _procMgr.DeleteProcedure(delId);
                                Console.WriteLine("Процедура удалена");
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
