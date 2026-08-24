using System;

namespace MyRecipeBook.Exception.ExceptionBase;

public class ErrorOnValidationException : MyRecipeBookException
{
    private readonly List<string> _errorMessages;

    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errorMessages = errorMessages;
    }
 
}
