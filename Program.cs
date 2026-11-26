
using cadastro_clientes.Data;
using cadastro_clientes.Services;
using cadastro_clientes.Repositories;

WebApplicationBuilder builder =
    WebApplication.CreateBuilder(args);

// Habilita o uso de Controllers.
builder.Services.AddControllers();

// Registra a classe de conexão.
builder.Services.AddSingleton<ConexaoBanco>();

// Registra as dependências de clientes.
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

WebApplication app = builder.Build();

app.MapControllers();

await app.StartAsync();

Console.WriteLine();
Console.WriteLine("Listar clientes: http://localhost:5227/api/clientes");
Console.WriteLine("http://localhost:5227/api/conexao/testar");

await app.WaitForShutdownAsync();
