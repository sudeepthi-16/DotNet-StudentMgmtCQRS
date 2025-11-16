using FluentValidation;

namespace StudentMgmtCQRS.Application.Commands.CreateStudent
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Department).NotEmpty();
            RuleFor(x => x.PhoneNumber).Matches(@"^\d{10}$");
            RuleFor(x => x.Age).GreaterThan(10);
            RuleFor(x => x.Marks).InclusiveBetween(0, 100);
        }
    }
}
