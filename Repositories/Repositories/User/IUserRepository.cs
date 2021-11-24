
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public  interface IUserRepository
    {
        List<string> getAllUsersName();
        int createNewUser(Users newUser);
        List<Users> getAllUsers();

        string getUserById(int id);
    }
}
