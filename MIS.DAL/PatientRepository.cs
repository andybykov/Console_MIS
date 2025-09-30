using MIS.Core;
using MIS.Core.Dtos;
using MIS.DAL.Queries;
using Npgsql;

namespace MIS.DAL
{
    public class PatientRepository
    {
        // Метод добавляет нового пациента
        // Возвращает id        
        public int AddPatient(PatientDto patient)
        {
            // создаем новый объетconnection для возможности соединения с БД
            // using {} дает возможность не закрывать содеинение вручную, а делать это автоматически, аналогично connection.Close();
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                // Параметризация запроса                
                NpgsqlCommand command = new NpgsqlCommand(PatientQuery.AddPatient, connection);

                command.Parameters.Add(new NpgsqlParameter("@age", patient.Age));
                command.Parameters.Add(new NpgsqlParameter("@height", patient.Height));
                command.Parameters.Add(new NpgsqlParameter("@weight", patient.Weight));
                command.Parameters.Add(new NpgsqlParameter("@diagnosis", patient.Diagnosis));
                command.Parameters.Add(new NpgsqlParameter("@arrival_date", patient.ArrivalDate));
                command.Parameters.Add(new NpgsqlParameter("@departure_date", patient.DepartureDate));
                command.Parameters.Add(new NpgsqlParameter("@first_name", patient.FirstName));
                command.Parameters.Add(new NpgsqlParameter("@last_name", patient.LastName));
                command.Parameters.Add(new NpgsqlParameter("@gender", patient.Gender));

                int id = (int)command.ExecuteScalar()!; // command.ExecuteScalar() возвращает одно значение

                return id;
            }
        }

        // Получает пациента по id
        public PatientDto GetPatientById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.GetPatientById, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));

                using NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new PatientDto
                    {
                        Age = reader.GetInt32(0),
                        Height = reader.GetDouble(1),
                        Weight = reader.GetDouble(2),
                        Diagnosis = reader.GetString(3),
                        ArrivalDate = DateOnly.FromDateTime(reader.GetDateTime(4)),
                        DepartureDate = reader.IsDBNull(5) ? null : DateOnly.FromDateTime(reader.GetDateTime(5)),
                        FirstName = reader.GetString(6),
                        LastName = reader.GetString(7),
                        Gender = reader.GetString(8)
                    };
                }
                throw new KeyNotFoundException($"Пациент с Id={id} не найден");
            }
        }

        // Получает список всех пациентов
        public List<PatientDto> GetAllPatients()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.GetAllPatients, connection);

                using NpgsqlDataReader reader = command.ExecuteReader();
                var list = new List<PatientDto>();
                while (reader.Read())
                {
                    list.Add(new PatientDto
                    {
                        Id = reader.GetInt32(0),
                        Age = reader.GetInt32(1),
                        Height = reader.GetDouble(2),
                        Weight = reader.GetDouble(3),
                        Diagnosis = reader.GetString(4),
                        ArrivalDate = DateOnly.FromDateTime(reader.GetDateTime(5)),
                        DepartureDate = reader.IsDBNull(6) ? null : DateOnly.FromDateTime(reader.GetDateTime(6)),
                        FirstName = reader.GetString(7),
                        LastName = reader.GetString(8),
                        Gender = reader.GetString(9)
                    });
                }
                return list;
            }
        }

        // Обновляет FirstName и LastName пациента по Id
        public void UpdatePatientName(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientName, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@first_name", p.FirstName));
                command.Parameters.Add(new NpgsqlParameter("@last_name", p.LastName));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Обновляет Age и lastName пациента по Id
        public void UpdatePatientAge(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientAge, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@age", p.Age));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Обновляет Рост пациента по Id
        public void UpdatePatientHeight(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientHeight, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@height", p.Height));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Обновляет Вес пациента по Id
        public void UpdatePatientWeight(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientWeight, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@weight", p.Weight));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Обновляет Диагноз пациента по Id
        public void UpdatePatientDiagnosis(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientDiagnosis, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@diagnosis", p.Diagnosis));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Обновляет Дату поступления пациента по Id
        public void UpdatePatientArrival(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientArrival, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@arrival_date", p.ArrivalDate));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Обновляет Дату выписки пациента по Id
        public void UpdatePatientDeparture(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientDeparture, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@departure_date",
                                            p.DepartureDate.HasValue ? p.DepartureDate.Value : (object)DBNull.Value));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Обновляет Пол пациента по Id
        public void UpdatePatientGender(PatientDto p)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.UpdatePatientGender, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", p.Id));
                command.Parameters.Add(new NpgsqlParameter("@gender", p.Gender));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={p.Id} не найден для обновления");
            }
        }

        // Удаляет пациента по Id
        public void DeletePatientById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(PatientQuery.DeletePatientById, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));

                int rows = command.ExecuteNonQuery();
                if (rows == 0) throw new KeyNotFoundException($"Пациент с Id={id} не найден для удаления");
            }
        }
    }
}

