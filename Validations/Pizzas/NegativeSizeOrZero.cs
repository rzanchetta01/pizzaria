using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Pizzas
{
    public class NegativeSizeOrZero : ISpecification<Pizza>
    {
        public bool IsSatisfiedBy(Pizza entity)
        {
            return entity.QntFatias >= 6;
        }
    }
}
