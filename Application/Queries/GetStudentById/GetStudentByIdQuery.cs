using MediatR;
using StudentMgmtCQRS.Models;

namespace StudentMgmtCQRS.Application.Queries.GetStudentById
{
    public record GetStudentByIdQuery(int Id) : IRequest<Student?>;
}
