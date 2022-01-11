using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
   public interface IProgramRepositort
    {
        List<Program> GetAllPrograms();
        int AddNewProgram(Program newProgram);
       
    }
}
