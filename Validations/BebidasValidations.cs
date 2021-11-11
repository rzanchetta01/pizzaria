using DomainValidation.Validation;
using Pizzaria.Model;
using Pizzaria.Validations.Bebidas;

namespace Pizzaria.Validations
{
    public class BebidasValidations : Validator<Bebida>
    {
        public BebidasValidations()
        {
            Add("NomeNeverNullOrWhiteSpace", new Rule<Bebida>(new NomeNeverNullOrWhiteSpace(), "Campo nome está faltando"));
            Add("DescricaoNullOrWhiteSpace", new Rule<Bebida>(new DescricaoNullOrWhiteSpace(), "Campo descrição está faltando"));
            Add("NegativeSizeOrZero", new Rule<Bebida>(new NegativeSizeOrZero(), "É apenas permitidos tamanhos maiores que 0"));
            Add("NegativePriceOrZero", new Rule<Bebida>(new NegativePriceOrZero(), "É apenas permitido precos maiores que 0"));
        }
    }
}
