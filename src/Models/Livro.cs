using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.WebApi.Models
{
    public class Livro
    {   
        
        public int Id { get; private set; }

        public string Titulo { get; private set; }

        public string Categoria { get; private set; }

        public int Quantidade { get; private set; }

        public decimal Preco { get; private set; }

       
        public string Autor { get; private set; }

        public bool Ativo { get; private set; }

        public Livro(int id, string titulo, string categoria, int quantidade, decimal preco, string autor, bool ativo){

            Id = id;
            Titulo = titulo;
            Categoria = categoria;
            Quantidade = quantidade;
            Preco = preco;
            Autor = autor;
            Ativo = ativo;
        }

       
    }
}