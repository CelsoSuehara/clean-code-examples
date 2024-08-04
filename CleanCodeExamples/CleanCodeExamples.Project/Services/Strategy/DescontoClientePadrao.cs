using CleanCodeExamples.Project.Interfaces;

namespace CleanCodeExamples.Project.Services.Strategy;

public class DescontoClientePadrao : ICalculadoraDesconto
{
    public decimal AplicarDesconto(decimal preco)
    {
        return preco;
    }
}