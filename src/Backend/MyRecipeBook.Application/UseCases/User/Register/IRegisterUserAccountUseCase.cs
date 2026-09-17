using MyRecipeBook.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public interface IRegisterUserAccountUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserAccountJson request);
    }
}
