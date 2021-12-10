using System.ComponentModel.DataAnnotations;

namespace Ravex.WebApi.Controllers.Requests
{
    public class ProdutoAtualizarRequest
    {
        [StringLength(2000)]
        public string Descricao { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Valor { get; set; }
    }
}