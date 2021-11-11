using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Avaliacoes
{
    public class RatingInvalido : ISpecification<Avaliacao>
    {
        public bool IsSatisfiedBy(Avaliacao entity)
        {
            return entity.Rating >= 0 && entity.Rating <= 5;
        }
    }
}
