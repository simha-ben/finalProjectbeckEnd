using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
    public class ProgramRepositort : IProgramRepositort
    {
        easyPlan contaxt;
        public ProgramRepositort(easyPlan easy)
        {
            this.contaxt = easy;
        }

        public int AddNewProgram(Program newProgram)
        {
            var addedUser = contaxt.Program.Add(newProgram);
            int succed = contaxt.SaveChanges();
            if (succed > 0)
                return addedUser.Entity.Id;
            return -1;
        }

        public List<Program> GetAllPrograms()
        {
            return contaxt.Program.Where(p => p.Status == 1).ToList();
        }

    }
}
