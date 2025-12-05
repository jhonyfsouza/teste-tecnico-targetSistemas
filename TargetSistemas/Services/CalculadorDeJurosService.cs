namespace TargetSistemas.Services;

public static class CalculadorDeJurosService
{
    public static double Calcular(double valor, DateOnly dataDeVencimento)
    {
        double multaDiaria = 2.5/100;

        DateOnly dataDeHoje = DateOnly.FromDateTime(DateTime.Today);
        int diasEmAtraso = dataDeHoje.DayNumber - dataDeVencimento.DayNumber;

        double juros = valor * multaDiaria * diasEmAtraso;

        return juros;
    }
}

