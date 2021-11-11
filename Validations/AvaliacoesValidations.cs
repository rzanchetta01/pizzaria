using DomainValidation.Validation;
using Pizzaria.Data;
using Pizzaria.Model;
using Pizzaria.Validations.Avaliacoes;

namespace Pizzaria.Validations
{
    public class AvaliacoesValidations : Validator<Avaliacao>
    {
        private readonly AppDbContext dbContext;
        public AvaliacoesValidations(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            Add("IdPizzaInvalido", new Rule<Avaliacao>(new IdPizzaInvalido(dbContext), "É nescessario que seja um id de uma pizza existente"));
            Add("RatingInvalido", new Rule<Avaliacao>(new RatingInvalido(), "Rating vai de 0 até 5"));
            Add("ComentarioInvalido", new Rule<Avaliacao>(new ComentarioInvalido(), "Tamanho maximo de letras é 400"));
        }
    }
}
