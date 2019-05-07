namespace Linn.Products.Resources.Validators
{
    using FluentValidation;

    public class SerialNumberCreateResourceValidator : AbstractValidator<SerialNumberCreateResource>
    {
        public SerialNumberCreateResourceValidator()
        {
            this.RuleFor(serialNumber => serialNumber.TransCode).NotEmpty()
                .WithMessage("Serial Number must have a Sernos Group");
            this.RuleFor(serialNumber => serialNumber.ArticleNumber).NotEmpty()
                .WithMessage("Serial Number must have an Article Number");
        }
    }
}
