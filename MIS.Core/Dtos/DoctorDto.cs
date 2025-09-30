namespace MIS.Core.Dtos
{
    // модель Data Transfer Object
    // содержит модель структуры таблицы Doctor в БД
    public class DoctorDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
