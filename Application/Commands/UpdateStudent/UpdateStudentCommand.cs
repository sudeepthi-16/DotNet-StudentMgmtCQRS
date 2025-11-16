using MediatR;

namespace StudentMgmtCQRS.Application.Commands.UpdateStudent
{
    public record UpdateStudentCommand(int Id, string Name, string Department, string PhoneNumber, int Age, int Marks) : IRequest<bool>;
}
