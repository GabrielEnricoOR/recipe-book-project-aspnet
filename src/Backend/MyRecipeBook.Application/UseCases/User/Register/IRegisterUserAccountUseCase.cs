using MyRecipeBook.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public interface IRegisterUserAccountUseCase
    {
        Task Execute(RequestRegisterUserAccountJson request);
    }
}
