using ProjetoFluenteValidation.API;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

builder.Services.ConfigureDbContext(connectionString);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureMediator();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
