using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.WebApi.Models;

namespace AspNetCore.WebApi.Repositories
{
    public interface ILivroRepository
    {

        Task Save(Livro livro);

        Task Update(Livro livro);

         Task Delete(Livro livro);

        Task<List<Livro>> Consult();

         Task<Livro> ConsultById(int id);

        Task Commit();

  
        
    }
}