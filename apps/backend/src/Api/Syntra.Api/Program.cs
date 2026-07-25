using Scalar.AspNetCore;
using Syntra.BuildingBlocks.Application;
using Syntra.BuildingBlocks.Infrastructure;
using Syntra.Modules.Management.Application;
using Syntra.Modules.Management.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApplication(
    typeof(ManagementAssemblyReference).Assembly);

builder.Services.AddInfrastructure();
builder.Services.AddManagementInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
