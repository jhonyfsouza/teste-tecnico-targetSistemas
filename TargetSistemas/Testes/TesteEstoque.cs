using System.Text.Json;
using TargetSistemas.Models;
using TargetSistemas.Services;

namespace TargetSistemas.Testes;
public static class TesteEstoque
{
    public static void Executar()
    {
        int idMovimentacao = 1;

        string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "estoque.json");

        if (!File.Exists(path))
            {
                Console.WriteLine("Arquivo JSON não encontrado!");
                return;
            }
        
        string json = File.ReadAllText(path);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var records = JsonSerializer.Deserialize<ListaDeEstoque>(json, options);

        if (records is null || records.Estoque is null || records.Estoque!.Count == 0)
        {
            Console.WriteLine("Nenhum produto encontrado!");
            return;
        }

        while (true)
        {
            Console.Write("Informe o código do produto: ");
            int codigo = int.Parse(Console.ReadLine()!);

            var produto = records.Estoque.FirstOrDefault(x => x.CodigoProduto == codigo);

            if (produto is null)
            {
                Console.WriteLine("Produto não encontrado!");
                continue;
            }

            Console.Write("Informe o tipo da movimentação (E = Entrada / S = Saída): ");
            string tipo = Console.ReadLine()!.Trim().ToUpper();

            if (tipo != "E" && tipo != "S")
            {
                Console.WriteLine("Informe apenas E ou S");
                continue;
            }

            Console.Write("Informe a Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine()!);

            if (tipo == "S" && quantidade > produto.Estoque)
            {
                Console.WriteLine("Quantidade informada é maior do que o estoque!");
                continue;
            }

            int estoqueFinal = AtualizaEstoqueService.AtualizarEstoque(produto, quantidade, tipo);
            

            Console.WriteLine($"Identificador da movimentação: {idMovimentacao}");
            Console.WriteLine($"Quantidade atualizada em estoque de {produto.DescricaoProduto} : {estoqueFinal}");

            idMovimentacao++;

            Console.Write("Deseja continuar? (S = SIM / N = NÃO): ");
            string continua = Console.ReadLine()!.Trim().ToUpper();

            if (continua != "S" && continua != "N")
            {
                Console.WriteLine("Informe apenas S ou N");
                continue;
            }

            if (continua != "S")
            {
                break;
            }
        }
    }
}