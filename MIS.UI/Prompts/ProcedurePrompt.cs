using MIS.Core.InputModels;
using MIS.Core.OutputModels;


namespace MIS.UI.Prompts
{
    public class ProcedurePrompt
    {
        public static ProcedureInputModel PromptProcedureInput()
        {
            var p = new ProcedureInputModel();
            Console.Write("Название: "); p.Name = Console.ReadLine() ?? "";
            Console.Write("Комментарий (можно пусто): "); p.Comment = Console.ReadLine();
            return p;
        }

        
    }
}
