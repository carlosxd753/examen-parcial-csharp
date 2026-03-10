public interface IPacienteService
{
    List<Paciente> ObtenerTodos();
    Paciente? ObtenerPorId(int id);
    Paciente Crear(Paciente paciente);
    bool Eliminar(int id);
}