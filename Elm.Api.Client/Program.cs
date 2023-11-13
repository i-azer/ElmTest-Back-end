using Elm.Application;
using Elm.Application.Contracts.Services;
using Elm.Cache.InMemory;
using Elm.Dapper.Orm;

var builder = WebApplication.CreateBuilder(args);


#region Infrastructure
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDapperInfrastructure();
builder.Services.AddInMemoryCacheInfrastructure();
#endregion
#region Application
builder.Services.AddElmApplicationServices();
#endregion
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});
var app = builder.Build();

app.UseCors("CORSPolicy");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/fetch", async (ISearchApplicationService _applicationService, int offset, int limit, string SearchSlug) =>
{
    var searchingResult = await _applicationService.SearchBooks(offset, limit, SearchSlug)
    .ConfigureAwait(false);
    if (searchingResult == null || !searchingResult.Any())
    { 
        return Results.NotFound(); 
    }
    else
    {
        return Results.Ok(searchingResult);
    }
})
.WithName("fetch");

app.Run();