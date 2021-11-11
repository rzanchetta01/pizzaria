using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Pizzas
{
    public class NegativePriceOrZero : ISpecification<Pizza>
    {
        public bool IsSatisfiedBy(Pizza entity)
        {
            return entity.Preco >= 0.0;
        }
    }
}
