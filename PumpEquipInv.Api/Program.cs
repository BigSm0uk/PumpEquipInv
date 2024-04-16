using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using PumpEquipInv.Core.Interfaces;
using PumpEquipInv.DataAccess;
using PumpEquipInv.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddControllers().AddMvcOptions(x =>
    x.SuppressAsyncSuffixInActionNames = false).AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    }
);
builder.Services.AddDbContext<PumpDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDB"));
});

builder.Services.AddScoped<IMotorRepository, MotorRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IPumpRepository, PumpRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.WithOrigins("http://myapp.local:443", "http://localhost:4200") // путь к нашему SPA клиенту
    .AllowCredentials()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.Run();