using FluentValidation;

namespace WebCommerce.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(a => a.Street)
                .NotEmpty()
                .Length(2, 200);

            RuleFor(a => a.Number)
                .NotEmpty()
                .Length(1, 50);

            RuleFor(a => a.Complement)
                .NotEmpty()
                .Length(2, 200);

            RuleFor(a => a.PostalCode)
                .NotEmpty()
                .Length(8);

            RuleFor(a => a.Neighborhood)
                .NotEmpty()
                .Length(2, 200);

            RuleFor(a => a.City)
                .NotEmpty()
                .Length(2, 100);

            RuleFor(a => a.State)
                .NotEmpty()
                .Length(2, 50);
        }
    }
}
