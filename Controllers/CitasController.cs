using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CitasController : ControllerBase
{
    private readonly ICitaService _service;
    private readonly IMedicoService _medicoService;
    private readonly IPacienteService _pacienteService;

    public CitasController(ICitaService service, IMedicoService medicoService, IPacienteService pacienteService)
    {
        _service = service;
        _medicoService = medicoService;
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        var citas = _service.ObtenerTodos();
        return Ok(citas);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var cita = _service.ObtenerPorId(id);

        if (cita == null)
            return NotFound();

        return Ok(cita);
    }

    [HttpPost]
    public IActionResult Crear(Cita cita)
    {
        var medico = _medicoService.ObtenerPorId(cita.MedicoId);
        if (medico == null)
            return BadRequest($"No existe un médico con ID {cita.MedicoId}");
        
        var paciente = _pacienteService.ObtenerPorId(cita.PacienteId);
        if (paciente == null)
            return BadRequest($"No existe un paciente con ID {cita.PacienteId}");

        var nuevo = _service.Crear(cita);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
    }

    [HttpDelete("{id}")]
    public IActionResult Cancelar(int id)
    {
        var cancelado = _service.Cancelar(id);

        if (!cancelado)
            return NotFound();

        return NoContent();
    }
}