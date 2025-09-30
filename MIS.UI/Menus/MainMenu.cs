namespace MIS.UI.Menus
{
    public class MainMenu
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine("=== Меню управления медицинской информационной системой ===");
            Console.WriteLine("1 – Врачи");
            Console.WriteLine("2 – Пациенты");
            Console.WriteLine("3 – Препараты");
            Console.WriteLine("4 – Процедуры");
            Console.WriteLine("5 – Листы назначений");
            Console.WriteLine("0 – Выход");
            Console.Write("Выберите раздел: ");
        }
    }
}
