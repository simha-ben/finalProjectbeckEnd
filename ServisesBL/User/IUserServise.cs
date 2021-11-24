using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL
{
   public interface IUserServise
    {
        List<string> getAllUsersName();
        int createNewUser(UserVM uvm);

        int login(UserVM uvm);
        string getUserById(int id);
    }
}
