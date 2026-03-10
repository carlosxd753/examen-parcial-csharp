public class CitaService : ICitaService
{
    private readonly List<Cita> citas = new List<Cita>();
    private int nextId = 1;

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