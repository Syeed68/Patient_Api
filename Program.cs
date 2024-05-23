using Microsoft.EntityFrameworkCore;
using PatientManagementSystem.Model;
using PatientManagementSystem.Model.IRepositories;
using PatientManagementSystem.Model.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddControllers();
builder.Services.AddTransient<IDropdownRepository, DropdownRepository>();
builder.Services.AddTransient<IPatientInformationRepository, PatientInformationRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myPolicy",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:29895");
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          builder.AllowCredentials();
                      });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();


app.UseCors("myPolicy");

app.Run();
