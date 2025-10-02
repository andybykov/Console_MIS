using MIS.Core.InputModels;

namespace MIS.UI.Prompts
{
    public class DoctorPrompt
    {
        public static DoctorInputModel PromptDoctorInput()
        {
            Console.Write("Имя: ");
            var first = Console.ReadLine() ?? "";
            Console.Write("Фамилия: ");
            var last = Console.ReadLine() ?? "";
            return new DoctorInputModel { FirstName = first, LastName = last };
        }
    }
}
