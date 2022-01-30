using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repositories
{
   public class Global:IGlobalInterface
    {
        easyPlan context;
        public Global(easyPlan context)
        {
            this.context = context;
        }
        public string convert(string table,int? id )
        { string res="" ;
            switch (table)
            {   case "Migdar":
                  res = context.Migdar.Where(m => m.Id == id).Select(m => m.Name.Replace("_", " ")).FirstOrDefault();           
                    break;
                case "Subject":
                    res = context.Subject.Where(m => m.Id == id).Select(m => m.Name.Replace("_", " ")).FirstOrDefault();
                    break;
                case "Age":
                    res = context.Age.Where(m => m.Id == id).Select(m => m.Name.Replace("_", " ")).FirstOrDefault();
                    break;
                case "Language":
                    res = context.Language.Where(m => m.Id == id).Select(m => m.Name).FirstOrDefault();
                    break;
                case "SumOfParticipants":
                    res = context.SumOfParticipants.Where(m => m.Id == id).Select(m => m.Name.Replace("_", " ")).FirstOrDefault();
                    break;
                case "Type":
                    res = context.Type.Where(m => m.Id == id).Select(m => m.Name.Replace("_", " ")).FirstOrDefault();
                    break;
                case "Programer":
                    res = context.Users.Where(m => m.Id == id).Select(m => m.UserName.Replace("_", " ")).FirstOrDefault();
                    break;
                default:
                    res = "not faund";
                    break;
            }
            return res;
        }

        public int? convertNameToId(string table, string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                return null;
            int res = -1;
            switch (table)
            {
                case "Migdar":
                    res = context.Migdar.Where(m => m.Name == name).Select(m => m.Id).FirstOrDefault();
                    break;
                case "Subject":
                    res = context.Subject.Where(m => m.Name == name)
                        .Select(m => m.Id).FirstOrDefault();
                    break;
                case "Age":
                    res = context.Age.Where(m => m.Name == name).Select(m => m.Id).FirstOrDefault();
                    break;
                case "Language":
                    res = context.Language.Where(m => m.Name == name).Select(m => m.Id).FirstOrDefault();
                    break;
                case "SumOfParticipants":
                    res = context.SumOfParticipants.Where(m => m.Name == name).Select(m => m.Id).FirstOrDefault();
                    break;
                case "Type":
                    res = context.Type.Where(m => m.Name == name).Select(m => m.Id).FirstOrDefault();
                    break;
                case "Programer":
                    res = context.Users.Where(m => m.UserName == name).Select(m => m.Id).FirstOrDefault();
                    break;
                default:
                    res = -1;
                    break;
            }
            return res;
        }

        public List<string> getAllFiles(string tableName)
        {
            List<string> res;
            switch (tableName)
            {
                case "Migdar":
                    res = context.Migdar.Select(m => m.Name.Replace("_", " ")).ToList();
                    break;
                case "Age":
                    res = context.Age.Select(m => m.Name.Replace("_", " ")).ToList();
                    break;
                case "Language":
                    res = context.Language.Select(m => m.Name.Replace("_", " ")).ToList();
                    break;
                case "Subject":
                    res = context.Subject.Select(m => m.Name.Replace("_", " ")).ToList();
                    break;
                case "SumOfParticipants":
                    res = context.SumOfParticipants.Select(m => m.Name.Replace("_", " ")).ToList();
                    break;
                case "Type":
                    res = context.Type.Select(m => m.Name.Replace("_", " ")).ToList();
                    break;
                case "Programer":
                    res = context.Users.Select(m => m.UserName.Replace("_", " ")).ToList();
                    break;
                default:
                    res = new List<string>();
                    break;
            }
            return res;
        }
    }
}
