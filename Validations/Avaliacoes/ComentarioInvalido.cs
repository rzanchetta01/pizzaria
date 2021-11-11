using DomainValidation.Interfaces.Specification;
using Pizzaria.Model;

namespace Pizzaria.Validations.Avaliacoes
{
    public class ComentarioInvalido : ISpecification<Avaliacao>
    {
        public bool IsSatisfiedBy(Avaliacao entity)
        {
            return entity.Comentario.Length <= 400;
        }
    }
}
