using Api.Minimal.Repositories.Interfaces;
using Api.Minimal.Services;

namespace Tests;

public class PedidoTestes
{
    [Fact]
    public void SalvarNoBanco_ValorAbaixoDoMinimo_DeveRetornarFalso()
    {
        // Arrange
        const double valor = 39.17;
        var bancoDeDadosMock = new Mock<IBancoDeDados>();
        var pedido = new PedidoService(bancoDeDadosMock.Object);

        // Act
        bool resultado = pedido.SalvarNoBanco(valor);

        // Assert
        Assert.False(resultado);
        bancoDeDadosMock.Verify(b => b.Salvar(It.IsAny<double>()), Times.Never);
    }

    [Fact]
    public void SalvarNoBanco_ValorAcimaDoMinimo_DeveRetornarVerdadeiro()
    {
        // Arrange
        const double valor = 150.0;
        var bancoDeDadosMock = new Mock<IBancoDeDados>();
        var pedido = new PedidoService(bancoDeDadosMock.Object);

        // Act
        bool resultado = pedido.SalvarNoBanco(valor);

        // Assert
        Assert.True(resultado);
        bancoDeDadosMock.Verify(b => b.Salvar(valor), Times.Once);
    }
}