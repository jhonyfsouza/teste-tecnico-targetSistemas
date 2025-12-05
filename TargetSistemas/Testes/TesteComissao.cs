using System.Text.Json;
using TargetSistemas.Models;
using TargetSistemas.Services;

namespace TargetSistemas.Testes;

public static class TesteComissao
{
    public static void Executar()
    {
        try
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "registroDeVendas.json"
            );

            if (!File.Exists(path))
            {
                Console.WriteLine("Arquivo JSON não encontrado!");
                Console.WriteLine(path);
                return;
            }

            string json = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            ListaDeVendas? record = JsonSerializer.Deserialize<ListaDeVendas>(json, options);

            if (record is null || record.Vendas is null)
            {
                Console.WriteLine("Nenhuma venda encontrada.");
                return;
            }

            var total = CalculadorDeComissaoService.CalculaComissaoDoVendedor(record.Vendas);

            foreach (var item in total)
            {
                Console.WriteLine($"{item.Key}: R$ {item.Value:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
    }
}