using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Pizzas
{
    public class NomeNeverNullOrWhiteSpace : ISpecification<Pizza>
    {
        public bool IsSatisfiedBy(Pizza entity)
        {
            return !string.IsNullOrEmpty(entity.Nome);
        }
    }
}
