using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public interface IAdminRepository
    {
        int createNewAdmin(Admin newAdmin);
        int login(Admin newAdmin);
        int newProgram(Program newProgram);

    }
}




   