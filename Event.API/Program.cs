using Event.API;
using Event.API.DbContexts;
using Event.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<EventsDataStore>();

builder.Services.AddDbContext<EventContext>(DbContextOptions => DbContextOptions.UseSqlServer(
    builder.Configuration["ConnectionStrings:EventDBConnectionString"]));

builder.Services.AddScoped<IEventRepository, EventRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
