namespace Linn.Products.Resources.Validators
{
    using FluentValidation;

    public class SernosNoteCreateResourceValidator : AbstractValidator<SernosNoteCreateResource>
    {
        public SernosNoteCreateResourceValidator()
        {
            this.RuleFor(sernosNote => sernosNote.SernosNotes)
                .NotNull().WithMessage("Sernos Note must not be empty")
                .NotEmpty().WithMessage("Sernos Note must not be empty")
                .MaximumLength(2000).WithMessage("Sernos Note must be no longer that 2000 characters");
            this.RuleFor(sernosNote => sernosNote.SernosGroup)
                .MaximumLength(10).WithMessage("Sernos Group must be no longer that 10 characters");
            this.RuleFor(sernosNote => sernosNote.TransCode)
                .MaximumLength(10).WithMessage("Trans Code must be no longer that 10 characters");
        }
    }
}
