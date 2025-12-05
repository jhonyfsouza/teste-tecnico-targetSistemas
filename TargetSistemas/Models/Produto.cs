namespace TargetSistemas.Models;

public class Produto
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = default!;
    public int Estoque { get; set; }
}
