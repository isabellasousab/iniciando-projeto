
using cadastro_clientes.Model;
using cadastro_clientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_clientes.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService ClienteService)
    {
        _clienteService = ClienteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> Listar()
    {
        List<Cliente> Cliente =
            await _clienteService.ListarTodosAsync();

        return Ok(Cliente);
    }
}
