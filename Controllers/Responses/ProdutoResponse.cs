using System.Collections.Generic;
using System.Linq;
using Ravex.WebApi.Entities;

namespace Ravex.WebApi.Controllers.Responses
{
    public class ProdutoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public static ProdutoResponse Mapper(Produto xPersistido)
        {
            return new ProdutoResponse
            {
                Id = xPersistido.Id,
                Nome = xPersistido.Nome,
                Descricao = xPersistido.Descricao,
                Valor = xPersistido.Valor
            };
        }

        /// <summary>
        /// O select abaixo é igual a:
        /// </summary>
        /// <code>
        /// var xRetorno = new List<ProdutoResponse>();
        /// foreach (var pProduto in pProdutos)
        /// {
        ///     xRetorno.Add(ProdutoResponse.Mapper(pProduto));
        /// }
        /// return xRetorno;
        /// </code>
        /// <param name="pProdutos"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoResponse> Mapper(IEnumerable<Produto> pProdutos)
        {
            return pProdutos.Select(Mapper);
        }
    }
}