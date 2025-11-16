using FluentValidation;

namespace StudentMgmtCQRS.Application.Commands.UpdateStudent
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Department).NotEmpty();
            RuleFor(x => x.PhoneNumber).Matches(@"^\d{10}$");
            RuleFor(x => x.Age).GreaterThan(10);
            RuleFor(x => x.Marks).InclusiveBetween(0, 100);
        }
    }
}
