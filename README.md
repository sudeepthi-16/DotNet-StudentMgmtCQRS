# DotNet-StudentMgmtCQRS
A basic Student Management System API built with
ASP.NET Core 8, Entity Framework Core (InMemory DB), CQRS Pattern, MediatR, and FluentValidation —
including centralized validation and logging middleware.

🧩 How It Works

Controllers accept HTTP requests.

Controllers call MediatR → sends a Command (for writes) or Query (for reads).

The ValidationBehavior runs automatically for every request.

The corresponding Handler executes business logic using AppDbContext.

LoggingMiddleware logs each request, status, duration, and exceptions.



💻 Sample Outputs:

 **DELETE – Remove Student**

Swagger’s DELETE /api/Students/1 request removed the student with ID 1.

<img width="1836" height="740" alt="Screenshot 2025-11-16 175247" src="https://github.com/user-attachments/assets/eee754e9-9af4-43a2-b35c-81768c819679" />

The response returned:
Status 204 (No Content)
Student deleted successfully from the in-memory list.

**PUT – Update Student**
Swagger’s PUT /api/Students/1 updated the student details (name changed to Sudeepthi, phone updated improperly).
Response:


Swagger’s PUT /api/Students/1 updated the student details (name changed to Sudeepthi, phone updated properly).
Response:

<img width="1848" height="1003" alt="image" src="https://github.com/user-attachments/assets/7ba09bc6-6674-4f38-8b19-015b83d86395" />

Student record modified successfully.

** GET – Fetch Student by ID**
Swagger’s GET /api/Students/2 fetched details of another student:

<img width="1857" height="1008" alt="Screenshot 2025-11-16 174537" src="https://github.com/user-attachments/assets/e574fd5b-1019-46bd-bef9-cf404edbdc07" />
Successfully retrieved record from the in-memory data store.



**Middleware Logging of each request**
<img width="1847" height="1114" alt="image" src="https://github.com/user-attachments/assets/bd00306e-64fc-408f-a88c-e4dd8cd9feee" />

