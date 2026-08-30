using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Domain.Security.PasswordHashing
{
    public interface IPasswordHashing
    {
       public string HashPassword(string password);

       public bool VerifyPassword(string password, string hashedPassword);
    }
}
