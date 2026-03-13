public class CitaService : ICitaService
{
    private readonly List<Cita> citas = new List<Cita>
    {
        new Cita
        {
            Id = 1,
            Fecha = DateTime.Now.AddDays(1),
            PacienteId = 1,
            MedicoId = 1,
            Estado = EstadoCita.Confirmada
        },
        new Cita
        {
            Id = 2,
            Fecha = DateTime.Now.AddDays(2),
            PacienteId = 2,
            MedicoId = 2,
            Estado = EstadoCita.Confirmada
        },
        new Cita
        {
            Id = 3,
            Fecha = DateTime.Now.AddDays(3),
            PacienteId = 2,
            MedicoId = 3,
            Estado = EstadoCita.Confirmada
        }
    };
    private int nextId = 4;

    public Cita Crear(Cita cita)
    {
        cita.Id = nextId++;
        citas.Add(cita);
        return cita;
    }

    public List<Cita> ObtenerTodos()
    {
        return citas;
    }

    public Cita? ObtenerPorId(int id)
    {
        return citas.FirstOrDefault(c => c.Id == id);
    }

    public bool Cancelar(int id)
    {
        var cita = ObtenerPorId(id);
        
        if (cita == null)
            return false;

        if (cita.Estado == EstadoCita.Cancelada)
            return false;

        cita.Estado = EstadoCita.Cancelada;
        return true;
    }
}