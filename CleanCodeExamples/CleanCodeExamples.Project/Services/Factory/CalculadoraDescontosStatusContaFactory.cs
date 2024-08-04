using CleanCodeExamples.Project.Interfaces;
using CleanCodeExamples.Project.Services.Strategy;

namespace CleanCodeExamples.Project.Services.Factory;

public class CalculadoraDescontosStatusContaFactory : ICalculadoraDescontoStatusContaFactory
{
    public ICalculadoraDesconto GetCalculoDescontoStatusConta(StatusDaConta statusDaConta)
    {
        ICalculadoraDesconto calculadora;

        switch (statusDaConta)
        {
            case StatusDaConta.ClientePadrao:
                calculadora = new DescontoClientePadrao();
                break;
            case StatusDaConta.ClienteEspecial:
                calculadora = new DescontoClienteEspecial();
                break;
            case StatusDaConta.ClienteOuro:
                calculadora = new DescontoClienteOuro();
                break;
            case StatusDaConta.ClienteVIP:
                calculadora = new DescontoClienteVIP();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return calculadora;

    }
}
