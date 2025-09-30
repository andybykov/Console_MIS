//using MIS.Core.Dtos;
using MIS.BLL;
using MIS.UI;
using MIS.DAL;
using MIS.Core;
using MIS.Core.InputModels;
using Npgsql;
using MIS.Core.Dtos;

// DoctorRepository doc= new DoctorRepository();
//Console.WriteLine(doc.AddDoctor(new DoctorDto() { FirstName = "Геннадий", LastName = "Букин" }));

//DrugRepository doc = new DrugRepository();
//Console.WriteLine(doc.AddDrug(new DrugDto()
//{
//    Name = "Что-то",
//    Dose = 20000,
//    Units = "тб/сут",
//    Comment = "на ночь"
//}
//));

//new ProductRepository().AddProduct(new ProductDto() { Name = "БУБУБУ", Volume = 2 });

TreatmentListRepository d = new TreatmentListRepository();
d.GetAllTreatmentLists();



//DrugRepository dr = new();
//dr.UpdateDrug(new DrugDto()
//{
//    Id = 2,
//    Name = "Левофлокссацин",
//    Dose = 1000,
//    Units = "мг/сут",
//    Comment = "за 30 минут"
//}
//);

/* Обработка исключений */
//var repo = new DrugRepository();

//try
//{

//    repo.DeleteDrugById(999);
//    Console.WriteLine("Удалено");
//}
//catch (PostgresException pgEx)        // специфичная ошибка СУБД
//{
//    Console.WriteLine($"SQL ошибка: {pgEx.Message}");
//}
//catch (Exception ex)                  // другие исключения, в т.ч свои
//{
//    Console.WriteLine(ex.Message);    // ... Препарат с Id=42 не найден для удаления.
//}


//var tl = new TreatmentListRepository().GetTreatmentListById(5);

//var tl = new TreatmentListRepository().GetAllTreatmentListsByPatientId(99);
//var tl = new TreatmentListRepository().GetTreatmentListsByDoctorId(11);

//DoctorManager doc = new DoctorManager();

////DoctorRepository doc = new();

////int id = Convert.ToInt32(Console.ReadLine());
//int id = 99;
//// Добавть try catch
//try
//{
//    var doctor = doc.GetDoctorById(id);
//    Console.WriteLine($"{doctor.Id} {doctor.FullName}");
//}
//catch (KeyNotFoundException e)
//{
//    Console.WriteLine(e.Message);
//}


//DoctorManager doc = new DoctorManager();

//var d = new DoctorInputModel
//{
//    FirstName = Console.ReadLine()!,
//    LastName = Console.ReadLine()!
//};



//if (doc.AddDoctor(d)) Console.WriteLine("Запсиь успешно добавлена");
//else Console.WriteLine("Ошибка!");



Console.WriteLine();
//List<DrugDto> p= new DrugRepository().GetAllProducts();

//try
//{
//    p.Id = 1;
//    p.Name = "Коробка";
//    new ProductRepository().UpdateProduct(p);
//}
//catch (ArgumentOutOfRangeException e)
//{
//    Console.WriteLine("Я упал");
//}

//var a = new WarehouseRepository().GetWarehouseFullmentById(1);

Console.WriteLine("Done!");
