using Api.ComInjecao.Models;
using Api.ComInjecao.Services.Interfaces;

namespace Api.ComInjecao.Services
{
    public class PedidoService : IPedidoService
    {
        private const double VALOR_MINIMO = 100;
        private readonly BancoDeDados _bancoDeDados;

        public PedidoService()
        {
            _bancoDeDados = new BancoDeDados();
        }

        public bool SalvarNoBanco(double valor)
        {
            if (valor < VALOR_MINIMO)
                return false;

            _bancoDeDados.Salvar(valor);
            return true;
        }
    }
}