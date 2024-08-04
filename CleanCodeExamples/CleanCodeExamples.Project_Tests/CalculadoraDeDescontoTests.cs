using CleanCodeExamples.Project;
using CleanCodeExamples.Project.Interfaces;
using CleanCodeExamples.Project.Services.Factory;
using CleanCodeExamples.Project.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCodeExamples.Project_Tests;

public class CalculadoraDeDescontoTests
{
    private readonly CalculadoraDeDesconto _calculadoraDeDesconto;

    public CalculadoraDeDescontoTests()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<ICalculadoraDescontoStatusContaFactory, CalculadoraDescontosStatusContaFactory>();

        serviceCollection.AddTransient<ICalculadoraDescontoPorFidelidade, CalculadoraDescontoPorFidelidade>();
        
        serviceCollection.AddTransient<CalculadoraDeDesconto>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        _calculadoraDeDesconto = serviceProvider.GetService<CalculadoraDeDesconto>()
            ?? throw new InvalidOperationException("A instância de CalculadoraDeDesconto não pôde ser criada.");
    }

    [Theory]
    [InlineData(100, StatusDaConta.ClientePadrao, 0, 100)]
    [InlineData(100, StatusDaConta.ClienteEspecial, 2, 88.20)]
    [InlineData(100, StatusDaConta.ClienteOuro, 3, 67.90)]
    [InlineData(100, StatusDaConta.ClienteVIP, 5, 47.50)]
    public void CalculaDesconto_ValidInputs_ReturnsExpectedResults(decimal precoDoProduto, 
                                                                    StatusDaConta statusDaConta, 
                                                                    int tempoDaContaEmAnos, 
                                                                    decimal resultadoEsperado)
    {
        // Act
        var resultado = _calculadoraDeDesconto.AplicarDesconto(precoDoProduto, statusDaConta, tempoDaContaEmAnos);

        // Assert
        Assert.Equal(resultadoEsperado, resultado, 2);
    }

    [Fact]
    public void CalculaDesconto_InvalidStatusDaConta_ThrowArgumentOutOfRangeException()
    {
        // Arrange
        var precoDoProduto = 100m;
        var tempoDaContaEmAnos = 1;
        // Status Inválido
        var statusDaConta = (StatusDaConta)99;

        // Act e Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            _calculadoraDeDesconto.AplicarDesconto(precoDoProduto, statusDaConta, tempoDaContaEmAnos));
    }
}