namespace Employee_API.Models
{
    public record EmployeDtos(
        string Matricule,
        string Name,
        string? LastName,
        string Email,
        DateTime DateOfBirth,
        string? Position
    );
}
