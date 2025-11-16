using MediatR;

namespace StudentMgmtCQRS.Application.Commands.DeleteStudent
{
    public record DeleteStudentCommand(int Id) : IRequest<bool>;
}
