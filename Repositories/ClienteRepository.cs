
using cadastro_clientes.Data;
using cadastro_clientes.Model;
using Npgsql;

namespace cadastro_clientes.Repositories;

public class ClienteRepository
{
    private readonly ConexaoBanco _conexaoBanco;

    public ClienteRepository(ConexaoBanco conexaoBanco)
    {
        _conexaoBanco = conexaoBanco;
    }

    public async Task<List<Cliente>> ListarTodosAsync()
    {
        List<Cliente> Clientes = new();

        await using NpgsqlConnection conexao =
            await _conexaoBanco.CriarConexaoAsync();

        string sql = """
            SELECT id_cliente, nome, cpf, email, telefone, data_nascimento, ativo
            FROM cliente
            ORDER BY nome;
            """;

        await using NpgsqlCommand comando =
            new NpgsqlCommand(sql, conexao);

        await using NpgsqlDataReader leitor =
            await comando.ExecuteReaderAsync();

        int colunaIdCliente = leitor.GetOrdinal("id_cliente");
        int colunaNome = leitor.GetOrdinal("nome");
        int colunaCpf = leitor.GetOrdinal("cpf");
        int colunaEmail = leitor.GetOrdinal("email");
        int colunaTelefone = leitor.GetOrdinal("telefone");
        int colunaDataNascimento = leitor.GetOrdinal("data_nascimento");
        int colunaAtivo = leitor.GetOrdinal("ativo");

        while (await leitor.ReadAsync())
        {
            Cliente Cliente = new Cliente(
                leitor.GetInt32(colunaIdCliente),
                leitor.GetString(colunaNome),
                leitor.GetString(colunaCpf),
                leitor.GetString(colunaEmail),
                leitor.GetString(colunaTelefone),
                leitor.GetDateTime(colunaDataNascimento).ToString("yyyy-MM-dd"),
                leitor.GetBoolean(colunaAtivo)
            );

            Clientes.Add(Cliente);
        }

        return Clientes;
    }
}
