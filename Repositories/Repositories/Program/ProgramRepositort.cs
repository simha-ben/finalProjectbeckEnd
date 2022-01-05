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

        public List<Program> getAllPrograms()
        {
            return contaxt.Program.Where(p => p.Status == 1).ToList();
        }
       
    }
}
