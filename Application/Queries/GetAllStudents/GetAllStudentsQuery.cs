using MediatR;
using StudentMgmtCQRS.Models;

namespace StudentMgmtCQRS.Application.Queries.GetAllStudents
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<Student>>;
}
