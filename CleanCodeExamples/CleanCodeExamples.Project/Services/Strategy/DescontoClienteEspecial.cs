using CleanCodeExamples.Project.Interfaces;

namespace CleanCodeExamples.Project.Services.Strategy;

public class DescontoClienteEspecial : ICalculadoraDesconto
{
    public decimal AplicarDesconto(decimal preco)
    {
        return preco - (Constantes.DESCONTO_CLIENTE_ESPECIAL * preco);
    }
}