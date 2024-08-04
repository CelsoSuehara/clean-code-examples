namespace CleanCodeExamples.Project.Interfaces;

public interface ICalculadoraDescontoPorFidelidade
{
    decimal CalcularDesconto(decimal precoProduto, int tempoDaContaEmAnos);
}
