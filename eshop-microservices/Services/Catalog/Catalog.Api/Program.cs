var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddMediatR();
builder.Services.AddCarter();
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
    
}).UseLightweightSessions();

var app = builder.Build();


app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapCarter();

app.Run();