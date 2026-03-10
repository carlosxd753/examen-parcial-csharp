public interface ICitaService
{
    List<Cita> ObtenerTodos();
    Cita? ObtenerPorId(int id);
    Cita Crear(Cita cita);
    bool Cancelar(int id);
}