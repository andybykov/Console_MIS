using MIS.Core;
using MIS.Core.Dtos;
using MIS.DAL.Queries;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
    public class ProcedureRepository
    {
        public int AddProcedure(ProcedureDto dto)
        {
            using var connection = new NpgsqlConnection(Options.ConnectionString);
            connection.Open();
            using var command = new NpgsqlCommand(ProcedureQuery.AddProcedure, connection);
            command.Parameters.AddWithValue("@name", dto.Name);
            command.Parameters.AddWithValue("@comment", dto.Comment ?? (object)DBNull.Value);

            return (int)command.ExecuteScalar()!;
        }

        public ProcedureDto GetProcedureById(int id)
        {
            using var connection = new NpgsqlConnection(Options.ConnectionString);
            connection.Open();
            using var command = new NpgsqlCommand(ProcedureQuery.GetProcedureById, connection);
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
                return new ProcedureDto
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Comment = reader.IsDBNull(2) ? null : reader.GetString(2)
                };
            throw new KeyNotFoundException($"Процедура с Id={id} не найдена.");
        }

        public List<ProcedureDto> GetAllProcedures()
        {
            using var connection = new NpgsqlConnection(Options.ConnectionString);
            connection.Open();
            using var command = new NpgsqlCommand(ProcedureQuery.GetAllProcedures, connection);

            var list = new List<ProcedureDto>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
                list.Add(new ProcedureDto
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Comment = reader.IsDBNull(2) ? null : reader.GetString(2)
                });
            return list;
        }

        public void UpdateProcedure(ProcedureDto dto)
        {
            using var connection = new NpgsqlConnection(Options.ConnectionString);
            connection.Open();
            using var command = new NpgsqlCommand(ProcedureQuery.UpdateProcedure, connection);
            command.Parameters.AddWithValue("@id", dto.Id);
            command.Parameters.AddWithValue("@name", dto.Name);
            command.Parameters.AddWithValue("@comment", dto.Comment ?? (object)DBNull.Value);

            var rows = command.ExecuteNonQuery();
            if (rows == 0)
                throw new KeyNotFoundException($"Процедура с Id={dto.Id} не найдена для обновления.");
        }

        public void DeleteProcedure(int id)
        {
            using var connection = new NpgsqlConnection(Options.ConnectionString);
            connection.Open();
            using var command = new NpgsqlCommand(ProcedureQuery.DeleteProcedure, connection);
            command.Parameters.AddWithValue("@id", id);

            var rows = command.ExecuteNonQuery();
            if (rows == 0)
                throw new KeyNotFoundException($"Процедура с Id={id} не найдена для удаления.");
        }
    }
}
