
using Employee.Management.Persistence;
using Employee.Management.Application;
using Employee.Management.Infrastructure;
using EmployeeManagement.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
       // builder.AllowAnyOrigin()
        builder.WithOrigins("https://localhost:7146")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
//.AllowAnyHeader()
//.AllowAnyMethod());
//});


//builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors();

app.UseMiddleware<ExceptionMiddleware> ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
