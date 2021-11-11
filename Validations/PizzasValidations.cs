using DomainValidation.Validation;
using Pizzaria.Model;
using Pizzaria.Validations.Pizzas;

namespace Pizzaria.Validations
{
    public class PizzasValidations : Validator<Pizza>
    {
        public PizzasValidations()
        {
            Add("NomeNeverNullOrWhiteSpace", new Rule<Pizza>(new NomeNeverNullOrWhiteSpace(), "Campo nome está faltando"));
            Add("DescricaoNullOrWhiteSpace", new Rule<Pizza>(new DescricaoNullOrWhiteSpace(), "Campo descrição está faltando"));
            Add("NegativeSizeOrZero", new Rule<Pizza>(new NegativeSizeOrZero(), "É apenas permitidos quantidades de fatias maiores que 6"));
            Add("NegativePriceOrZero", new Rule<Pizza>(new NegativePriceOrZero(), "É apenas permitido precos maiores que 0"));
        }
    }
}
