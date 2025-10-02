using MIS.BLL;
using MIS.Core.InputModels;
using MIS.UI.Prints;
using MIS.UI.Prompts;

namespace MIS.UI.Menus
{
	public class TreatListMenu
	{
		private static readonly TreatmentListManager _treatMgr = new();

		//  Листы назначений
		public static void ShowTreatmentListMenu()
		{
			while (true)
			{
				Console.WriteLine("\n--- Листы назначений ---");
				Console.WriteLine("1 – Показать все");
				Console.WriteLine("2 – По Id");
				Console.WriteLine("3 – По Id врача");
				Console.WriteLine("4 – По Id пациента");
				Console.WriteLine("5 – Добавить");
				Console.WriteLine("6 – Обновить");
				Console.WriteLine("7 – Удалить");
				Console.WriteLine("0 – Назад");
				Console.Write("Выберите действие: ");

				var cmd = Console.ReadLine();
				Console.Clear();

				try
				{
					switch (cmd)
					{
						case "1":
							foreach (var t in _treatMgr.GetAllTreatmentLists())
								PrintTreatLists.PrintTreatment(t);
							break;

						case "2":
							Console.Write("Id листа: ");
							if (int.TryParse(Console.ReadLine(), out int id))
								PrintTreatLists.PrintTreatment(_treatMgr.GetTreatmentListById(id));
							else
								Console.WriteLine("Некорректный Id");
							break;

						case "3":
							Console.Write("Id врача: ");
							if (int.TryParse(Console.ReadLine(), out int docId))
							{
								var list = _treatMgr.GetTreatmentListsByDoctorId(docId);
								if (list.Count == 0) Console.WriteLine("Нет листов для данного врача");
								else foreach (var t in list) PrintTreatLists.PrintTreatment(t);
							}
							else
								Console.WriteLine("Некорректный Id");
							break;

						case "4":
							Console.Write("Id пациента: ");
							if (int.TryParse(Console.ReadLine(), out int patId))
							{
								var list = _treatMgr.GetTreatmentListsByPatientId(patId);
								if (list.Count == 0) Console.WriteLine("Нет листов для данного пациента");
								else foreach (var t in list) PrintTreatLists.PrintTreatment(t);
							}
							else
								Console.WriteLine("Некорректный Id");
							break;
							
                        case "5":
                            
                            var newT = TreatListPrompt.PromptAddTreatmentListInput();                               
                            int patientDoctorId = _treatMgr.CreatePatientDoctorId(newT); // Создаем и/или получаем PatientDoctorId 
                            newT.PatientDoctorId = patientDoctorId;                            
                            int treatmentListId = _treatMgr.AddTreatmentList(newT);
                            Console.WriteLine($"Лист назначений добавлен. Id = {treatmentListId}");
                            break;

						case "6":
							Console.Write("Id листа для изменения: ");
							if (int.TryParse(Console.ReadLine(), out int updId))
							{
								var upd = TreatListPrompt.PromptAddTreatmentListInput();
                                int pdid = _treatMgr.CreatePatientDoctorId(upd); // Создаем и/или получаем PatientDoctorId
								upd.PatientDoctorId = pdid;											
                                _treatMgr.UpdateTreatmentList(upd);
								Console.WriteLine("Обновлено");
							}
							else
								Console.WriteLine("Некорректный Id");
							break;

						case "7":
							Console.Write("Id листа для удаления: ");
							if (int.TryParse(Console.ReadLine(), out int delId))
							{
								_treatMgr.DeleteTreatmentListById(delId);
								Console.WriteLine("Лист удалён");
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
