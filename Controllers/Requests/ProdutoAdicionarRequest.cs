using System.ComponentModel.DataAnnotations;
using Ravex.WebApi.Entities;

namespace Ravex.WebApi.Controllers.Requests
{
    public class ProdutoAdicionarRequest
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(2000)]
        public string Descricao { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Valor { get; set; }

        public static Produto Mapper(ProdutoAdicionarRequest pRequest, int pId)
        {
            var xRetorno = new Produto
            {
                Id = pId,
                Nome = pRequest.Nome,
                Descricao = pRequest.Descricao,
                Valor = pRequest.Valor
            };
            return xRetorno;
        }
    }
}