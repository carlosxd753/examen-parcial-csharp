using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PacientesController : ControllerBase
{
    private readonly IPacienteService _service;

    public PacientesController(IPacienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        var pacientes = _service.ObtenerTodos();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var paciente = _service.ObtenerPorId(id);

        if (paciente == null)
            return NotFound();

        return Ok(paciente);
    }

    [HttpPost]
    public IActionResult Crear(Paciente paciente)
    {
        var nuevo = _service.Crear(paciente);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var eliminado = _service.Eliminar(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}