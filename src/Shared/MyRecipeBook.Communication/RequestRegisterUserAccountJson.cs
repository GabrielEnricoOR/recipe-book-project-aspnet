using System;

namespace MyRecipeBook.Communication;

public class RequestRegisterUserAccountJson
{   
    public string? Name {get; set;}
    public string? Email { get; set; }
    public string? Password { get; set; }
}
