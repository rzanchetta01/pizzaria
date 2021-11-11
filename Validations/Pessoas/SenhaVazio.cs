using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Pessoas
{
    public class SenhaVazio : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return !string.IsNullOrEmpty(entity.Senha);
        }
    }
}
