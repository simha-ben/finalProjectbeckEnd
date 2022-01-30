using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Models;

namespace Repositories.Repositories
{
   public class AdminRepository : IAdminRepository
    {
        easyPlan context;
        public AdminRepository(easyPlan c)
        {
            this.context = c;
        }

        public string changeProgramStatus(int? programId, int? status)
        {
            try
            { 
            context.Program.Where(p => p.Id == programId).FirstOrDefault().Status = status;
           int res= context.SaveChanges();
            if (res>=0)
            {
                return "תוכנית " + programId + " נוספה לתוכניות הפעילות";
            }
            return "ארעה שגיאה במהלך שמירת הנתונים";
            }
            catch(Exception err)
            {
                return err.Message;
            }
        }

        public int createNewAdmin(Admin newAdmin)
        {
            int id = 120;
            if (context.Admin == null)
            {
               var newA=  context.Admin.Add(newAdmin);
                context.SaveChanges();
                id = newA.Entity.Id;
            }
            foreach (Admin item in context.Admin)
            {
                if (newAdmin.Name.Equals(item.Name))
                {
                    if (item.Email.Equals(newAdmin.Email.Trim()))
                    {
                        id = -1;
                        break;
                    }
                }
            }
            if (id != -1)
            {
               var newA= context.Admin.Add(newAdmin);
                context.SaveChanges();
                id = newA.Entity.Id;
            }
            return id;
        }

        public int login(Admin newAdmin)
        {//מחזיר -1 אם לא קייים כזה מנהל אחרת מחזיר את ה-ID
            int id = -1;
            foreach (Admin item in context.Admin)
            {
                if(item.Name.Equals(newAdmin.Name))
                {
                    if (item.Email.Equals(newAdmin.Email.Trim()))
                    {
                        id = item.Id;
                        break;
                    }
                }
            }
            return id;
        }
        public int newProgram(Program newProgram)
        {
            context.Program.Add(newProgram);
            int isOK = context.SaveChanges();
            return isOK;
        }
        public Admin GetAdmin()
        {
            return context.Admin.FirstOrDefault();
        }

    }
}
