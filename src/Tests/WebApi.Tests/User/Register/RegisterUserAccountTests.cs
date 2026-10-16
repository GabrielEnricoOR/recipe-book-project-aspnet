using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using CommomTestUtilities;
using Microsoft.AspNetCore.Mvc.Testing;
using MyRecipeBook.Exception;
using Shouldly;

namespace WebApi.Tests.User.Register;

public class RegisterUserAccountTests : IClassFixture<WebApplicationFactory<Program>>
{
    private const string REQUEST_URI = "api/user/register";
    private readonly HttpClient _client;
    
    public RegisterUserAccountTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        var response = await _client.PostAsJsonAsync(REQUEST_URI, request);
        
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        
        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseData = await JsonDocument.ParseAsync(responseStream);
        
        responseData.RootElement.GetProperty("name").GetString().ShouldBe(request.Name);
        responseData.RootElement.GetProperty("tokens").GetProperty("accessToken").GetString().ShouldBeEmpty();
    }

    [Fact]
    public async Task Validate_ShouldHaveAnError_WhenNameIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;
        var response = await _client.PostAsJsonAsync(REQUEST_URI, request);
            
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        
        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseData = await JsonDocument.ParseAsync(responseStream);

        var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

        errors.ShouldSatisfyAllConditions(errorList =>
        {
            errorList.Count().ShouldBe(1);
            errorList.ShouldContain(error => error.GetString().Equals(ResourceMessagesException.VALIDATION_NAME_REQUIRED));
        });
    }
}