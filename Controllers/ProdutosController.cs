using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ravex.WebApi.Controllers.Requests;
using Ravex.WebApi.Controllers.Responses;
using Ravex.WebApi.Entities;

namespace Ravex.WebApi.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutosController : ControllerBase
    {
        private static readonly List<Produto> _produtos = new();

        // CREATE
        [HttpPost] // POST produtos/
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProdutoResponse> Post([FromBody] ProdutoAdicionarRequest pRequest)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var xProduto = ProdutoAdicionarRequest.Mapper(pRequest, _produtos.Count + 1);
            _produtos.Add(xProduto);

            return CreatedAtAction(nameof(Get)
                , new { pId = xProduto.Id } // RouterParam
                , ProdutoResponse.Mapper(xProduto));
        }

        // READ
        [HttpGet("{pId:int}")] // GET produtos/123 = produtos/{pId}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProdutoResponse> Get(int pId)
        {
            var xPersistido = _produtos.FirstOrDefault(p => p.Id == pId);
            return xPersistido is null
                ? NotFound()
                : Ok(ProdutoResponse.Mapper(xPersistido));
        }

        // READ
        [HttpGet] // GET produtos/
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProdutoResponse>> Get()
        {
            return Ok(ProdutoResponse.Mapper(_produtos));
        }

        // UPDATE
        [HttpPut("{pId:int}")] // PUT /produtos/123 = produtos/{pId}
        [ProducesResponseType(StatusCodes.Status204NoContent)] // ✔
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // ✔
        [ProducesResponseType(StatusCodes.Status404NotFound)] // ✔
        public IActionResult Put(int pId, [FromBody] ProdutoAtualizarRequest pRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var xPersistido = _produtos.FirstOrDefault(p => p.Id == pId);
            if (xPersistido == null)
                return NotFound();

            xPersistido.Descricao = pRequest.Descricao;
            xPersistido.Valor = pRequest.Valor;
            return NoContent();
        }

        // DELETE
        // GET produtos/123 = produtos/{pId}
        // STATUS 204, 404
        [HttpDelete("{pId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int pId)
        {
            var xPersistido = _produtos.FirstOrDefault(p => p.Id == pId);
            if (xPersistido is null)
                return NotFound();

            _produtos.Remove(xPersistido);
            return NoContent();
        }
    }
}
