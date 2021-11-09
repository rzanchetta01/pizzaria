using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.Model
{
    public class Avaliacao
    {
        public int Id { get; set; }

        [ForeignKey ("Pizza")]
        public int IdPizza { get; set; }
        public int Rating { get; set; }
        public string? Comentario { get; set; }
    }
}
