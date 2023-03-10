namespace AspNetCore.WebApi.Repositories;

    public class LivroRepository : ILivroRepository
{
    private readonly Context _context;
    public LivroRepository(Context Context)
    {
        _context = Context;
    }

    public async Task Save(Livro livro)
    {
        await _context.Livros.AddAsync(livro);
    }

    public void Update(Livro livro)
    {
        _context.Livros.Update(livro);
    }

    public void Delete(Livro livro)
    {
        _context.Livros.Remove(livro);
    }


    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<Livro>> Consult()
    {
        var livros = await _context.Livros.AsNoTracking().ToListAsync();

        return livros;

    }

    public Task<Livro> ConsultById(int id)
    {
        var livro = _context.Livros.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        return livro;
    }



}
