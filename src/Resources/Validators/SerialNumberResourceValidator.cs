namespace Linn.Products.Resources.Validators
{
    using FluentValidation;

    public class SerialNumberResourceValidator : AbstractValidator<SerialNumberResource>
    {
        public SerialNumberResourceValidator()
        {
            this.RuleFor(serialNumber => serialNumber.SernosGroup)
                .NotNull().WithMessage("Serial Number must have a Sernos Group")
                .NotEmpty().WithMessage("Serial Number's Sernos Group must not be an empty string");
            this.RuleFor(serialNumber => serialNumber.TransCode)
                .NotNull().WithMessage("Serial Number must have a Sernos Group")
                .NotEmpty().WithMessage("Serial Number's Sernos Group must not be an empty string");
            this.RuleFor(serialNumber => serialNumber.ArticleNumber)
                .NotNull().WithMessage("Serial Number must have an Article Number")
                .NotEmpty().WithMessage("Serial Number's Article Number must not be an empty string");
        }
    }
}
