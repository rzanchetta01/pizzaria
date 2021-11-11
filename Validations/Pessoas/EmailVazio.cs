using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Pessoas
{
    public class EmailVazio : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return !string.IsNullOrEmpty(entity.Email);
        }
    }
}
