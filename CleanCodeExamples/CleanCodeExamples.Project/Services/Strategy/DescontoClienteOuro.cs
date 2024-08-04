using CleanCodeExamples.Project.Interfaces;

namespace CleanCodeExamples.Project.Services.Strategy;

public class DescontoClienteOuro : ICalculadoraDesconto
{
    public decimal AplicarDesconto(decimal preco)
    {
        return preco - (Constantes.DESCONTO_CLIENTE_OURO * preco);
    }
}
