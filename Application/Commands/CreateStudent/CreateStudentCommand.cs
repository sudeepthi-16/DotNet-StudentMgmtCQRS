using MediatR;

namespace StudentMgmtCQRS.Application.Commands.CreateStudent
{
    public record CreateStudentCommand(string Name, string Department, string PhoneNumber, int Age, int Marks) : IRequest<int>;
}
