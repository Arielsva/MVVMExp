using FluentValidation;
using WebCommerce.Business.Models.Validations.Documents;

namespace WebCommerce.Business.Models.Validations
{
    public class ProviderValidation : AbstractValidator<Provider>
    {
        public ProviderValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(2, 100);

            When(p => p.ProviderType == PersonType.Individual, () => 
            {
                RuleFor(p => p.Document.Length).Equal(IndividualDocumentValidation.CpfSize);
                RuleFor(p => IndividualDocumentValidation.Validate(p.Document)).Equal(true);
            });

            When(p => p.ProviderType == PersonType.Company, () => 
            {
                RuleFor(p => p.Document.Length).Equal(CompanyDocumentValidation.CnpjSize);
                RuleFor(p => CompanyDocumentValidation.Validate(p.Document)).Equal(true);
            });

            RuleFor(p => p.ProviderType)
                .IsInEnum();
        }
    }
}
