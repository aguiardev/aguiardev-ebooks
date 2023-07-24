using Api.Minimal.Repositories.Interfaces;
using Api.Minimal.Services.Interfaces;

namespace Api.Minimal.Services;

public class PedidoService : IPedidoService
{
    private const double VALOR_MINIMO = 100;
    private readonly IBancoDeDados _bancoDeDados;

    public PedidoService(IBancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public bool SalvarNoBanco(double valor)
    {
        if (valor < VALOR_MINIMO)
            return false;

        _bancoDeDados.Salvar(valor);
        return true;
    }
}