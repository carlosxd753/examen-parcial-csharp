public class PacienteService : IPacienteService
{
    private static List<Paciente> pacientes = new List<Paciente>
    {
        new Paciente
        {
            Id = 1,
            Nombre = "Juan Perez",
            Telefono = "999111222",
            Email = "juan@correo.com"
        },
        new Paciente
        {
            Id = 2,
            Nombre = "Maria Lopez",
            Telefono = "988333444",
            Email = "maria@correo.com"
        }
    };
    private static int nextId = 3;

    public List<Paciente> ObtenerTodos()
    {
        return pacientes;
    }

    public Paciente? ObtenerPorId(int id)
    {
        return pacientes.FirstOrDefault(p => p.Id == id);
    }

    public Paciente Crear(Paciente paciente)
    {
        paciente.Id = nextId++;
        pacientes.Add(paciente);
        return paciente;
    }

    public bool Eliminar(int id)
    {
        var paciente = ObtenerPorId(id);
        if (paciente == null)
            return false;

        pacientes.Remove(paciente);
        return true;
    }
}