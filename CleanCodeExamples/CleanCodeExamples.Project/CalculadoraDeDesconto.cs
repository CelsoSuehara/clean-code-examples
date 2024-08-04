using CleanCodeExamples.Project.Interfaces;

namespace CleanCodeExamples.Project;

public class CalculadoraDeDesconto
{
    private readonly ICalculadoraDescontoStatusContaFactory _calculadoraDescontoStatusContaFactory;
    private readonly ICalculadoraDescontoPorFidelidade _calculadoraDescontoPorFidelidade;

    public CalculadoraDeDesconto(
        ICalculadoraDescontoStatusContaFactory calculadoraDescontosStatusContaFactory, 
        ICalculadoraDescontoPorFidelidade calculadoraDescontoPorFidelidade)
    {
        _calculadoraDescontoStatusContaFactory = calculadoraDescontosStatusContaFactory;
        _calculadoraDescontoPorFidelidade = calculadoraDescontoPorFidelidade;
    }

    public decimal AplicarDesconto(decimal precoDoProduto, StatusDaConta statusDaConta, int tempoDaContaEmAnos)
    {
        var calculadoraDesconto = _calculadoraDescontoStatusContaFactory.GetCalculoDescontoStatusConta(statusDaConta);

        var precoComDescontoStatus = calculadoraDesconto.AplicarDesconto(precoDoProduto);

        var precoFinal = _calculadoraDescontoPorFidelidade.CalcularDesconto(precoComDescontoStatus, tempoDaContaEmAnos);

        return precoFinal;
    }
}