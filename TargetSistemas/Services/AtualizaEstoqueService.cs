using TargetSistemas.Models;

namespace TargetSistemas.Services;

public class AtualizaEstoqueService
{
    public static int AtualizarEstoque(Produto produto, int quantidade, string tipoDeMovimentacao)
    {
        if (tipoDeMovimentacao == "E")
        {
            produto.Estoque += quantidade;
        }
        else
        {
            produto.Estoque -= quantidade;
        }

        return produto.Estoque;
    }
}
