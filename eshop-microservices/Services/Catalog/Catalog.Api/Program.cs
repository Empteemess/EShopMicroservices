using Catalog.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddMediatR();
builder.Services.AddCarter();
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
    
}).UseLightweightSessions();


if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}

var app = builder.Build();
app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapCarter();

app.Run();