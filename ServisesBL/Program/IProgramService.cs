using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL
{
    public interface IProgramService
    {
        List<ProgramVM> GetAllPrograms();
        List<string> GetFields(string tableName);
        int AddNewProgram(ProgramVM newProgram);

    }
}
