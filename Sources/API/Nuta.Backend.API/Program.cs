using Nuta.Backend.Access.Domain.Enums;
using Nuta.Backend.Access.Infrastructure.DependencyInjection;
using Nuta.Backend.Access.Infrastructure.Persistence.Relational;
using Nuta.Backend.BuildingBlocks.Infrastructure.DependencyInjection;
using Nuta.Backend.Products.Infrastructure.DependencyInjection;
using Nuta.Backend.Products.Infrastructure.Persistence.Relational;
using Nuta.Backend.Users.Infrastructure.DependencyInjection;
using Nuta.Backend.Users.Infrastructure.Persistence.Relational;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddBuildingBlocks();
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddProductsModule(builder.Configuration);
builder.Services.AddAccessModule(builder.Configuration);

builder.Services.AddAuthorization(opt =>
{
    foreach (var p in Enum.GetValues<Permission>())
        opt.AddPolicy(p.ToString(), pb => pb.RequireClaim("permission", p.ToString()));
});

var app = builder.Build();

await UsersModuleDbMigrator.MigrateUp(app.Services);
await ProductsModuleDbMigrator.MigrateUp(app.Services);
await AccessModuleDbMigrator.MigrateUp(app.Services);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();