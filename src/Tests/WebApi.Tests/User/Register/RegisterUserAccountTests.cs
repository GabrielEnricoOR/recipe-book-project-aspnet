using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using CommomTestUtilities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Shouldly;

namespace WebApi.Tests.User.Register;

public class RegisterUserAccountTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    
    public RegisterUserAccountTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        var response = await _client.PostAsJsonAsync("/api/user/register", request);
        
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        
        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseData = await JsonDocument.ParseAsync(responseStream);
        
        responseData.RootElement.GetProperty("name").GetString().ShouldBe(request.Name);
        responseData.RootElement.GetProperty("tokens").GetProperty("accessTokens").GetString().ShouldBeEmpty();
    }
}