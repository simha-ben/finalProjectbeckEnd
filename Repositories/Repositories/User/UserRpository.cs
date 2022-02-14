
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repositories
{
    public  class UserRpository : IUserRepository
    {
        easyPlan context;
        public UserRpository(easyPlan context)
        {
            this.context = context;
        }       

        public int createNewUser(Users newUser)
        {
            int answer = 1;
            //בודק האם קיים כבר משתמש עם מייל כזו ואם כן מחזיר -1
            foreach (var item in context.Users)
            {
                if (newUser.UserName.Equals(item.UserName))
                {
                    if (item.Email.Equals(newUser.Email.Trim()))
                    {
                        answer = -1;
                        break;
                    }
                }
            }
            if (answer!=-1)
            {
                
                var addedUser=context.Users.Add(newUser); 
                try
                {
                    context.SaveChanges();
                }
                catch(Exception ex) { }
                answer= addedUser.Entity.Id;
            }

            return answer;
        }

        public List<Users> getAllUsers()
        {
            return context.Users.ToList();
        }

        public List<string> getAllUsersName()
        {
            List<string> allNames = new List<string>();
            foreach (var item in context.Users)
            {
                allNames.Add(item.UserName);
            }
            return allNames;
        }

        public string getUserNameById(int? id)
        {string name = "";
            try
            {
 
            name = context.Users.Where(u => u.Id == id).FirstOrDefault().UserName;
            return name;
            }
            catch(Exception err)
            {

            }
            return name;
        }

    }
}
