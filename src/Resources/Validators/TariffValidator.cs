namespace Linn.Products.Resources.Validators
{
    using FluentValidation;

    public class TariffValidator : AbstractValidator<TariffResource>
    {
        public TariffValidator()
        {
            this.RuleFor(tariff => tariff.TariffCode).NotNull().WithMessage("The tariff code must be specified")
                .MaximumLength(14).WithMessage("The tariff code must not be longer than 14 characters");
            this.RuleFor(tariff => tariff.Description).NotNull().WithMessage("The description must not be empty").MaximumLength(2000).WithMessage("The length of the description must not exceed two thousand characters");
            this.RuleFor(tariff => tariff.USTariffCode).MaximumLength(14)
                .WithMessage("The US tariff code must not exceed 14 characters");
        }
    }
}
