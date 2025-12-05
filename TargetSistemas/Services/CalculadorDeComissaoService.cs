using TargetSistemas.Models;

namespace TargetSistemas.Services
{
    public class CalculadorDeComissaoService
    {
        public static double CalcularComissao(double valor)
        {
            double percentualMinimo = 0.01;
            double PercentualMaximo = 0.05;

            if (valor < 100)
            {
                return 0;
            }

            if (valor < 500)
            {
                return valor * percentualMinimo;
            }

            return valor * PercentualMaximo;
        }

        public static Dictionary<string, double> CalculaComissaoDoVendedor(List<Venda> vendas)
        {
            var result = new Dictionary<string, double>();

            if (vendas == null)
            {
                return result;
            }

            foreach (var venda in vendas)
            {
                var commissao = CalcularComissao(venda.Valor);

                if (!result.ContainsKey(venda.Vendedor))
                    result[venda.Vendedor] = 0;

                result[venda.Vendedor] += commissao;
            }

            return result;
        }
    }
}
