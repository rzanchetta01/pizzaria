using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Bebidas
{
    public class NomeNeverNullOrWhiteSpace : ISpecification<Bebida>
    {
        public bool IsSatisfiedBy(Bebida entity)
        {
            return !string.IsNullOrEmpty(entity.Nome);
        }
    }
}
