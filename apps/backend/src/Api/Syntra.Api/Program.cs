using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Syntra.BuildingBlocks.Application;
using Syntra.BuildingBlocks.Infrastructure;
using Syntra.Modules.Authentication.Infrastructure;
using Syntra.Modules.Management.Application;
using Syntra.Modules.Management.Infrastructure;
using Syntra.Modules.Management.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApplication(
    typeof(ManagementAssemblyReference).Assembly);

builder.Services.AddInfrastructure();

builder.Services.AddManagementInfrastructure(builder.Configuration);
builder.Services.AddAuthenticationInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ManagementDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
