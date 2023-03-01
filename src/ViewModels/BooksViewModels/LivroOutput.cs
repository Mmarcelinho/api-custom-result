namespace AspNetCore.WebApi.ViewModels.BooksViewModels;

public class LivroOutput
{
    public LivroOutput(int id, string titulo, string categoria, int quantidade, decimal preco, string autor, DateTime dataCriacao, bool ativo)
    {
        this.Id = id;
        this.Titulo = titulo;
        this.Categoria = categoria;
        this.Quantidade = quantidade;
        this.Preco = preco;
        this.Autor = autor;
        this.DataCriacao = dataCriacao;
        this.Ativo = ativo;

    }
    public int Id { get; private set; }

    public string Titulo { get; private set; }

    public string Categoria { get; private set; }

    public int Quantidade { get; private set; }

    public decimal Preco { get; private set; }

    public string Autor { get; private set; }

    public DateTime DataCriacao { get;private set; }

    public bool Ativo { get; private set; }
}
