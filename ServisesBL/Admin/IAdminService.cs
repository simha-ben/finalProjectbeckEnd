using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL
{
  public  interface IAdminService
    {
        int createNewAdmin(AdminVM newAdmin);
        int login(AdminVM newAdmin);
        int newProgram(ProgramVM newProgram);

    }
}
