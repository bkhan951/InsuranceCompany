using InsuranceCompany.Clients;
using InsuranceCompany.Helpers;
using InsuranceCompany.Interfaces;
using InsuranceCompany.Repositories.IRepository;
using InsuranceCompany.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICompanyTask, CompanyTask>();
builder.Services.AddTransient<IClaimsTask, ClaimsTask>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IClaimsRepository, ClaimsRepository>();
builder.Services.AddSingleton<DataHelpers>();


var app = builder.Build();

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
