using MIS.Core;
using MIS.Core.Dtos;
using MIS.DAL.Queries;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace MIS.DAL
{
 
    // Репозиторий для работы с таблицей листов назначений (Treatment_list) 
    public class TreatmentListRepository
    {      
        // Создает новую запись листа назначения и возвращает его Id        
        public int AddTreatmentList(TreatmentListDto tlist)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(TreatmentListQuery.AddTreatmentList, connection);
                command.Parameters.Add(new NpgsqlParameter("@date", tlist.CurrentDate));
                command.Parameters.Add(new NpgsqlParameter("@procId", tlist.ProcedureId ?? (object)DBNull.Value));
                command.Parameters.Add(new NpgsqlParameter("@drugId", tlist.DrugId ?? (object)DBNull.Value));
                command.Parameters.Add(new NpgsqlParameter("@pdId", tlist.PatientDoctorId));

                int id = (int)command.ExecuteScalar()!;
                return id;
            }
        }

        // Возвращает один лист назначения по Id
        public TreatmentListDto GetTreatmentListById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(TreatmentListQuery.GetTreatmentListById, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));

                using NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new TreatmentListDto
                    {
                        Id = reader.GetInt32(0),
                        CurrentDate = DateOnly.FromDateTime(reader.GetDateTime(1)),
                        ProcedureId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                        ProcedureName = reader.IsDBNull(3) ? null : reader.GetString(3),
                        DrugId = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                        DrugName = reader.IsDBNull(5) ? null : reader.GetString(5),
                        DrugDose = reader.IsDBNull(6) ? null : reader.GetDouble(6),
                        DrugUnits = reader.IsDBNull(7) ? null : reader.GetString(7),
                        DrugComment = reader.IsDBNull(8) ? null : reader.GetString(8),
                        PatientDoctorId = reader.GetInt32(9),
                        PatientId = reader.GetInt32(10),
                        PatientName = reader.GetString(11),
                        DoctorId = reader.GetInt32(12),
                        DoctorName = reader.GetString(13)
                    };
                }
                throw new KeyNotFoundException($"Лист назначений с Id={id} не найден");
            }
        }

        
        // Возвращает список всех листов назначений        
        public List<TreatmentListDto> GetAllTreatmentLists()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(TreatmentListQuery.GetAllTreatmentLists, connection);

                using NpgsqlDataReader reader = command.ExecuteReader();
                var list = new List<TreatmentListDto>();
                while (reader.Read())
                {
                    list.Add(new TreatmentListDto
                    {
                        Id = reader.GetInt32(0),
                        CurrentDate = DateOnly.FromDateTime(reader.GetDateTime(1)),
                        ProcedureId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                        ProcedureName = reader.IsDBNull(3) ? null : reader.GetString(3),
                        DrugId = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                        DrugName = reader.IsDBNull(5) ? null : reader.GetString(5),
                        DrugDose = reader.IsDBNull(6) ? null : reader.GetDouble(6),
                        DrugUnits = reader.IsDBNull(7) ? null : reader.GetString(7),
                        DrugComment = reader.IsDBNull(8) ? null : reader.GetString(8),
                        PatientDoctorId = reader.GetInt32(9),
                        PatientId = reader.GetInt32(10),
                        PatientName = reader.GetString(11),
                        DoctorId = reader.GetInt32(12),
                        DoctorName = reader.GetString(13)
                    });
                }
                //if(reader.Read()!) throw new KeyNotFoundException($"Листы назначений не найдены");
                return list;
            }
        }

        // Возвращает все листы назначений по Id врача
        public List<TreatmentListDto> GetTreatmentListsByDoctorId(int doctorId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(TreatmentListQuery.GetAllTreatmentListsByDoctorId, connection);
                command.Parameters.Add(new NpgsqlParameter("@doctorId", doctorId));

                using NpgsqlDataReader reader = command.ExecuteReader();
                var list = new List<TreatmentListDto>();
                
                while (reader.Read())
                {
                    list.Add(new TreatmentListDto
                    {
                        Id = reader.GetInt32(0),
                        CurrentDate = DateOnly.FromDateTime(reader.GetDateTime(1)),
                        ProcedureId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                        ProcedureName = reader.IsDBNull(3) ? null : reader.GetString(3),
                        DrugId = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                        DrugName = reader.IsDBNull(5) ? null : reader.GetString(5),
                        DrugDose = reader.IsDBNull(6) ? null : reader.GetDouble(6),
                        DrugUnits = reader.IsDBNull(7) ? null : reader.GetString(7),
                        DrugComment = reader.IsDBNull(8) ? null : reader.GetString(8),
                        PatientDoctorId = reader.GetInt32(9),
                        PatientId = reader.GetInt32(10),
                        PatientName = reader.GetString(11),
                        DoctorId = reader.GetInt32(12),
                        DoctorName = reader.GetString(13)
                    });
                }
                //if (!reader.Read()) throw new KeyNotFoundException($"Листы назначений с doctorId={doctorId} не найдены");
                return list;
            }
        }

        
        // Возвращает все листы назначений по Id пациента
        public List<TreatmentListDto> GetAllTreatmentListsByPatientId(int patientId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(TreatmentListQuery.GetAllTreatmentListsByPatientId, connection);
                command.Parameters.Add(new NpgsqlParameter("@patientId", patientId));

                using NpgsqlDataReader reader = command.ExecuteReader();
                var list = new List<TreatmentListDto>();
                
                while (reader.Read())
                {
                    list.Add(new TreatmentListDto
                    {
                        Id = reader.GetInt32(0),
                        CurrentDate = DateOnly.FromDateTime(reader.GetDateTime(1)),
                        ProcedureId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                        ProcedureName = reader.IsDBNull(3) ? null : reader.GetString(3),
                        DrugId = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                        DrugName = reader.IsDBNull(5) ? null : reader.GetString(5),
                        DrugDose = reader.IsDBNull(6) ? null : reader.GetDouble(6),
                        DrugUnits = reader.IsDBNull(7) ? null : reader.GetString(7),
                        DrugComment = reader.IsDBNull(8) ? null : reader.GetString(8),
                        PatientDoctorId = reader.GetInt32(9),
                        PatientId = reader.GetInt32(10),
                        PatientName = reader.GetString(11),
                        DoctorId = reader.GetInt32(12),
                        DoctorName = reader.GetString(13)
                    });
                }
                //if (!reader.Read()) throw new KeyNotFoundException($"Листы назначений с patientId={patientId} не найдены");
                return list;
            }
        }

        
        // Обновляет существующий лист назначения
        public void UpdateTreatmentList(TreatmentListDto tlist)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(TreatmentListQuery.UpdateTreatmentList, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", tlist.Id));
                command.Parameters.Add(new NpgsqlParameter("@date", tlist.CurrentDate));
                command.Parameters.Add(new NpgsqlParameter("@procId", tlist.ProcedureId ?? (object)DBNull.Value));
                command.Parameters.Add(new NpgsqlParameter("@drugId", tlist.DrugId ?? (object)DBNull.Value));
                command.Parameters.Add(new NpgsqlParameter("@pdId", tlist.PatientDoctorId));

                int rows = command.ExecuteNonQuery();
                if (rows == 0)
                    throw new KeyNotFoundException($"Лист назначений с Id={tlist.Id} не найден");
            }
        }

        
        // Удаляет лист назначения по Id        
        public void DeleteTreatmentListById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();
                using NpgsqlCommand command = new NpgsqlCommand(TreatmentListQuery.DeleteTreatmentList, connection);
                command.Parameters.Add(new NpgsqlParameter("@id", id));

                int rows = command.ExecuteNonQuery();
                if (rows == 0)
                    throw new KeyNotFoundException($"Лист назначений с Id={id} не найден");
            }
        }
        

    }
}