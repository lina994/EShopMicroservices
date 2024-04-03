var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
var validationBehavior = typeof(ValidationBehavior<,>);
var loggingBehavior = typeof(LoggingBehavior<,>);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(validationBehavior);
    config.AddOpenBehavior(loggingBehavior);
});

builder.Services.AddValidatorsFromAssembly(assembly);

// RegisterServicesFromAssembly - not supported for carter
builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
