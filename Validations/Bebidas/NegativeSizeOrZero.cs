using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Bebidas
{
    public class NegativeSizeOrZero : ISpecification<Bebida>
    {
        public bool IsSatisfiedBy(Bebida entity)
        {
            return entity.Tamanho > 0;
        }
    }
}
