using server.Services;
using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors( options =>
{
    options.AddPolicy( "AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins( "http://localhost:5173" )
              .AllowAnyMethod()
              .AllowAnyHeader();
    } );
} );

builder.Services.AddScoped<ICurrencyService, CurrencyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use( ( context, next ) =>
{
    Console.WriteLine( $"Request from: {context.Request.Headers[ "Origin" ]}" );
    return next();
} );

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors( "AllowAll" );

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

CurrencyHelper.AddCurrencyData(app);

app.Run();
