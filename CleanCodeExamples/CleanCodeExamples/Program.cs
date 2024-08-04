using CleanCodeExamples.Project;
using CleanCodeExamples.Project.Interfaces;
using CleanCodeExamples.Project.Services;
using CleanCodeExamples.Project.Services.Factory;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddScoped<ICalculadoraDescontoStatusContaFactory, CalculadoraDescontosStatusContaFactory>()
    .AddScoped<ICalculadoraDescontoPorFidelidade, CalculadoraDescontoPorFidelidade>()
    .AddScoped<CalculadoraDeDesconto>()
    .BuildServiceProvider();

var calculadoraDeDesconto = serviceProvider.GetService<CalculadoraDeDesconto>()
    ?? throw new InvalidOperationException("A instância de CalculadoraDeDesconto não pôde ser criada.");

decimal precoProduto = 100m;
int tempoDaContaEmAnos = 3;

decimal precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto, StatusDaConta.ClientePadrao, tempoDaContaEmAnos);
Console.WriteLine($"\nCliente Padrão - Preço com Desconto: {precoComDesconto:C}");

precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto, StatusDaConta.ClienteEspecial, tempoDaContaEmAnos);
Console.WriteLine($"\nCliente Especial - Preço com Desconto: {precoComDesconto:C}");

precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto, StatusDaConta.ClienteOuro, tempoDaContaEmAnos);
Console.WriteLine($"\nCliente Ouro - Preço com Desconto: {precoComDesconto:C}");

precoComDesconto = calculadoraDeDesconto.AplicarDesconto(precoProduto, StatusDaConta.ClienteVIP, tempoDaContaEmAnos);
Console.WriteLine($"\nCliente VIP - Preço com Desconto: {precoComDesconto:C}");

Console.ReadLine();