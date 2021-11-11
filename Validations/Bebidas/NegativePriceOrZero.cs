using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Bebidas
{
    public class NegativePriceOrZero : ISpecification<Bebida>
    {
        public bool IsSatisfiedBy(Bebida entity)
        {
            return entity.Preco >= 0.0;
        }
    }
}
