using Asp.Versioning;
using Nuta.Backend.Access.Domain.Enums;
using Nuta.Backend.Access.Infrastructure.DependencyInjection;
using Nuta.Backend.Access.Infrastructure.Postgres;
using Nuta.Backend.API.Filters;
using Nuta.Backend.BuildingBlocks.Infrastructure.DependencyInjection;
using Nuta.Backend.Products.Infrastructure.DependencyInjection;
using Nuta.Backend.Products.Infrastructure.Postgres;
using Nuta.Backend.Users.Infrastructure.DependencyInjection;
using Nuta.Backend.Users.Infrastructure.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});

builder.Services.AddOpenApi("UsersModuleV1");
builder.Services.AddOpenApi("ProductsModuleV1");
builder.Services.AddOpenApi("AccessModuleV1");

builder.Services.AddBuildingBlocks();
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddProductsModule(builder.Configuration);
builder.Services.AddAccessModule(builder.Configuration, builder.Environment);

builder.Services
    .AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddAuthorization(options =>
{
    foreach (var p in Enum.GetValues<Permission>())
        options.AddPolicy(p.ToString(), pb => pb.RequireClaim("permission", p.ToString()));
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

await UsersModuleDbMigrator.MigrateUp(app.Services);
await ProductsModuleDbMigrator.MigrateUp(app.Services);
await AccessModuleDbMigrator.MigrateUp(app.Services);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(swaggerUiOptions =>
    {
        swaggerUiOptions.SwaggerEndpoint("/openapi/UsersModuleV1.json", "Users Module V1");
        swaggerUiOptions.SwaggerEndpoint("/openapi/ProductsModuleV1.json", "Products Module V1");
        swaggerUiOptions.SwaggerEndpoint("/openapi/AccessModuleV1.json", "Access Module V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();