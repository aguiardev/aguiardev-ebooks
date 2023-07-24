using Api.Minimal.Models;
using Api.Minimal.Repositories;
using Api.Minimal.Repositories.Interfaces;
using Api.Minimal.Services;
using Api.Minimal.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IBancoDeDados, BancoDeDados>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/pedido", (PedidoModel model, IPedidoService pedido) =>
{
    if (pedido.SalvarNoBanco(model.Valor))
    {
        return Results.Ok(new MensagemModel() { Mensagem = "", Sucesso = true });
    }
    else
    {
        return Results.BadRequest(new MensagemModel()
        {
            Mensagem = "Algo deu errado.",
            Sucesso = false
        });
    }
})
.WithName("PostPedido")
.WithOpenApi();

app.Run();