using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentMgmtCQRS;
using StudentMgmtCQRS.Behaviors;
using StudentMgmtCQRS.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inhouse DB
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("StudentDb"));


builder.Services.AddMediatR(typeof(Program).Assembly);

// Register all validators auto
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Register Validation  
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// middleware

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//custom Logging Middleware
app.UseRequestLogging();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
