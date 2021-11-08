namespace Pizzaria.Model
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int IdPizza { get; set; }
        public int Rating { get; set; }
        public string Comentario { get; set; }
        public virtual Pizza idPizzaRelation { get; set; }
    }
}
