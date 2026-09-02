using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MyRecipeBook.Api.Filters;
using MyRecipeBook.Application;
using MyRecipeBook.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

DependecyInjectionInfrastructure.AddInfrastructureServices(builder.Services);
DependencyInjectionExtension.AddApplicationServices(builder.Services);


builder.Services.AddMvc(Options => Options.Filters.Add<ExceptionFilter>());


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] {"en-US", "pt-BR", "es"};
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.DefaultRequestCulture = new RequestCulture("en-US"); 
    options.RequestCultureProviders = new List<IRequestCultureProvider>
   {
       new AcceptLanguageHeaderRequestCultureProvider()
   };
});

var app = builder.Build();

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
