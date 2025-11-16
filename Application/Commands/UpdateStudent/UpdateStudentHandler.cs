using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentMgmtCQRS.Data;

namespace StudentMgmtCQRS.Application.Commands.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateStudentHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if (student == null)
                return false;

            student.UpdateDetails(request.Name, request.Department, request.PhoneNumber, request.Age, request.Marks);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
