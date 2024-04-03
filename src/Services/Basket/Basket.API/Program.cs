var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
var validationBehavior = typeof(ValidationBehavior<,>);
var loggingBehavior = typeof(LoggingBehavior<,>);

// RegisterServicesFromAssembly - not supported for carter
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(validationBehavior);
    config.AddOpenBehavior(loggingBehavior);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
