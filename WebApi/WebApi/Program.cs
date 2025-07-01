using Domain.Interfaces;
using WebApi.Mapping;
using Infrastructure.Repositories;
using Infrastructure.Service;

var builder = WebApplication.CreateBuilder( args );
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper( typeof( MappingProfile ) );

builder.Services.AddSingleton<IPropertyRepository, PropertyRepository>();
builder.Services.AddSingleton<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddSingleton<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
