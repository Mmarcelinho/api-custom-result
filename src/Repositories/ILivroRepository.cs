namespace AspNetCore.WebApi.Repositories;

public interface ILivroRepository
{

    Task Save(Livro livro);

    void Update(Livro livro);

    void Delete(Livro livro);

    Task<List<Livro>> Consult();

    Task<Livro> ConsultById(int id);

    Task Commit();

}
