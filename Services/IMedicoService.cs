public interface IMedicoService
{
    List<Medico> ObtenerTodos();
    Medico? ObtenerPorId(int id);
    Medico Crear(Medico medico);
    bool Eliminar(int id);
}