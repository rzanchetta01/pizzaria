using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Pessoas
{
    public class PrimeroNomeVazio : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return !string.IsNullOrEmpty(entity.PrimeiroNome);
        }
    }
}
