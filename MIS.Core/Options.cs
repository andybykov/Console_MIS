namespace MIS.Core
{
    public static class Options
    {
        // инициируем Connection string
        public static string ConnectionString
        {  get 
            {
                

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
