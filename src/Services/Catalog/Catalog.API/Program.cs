var builder = WebApplication.CreateBuilder(args);


// RegisterServicesFromAssembly - not supported for carter
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();

app.MapCarter();

app.Run();
