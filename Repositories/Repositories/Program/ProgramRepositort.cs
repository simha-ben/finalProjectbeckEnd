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
        IGlobalInterface global;
        public ProgramRepositort(easyPlan easy,IGlobalInterface global)
        {
            this.contaxt = easy;
            this.global = global;
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
        public string getDetailes(Program p)
        {
            return "כותרת :" + p.Title
                + "/n מאת: " + global.convert("User", p.Programer)
                + "/n תאור: " + p.Description
                + "/n מיועד לגילאי: " + global.convert("Age", p.Age)
            +"/n נושא: " + global.convert("Subject", p.Subject);
               
        }
    }
}
