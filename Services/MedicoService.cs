public class MedicoService : IMedicoService
{
    private static List<Medico> medicos = new List<Medico>
    {
        new Medico
        {
            Id = 1,
            Nombre = "Dr. Juan Perez",
            Telefono = "919111222",
            Email = "drjuan@correo.com",
            Especialidad = Especialidad.Cardiologia
        },
        new Medico
        {
            Id = 2,
            Nombre = "Dr. Maria Lopez",
            Telefono = "918333444",
            Email = "drmaria@correo.com",
            Especialidad = Especialidad.Dermatologia
        },
        new Medico
        {
            Id = 3,
            Nombre = "Dr. Carlos Gomez",
            Telefono = "917555666",
            Email = "drcarlos@correo.com",
            Especialidad = Especialidad.Pediatria
        }
    };
    private int nextId = 4;

    public List<Medico> ObtenerTodos()
    {
        return medicos;
    }

    public Medico? ObtenerPorId(int id)
    {
        return medicos.FirstOrDefault(m => m.Id == id);
    }

    public Medico Crear(Medico medico)
    {
        medico.Id = nextId++;
        medicos.Add(medico);
        return medico;
    }

    public bool Eliminar(int id)
    {
        var medico = ObtenerPorId(id);

        if (medico == null)
            return false;

        medicos.Remove(medico);
        return true;
    }
}
