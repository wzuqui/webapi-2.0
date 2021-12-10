namespace Ravex.WebApi.Entities
{
    public class Produto
    {
        public int Id { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}