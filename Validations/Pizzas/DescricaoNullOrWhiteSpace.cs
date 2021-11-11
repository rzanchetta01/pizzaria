using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Pizzas
{
    public class DescricaoNullOrWhiteSpace : ISpecification<Pizza>
    {
        public bool IsSatisfiedBy(Pizza entity)
        {
            return !string.IsNullOrEmpty(entity.Descricao);
        }
    }
}
