using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCore.WebApi.Models;

namespace AspNetCore.WebApi.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {}


        public DbSet<Livro> Livros { get; set; }
    }
}