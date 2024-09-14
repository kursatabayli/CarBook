using CarBook.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddSwaggerDocumentation();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwaggerDocumentation(app.Environment);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
