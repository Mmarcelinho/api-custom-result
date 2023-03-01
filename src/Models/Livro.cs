namespace AspNetCore.WebApi.Models;

    public class Livro
{

    public Livro(int id, string titulo, string categoria, int quantidade, decimal preco, string autor)
    {

        Id = id;
        Titulo = titulo;
        Categoria = categoria;
        Quantidade = quantidade;
        Preco = preco;
        Autor = autor;
        DataCriacao = DateTime.Now;
        Ativo = true;
    }

    public int Id { get; private set; }

    public string Titulo { get; private set; }

    public string Categoria { get; private set; }

    public int Quantidade { get; private set; }

    public decimal Preco { get; private set; }

    public string Autor { get; private set; }

    public DateTime DataCriacao { get; private set; }

    public bool Ativo { get; private set; }


}
