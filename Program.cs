using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// JSONƒVƒŠƒAƒ‹‰»‚ÅzŠÂŽQÆ‚ð–³Ž‹
builder.Services.AddControllers().AddJsonOptions(option =>
                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<ApplicationContext>(opt =>
     opt.UseNpgsql("Host=localhost; Database=thankscard; Username=postgres; Password=postgres"));
// DateTime Œ^ ‚ð UTC ‚Å ƒf[ƒ^‚ð PostgreSQL ‚É“o˜^
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();

// API ‚ðˆê——•\Ž¦‚·‚é Swagger ‚ÌÝ’è
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "ThanksCardAPI", Version = "v1" });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();