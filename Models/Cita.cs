using System.ComponentModel.DataAnnotations;

public class Cita
{
    public int Id { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public int PacienteId { get; set; }

    [Required]
    public int MedicoId { get; set; }

    [Required]
    public EstadoCita Estado { get; set; }
}