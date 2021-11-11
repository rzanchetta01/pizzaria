using DomainValidation.Validation;
using Pizzaria.Model;
using Pizzaria.Validations.Pessoas;

namespace Pizzaria.Validations
{
    public class ClientesValidations : Validator<Cliente>
    { 
        public ClientesValidations()
        {
            Add("PrimeroNomeVazio", new Rule<Cliente>(new PrimeroNomeVazio(), "Campo nome vazio"));
            Add("SegundoNomeVazio", new Rule<Cliente>(new SegundoNomeVazio(), "Campo sobrenome vazio"));
            Add("EmailVazio", new Rule<Cliente>(new EmailVazio(), "Campo email vazio"));
            Add("SenhaVazio", new Rule<Cliente>(new SenhaVazio(), "Campo senha está em branco"));
        }
    }
}
