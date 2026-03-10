using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MedicosController : ControllerBase
{
    private readonly IMedicoService _service;

    public MedicosController(IMedicoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        var medicos = _service.ObtenerTodos();
        return Ok(medicos);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var medico = _service.ObtenerPorId(id);

        if (medico == null)
            return NotFound();

        return Ok(medico);
    }

    [HttpPost]
    public IActionResult Crear(Medico medico)
    {
        var nuevo = _service.Crear(medico);
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