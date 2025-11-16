using MediatR;
using StudentMgmtCQRS.Data;
using StudentMgmtCQRS.Models;

namespace StudentMgmtCQRS.Application.Commands.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Name, request.Department, request.PhoneNumber, request.Age, request.Marks);
            _context.Students.Add(student);
            await _context.SaveChangesAsync(cancellationToken);
            return student.Id;
        }
    }
}
