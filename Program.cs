using LibraryManangementSys.ApplicationDBContextFolder;
using LibraryManangementSys.MiddleWare;
using LibraryManangementSys.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));
builder.Services.AddScoped<IApplicationDBContext, ApplicationDBContext>();
builder.Services.AddScoped<IBooksRepository,BooksRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>(); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
