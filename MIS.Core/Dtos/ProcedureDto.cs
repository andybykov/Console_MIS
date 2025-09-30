namespace MIS.Core.Dtos;

public class ProcedureDto
{
    public int Id { get; set; }
    public required string Name { get; set; } //= string.Empty;
    public required string? Comment { get; set; }
}
