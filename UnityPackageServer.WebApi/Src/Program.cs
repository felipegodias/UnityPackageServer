using UnityPackageServer.Services;
using UnityPackageServer.Services.Aws;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddUpsServices();
builder.Services.AddUpsAwsServices();

WebApplication app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();