using TargetSistemas.Services;

namespace TargetSistemas.Testes;

public static class TesteJuros
{
    public static void Executar()
    {
        DateTime dataEHoraAtual = DateTime.UtcNow;
        DateOnly dataAtual = DateOnly.FromDateTime(dataEHoraAtual);

        Console.Write("Digite o valor: ");
        double valor = double.Parse(Console.ReadLine()!);

        Console.Write("Informe a data de vencimento: ");
        DateOnly dataDeVencimento = DateOnly.Parse(Console.ReadLine()!);
        if (dataDeVencimento >= dataAtual)
        {
            Console.WriteLine("Fatura não está em atraso!");
            return;
        }

        double jurosCalculado = CalculadorDeJurosService.Calcular(valor, dataDeVencimento);

        Console.WriteLine($"O Juros calculado até hoje é de: R$ {jurosCalculado:C2}");
    }
}
