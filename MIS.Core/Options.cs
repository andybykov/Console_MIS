namespace MIS.Core
{
    public static class Options
    {
        // инициируем Connection string
        public static string ConnectionString
        {  get 
            {
                //return  "Server = localhost;" +
                //        " Port = 5432;" +
                //        " User Id = postgres;" +
                //        " Password = 4770;" +
                //        " Database = MIS;";

                // Получаем данные Connection string из "переменной среды"
                string? cs = Environment.GetEnvironmentVariable("ConnectionStringDB");

                if (cs == null)
                {
                    throw new InvalidOperationException("Переменная среды ConnectionStringDB не задана или пуста");
                }                  

                return cs;
            }
        }            
    }
}
