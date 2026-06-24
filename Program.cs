using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi;
using System.Text.Json.Serialization;
using WebApi_PostGreSQLDemo.Database;
using WebApi_PostGreSQLDemo.Extensions;
using Microsoft.OpenApi;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddCookie(IdentityConstants.ApplicationScheme).
    AddBearerToken(IdentityConstants.BearerScheme);
    //.AddCookie(IdentityConstants.ApplicationScheme);


builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Post_Connect")));

builder.Services.Configure<RouteOptions>(options =>
    options.SetParameterPolicy<RegexInlineRouteConstraint>("regex"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(d =>
{
    d.AddSecurityDefinition("beaererAuth", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Jwt Authorization header using bearer scheme"

    });

    
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigration();


}


app.MapIdentityApi<User>();

app.MapGet("users/me", async (ClaimsPrincipal claims, AppDbContext dbContext) =>
{
    string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

    return await dbContext.Users.FindAsync(userId);
}).RequireAuthorization();



var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);


app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
