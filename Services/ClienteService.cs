
using cadastro_clientes.Model;
using cadastro_clientes.Repositories;

namespace cadastro_clientes.Services;

public class ClienteService
{
    private readonly ClienteRepository _ClienteRepository;

    public ClienteService(ClienteRepository ClienteRepository)
    {
        _ClienteRepository = ClienteRepository;
    }

    public async Task<List<Cliente>> ListarTodosAsync()
    {
        return await _ClienteRepository.ListarTodosAsync();
    }
}
