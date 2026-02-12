using MiddlewareDemo.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Our custom middleware ¨C runs early in the pipeline
// if Putting it before UseAuthorization means correlation IDs are available for auth, logging, etc
app.UseCorrelationId();

app.UseAuthorization();

app.MapControllers();

// if Putting it after MapControllers() would mean it never runs (because MapControllers terminates the pipeline for matching routes).
//app.UseCorrelationId();

app.Run();
