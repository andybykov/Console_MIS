using MIS.Core.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
