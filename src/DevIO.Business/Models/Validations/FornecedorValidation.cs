using DevIO.Business.Models.Validations.Docs;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preechido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(x => x.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
              {
                  RuleFor(x => x.Documento.Length).Equal(CpfValidation.TamanhoCpf)
                  .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                  RuleFor(x => CpfValidation.Validar(x.Documento)).Equal(true)
                  .WithMessage("O documento fornecido é inválido.");
              });

            When(x => x.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(x => x.Documento.Length).Equal(CnpjValidation.TamanhoCnpj)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(x => CnpjValidation.Validar(x.Documento)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}
