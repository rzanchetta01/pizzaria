namespace Pizzaria.Model
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public double Preco { get; set; }         
        public List<Avaliacao> Avaliacoes { get; set; }
    }
}
