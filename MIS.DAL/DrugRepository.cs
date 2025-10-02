using MIS.Core;
using MIS.Core.Dtos;
using MIS.DAL.Queries;
using Npgsql;

namespace MIS.DAL
{
    public class DrugRepository
    {
        // Добавление препарата
        public int AddDrug(DrugDto durg)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                // Параметризация запроса
                NpgsqlCommand command = new NpgsqlCommand(DrugQuery.AddDrug, connection);
                command.Parameters.Add(new NpgsqlParameter("@name", durg.Name));
                command.Parameters.Add(new NpgsqlParameter("@dose", durg.Dose));
                command.Parameters.Add(new NpgsqlParameter("@units", durg.Units));
                command.Parameters.Add(new NpgsqlParameter("@comment", durg.Comment));

                int id = (int)command.ExecuteScalar()!; // command.ExecuteScalar() возвращает одно значение

                return id; // возврат id
            }
        }

        // Получение прерапата по Id
        public DrugDto GetDrugById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                // Параметризация запроса
                NpgsqlCommand command = new NpgsqlCommand(DrugQuery.GetDrugById, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));

                // объект NpgsqlDataReader 
                NpgsqlDataReader reader = command.ExecuteReader();

                //if (reader.HasRows)
                if (reader.Read())
                {
                    //reader.Read();

                    //DrugDto product = new DrugDto()
                    //{
                    //    Id = reader.GetInt32(0),
                    //    Name = reader.GetString(1),
                    //    Dose = reader.GetDouble(2),
                    //    Units = reader.GetString(3),
                    //    Comment = reader.GetString(4),
                    //};

                    //return product;
                    return new DrugDto
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Dose = reader.GetDouble(2),
                        Units = reader.GetString(3),
                        Comment = reader.IsDBNull(4) ? null : reader.GetString(4) // проверка на NULL       
                    };
                }
                else
                {
                    throw new Exception($"Id={id} не существует");
                }
            }

        }

        // Получить список всех препаратов
        public List<DrugDto> GetAllDrugs()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(DrugQuery.GetAllDrugs, connection);

                using NpgsqlDataReader reader = command.ExecuteReader();
                List<DrugDto> list = new List<DrugDto>();

                while (reader.Read())
                {
                    list.Add(new DrugDto
                    {

                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Dose = reader.GetDouble(2),
                        Units = reader.GetString(3),
                        Comment = reader.IsDBNull(4) ? null : reader.GetString(4)  // проверка на NULL
                    });
                }

                return list;
            }
        }

        // Обновить препарат
        public void UpdateDrug(DrugDto drug)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(DrugQuery.UpdateDrug, connection);

                command.Parameters.Add(new NpgsqlParameter("@id", drug.Id));
                command.Parameters.Add(new NpgsqlParameter("@name", drug.Name));
                command.Parameters.Add(new NpgsqlParameter("@dose", drug.Dose));
                command.Parameters.Add(new NpgsqlParameter("@units", drug.Units));
                command.Parameters.Add(new NpgsqlParameter("@comment", drug.Comment));

                int rows = command.ExecuteNonQuery(); // не возвращает данные, но возвращает количетсво измененных строк
                if (rows == 0) // может быть -1
                    throw new Exception($"Препарат с Id={drug.Id} не найден для обновления.");
            }
        }

        // Удалить препарат
        public void DeleteDrugById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(DrugQuery.DeleteDrugById, connection);

                command.Parameters.Add(new NpgsqlParameter("@id", id));

                int rows = command.ExecuteNonQuery();
                if (rows == 0)
                    throw new Exception($"Препарат с Id={id} не найден для удаления.");
            }
        }

    }
}
