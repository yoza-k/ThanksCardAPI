using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// JSONシリアル化で循環参照を無視
builder.Services.AddControllers().AddJsonOptions(option =>
                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<ApplicationContext>(opt =>
     opt.UseNpgsql("Host=localhost; Database=webapp1; Username=postgres; Password=postgres"));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//<---この行を追加

builder.Services.AddControllers();

// API を一覧表示する Swagger の設定
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