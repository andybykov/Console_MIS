using MIS.Core;
using MIS.Core.Dtos;
using MIS.DAL.Queries;
using Npgsql;


namespace MIS.DAL
{
    public class DoctorRepository
    {
        // Метод добавляет нового врача
        // Возвращает id

        //public DoctorDt AddDoctor(DoctorDto doctor)  // возвращаем DoctorDto
        public int AddDoctor(DoctorDto doctor)
        {
            // создаем новый объетconnection для возможности соединения с БД
            // using {} дает возможность не закрывать содеинение вручную, а делать это автоматически, аналогично connection.Close();
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                // Параметризация запроса
                NpgsqlCommand command = new NpgsqlCommand(DoctorQuery.AddDoctor, connection);
                command.Parameters.Add(new NpgsqlParameter("@first_name", doctor.FirstName));
                command.Parameters.Add(new NpgsqlParameter("@last_name", doctor.LastName));

                int id = (int)command.ExecuteScalar()!; // command.ExecuteScalar() возвращает одно значение

                return id;
            }
        }   


        public DoctorDto GetDoctorById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(DoctorQuery.GetDoctorById, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));

                using NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new DoctorDto
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    };
                }
                throw new KeyNotFoundException($"Врач с Id={id} не найден.");
            }
        }

        public List<DoctorDto> GetAllDoctors()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(DoctorQuery.GetAllDoctors, connection);

                using NpgsqlDataReader reader = command.ExecuteReader();
                var list = new List<DoctorDto>();
                while (reader.Read())
                {
                    list.Add(new DoctorDto
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    });
                }
                return list;
            }
        }

        public void UpdateDoctor(DoctorDto doctor)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(DoctorQuery.UpdateDoctor, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", doctor.Id));
                command.Parameters.Add(new NpgsqlParameter("@first_name", doctor.FirstName));
                command.Parameters.Add(new NpgsqlParameter("@last_name", doctor.LastName));

                int rows = command.ExecuteNonQuery();
                if (rows == 0)
                    throw new KeyNotFoundException($"Врач с Id={doctor.Id} не найден для обновления.");
            }
        }

        public void DeleteDoctorById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(DoctorQuery.DeleteDoctorById, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));

                int rows = command.ExecuteNonQuery();
                if (rows == 0)
                    throw new KeyNotFoundException($"Врач с Id={id} не найден для удаления.");
            }
        }
    }
}
