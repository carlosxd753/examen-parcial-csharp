using System.ComponentModel.DataAnnotations;

public class Medico
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = "";

    [Required]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "El telefono debe tener exactamente 9 digitos")]

    public string Telefono { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public Especialidad Especialidad { get; set; }
}