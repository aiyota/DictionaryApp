using DictionaryApp.Infrastructure.IoC;
using DictionaryApp.Presentation.Api;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddInfrastructure()
    .AddApplication()
    .AddPresentation();

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
