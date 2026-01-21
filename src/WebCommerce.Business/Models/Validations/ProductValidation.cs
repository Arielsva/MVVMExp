using FluentValidation;

namespace WebCommerce.Business.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation() 
        { 
            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(2, 200);

            RuleFor(p => p.Description)
                .NotEmpty()
                .Length(2, 1000);

            RuleFor(p => p.Value)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.RegistrationDate)
                .NotEmpty();
        }
    }
}
