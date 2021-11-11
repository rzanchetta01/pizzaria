using DomainValidation.Interfaces.Specification;
using Pizzaria.Data;
using Pizzaria.Model;

namespace Pizzaria.Validations.Avaliacoes
{
    public class IdPizzaInvalido : ISpecification<Avaliacao>
    {
        private readonly AppDbContext dbContext = new();

        public IdPizzaInvalido(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsSatisfiedBy(Avaliacao entity)
        {
            var x = from i in dbContext.Pizzas where i.Id == entity.IdPizza select i;
            
            return x != null;
        }
    }
}
