using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCore.WebApi.Controllers.Shared;
using AspNetCore.WebApi.Data;
using AspNetCore.WebApi.Models;
using static AspNetCore.WebApi.Attributes.CustomResponse;
using AspNetCore.WebApi.Repositories;

namespace AspNetCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LivrosController : ApiController
    {

     
        ///<summary>Obtém todos os livros</summary>
        ///<returns>Retorna os livros encontrados</returns>
        ///<response code="200">Retorna os livros encontrados</response>
        [HttpGet("livros")]
        public async Task<ActionResult<List<Livro>>> ObterTodosTipado([FromServices] ILivroRepository livroRepository)
        {
          var livros = await livroRepository.Consult();
          return Ok(livros);
        }


        /// <summary>
        /// Obtém um livro pelo seu identificador.
        /// </summary>
        /// <param name="id">id do livro</param>
        /// <returns>Retorna o livro encontrado</returns>
        /// <response code="200">Retorna o livro encontrado</response>
        /// <response code="400">Se o id passado for nulo</response>
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]

        [HttpGet("livros/{id}")]
        public async Task<IActionResult> ObterPorId([FromServices] ILivroRepository livroRepository, int id)
        {
            if (id <= 0)
                return ResponseBadRequest();

            var livro = await livroRepository.ConsultById(id);

            return ResponseOk(livro);
        }


        /// <summary>
        /// Cria um livro.
        /// </summary>
        /// <param name="livro">Dados do livro</param>
        /// <returns>Um novo livro criado</returns>
        /// <response code="201">Retorna com o ID criado</response>
        /// <response code="400">Se o livro passado for nulo</response>
        /// <response code="500">Se houver um erro ao criar um livro</response>
        [CustomResponse(StatusCodes.Status201Created)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        [HttpPost("livros")]
        public async Task<IActionResult> Criar([FromServices] ILivroRepository livroRepository, [FromBody] Livro model)
        {

            if (!ModelState.IsValid)
            return ResponseBadRequest();

            var livro = new Livro(model.Id, model.Titulo, model.Categoria, model.Quantidade, model.Preco, model.Autor, model.Ativo);          
            await livroRepository.Save(model);
            await livroRepository.Commit();

            return ResponseCreated(model);
        }

        /// <summary>
        /// Atualiza um livro.
        /// </summary>
        /// <param name="id">id do livro</param> 
        /// <response code="200">Retorna com o status da atualização</response>
        /// <response code="400">Se o livro passado for nulo</response>
        /// <response code="500">Se houver um erro ao atualizar um livro</response>
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        [HttpPut("livros/{id}")]
        public async Task<IActionResult> Atualizar(
            [FromServices] ILivroRepository livroRepository,
            [FromBody] Livro model,
            int id)
        {

            if (!ModelState.IsValid)
                return ResponseBadRequest();

            var livro = await livroRepository.ConsultById(id);

            if(livro == null)
            return ResponseNotFound();

            livro = new Livro(id, model.Titulo, model.Categoria, model.Quantidade, model.Preco, model.Autor, model.Ativo);
            livroRepository.Update(livro);
            livroRepository.Commit();

            return ResponseOk(livro);
        }

        /// <summary>
        /// Exclui um livro.
        /// </summary>
        /// <param name="id">id do livro</param>
        /// <response code="200">Retorna com o status da exclusão</response>
        /// <response code="400">Se o livro passado for nulo</response>
        /// <response code="500">Se houver um erro ao excluir um livro</response>
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status500InternalServerError)]
        [HttpDelete("livros/{id}")]
        public async Task<IActionResult> Deletar(
            [FromServices] ILivroRepository livroRepository,
            int id)
        {


            if (id == 0)
            return ResponseBadRequest();

            var livro = await livroRepository.ConsultById(id);
            livroRepository.Delete(livro);
            livroRepository.Commit();

            return ResponseOk(livro);
        }


    }
}