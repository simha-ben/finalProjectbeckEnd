using AutoMapper;
using Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories.Models;
using Repositories.Repositories;
using System.Collections.Generic;

namespace ServisesBL
{
    public class ProgramService : IProgramService
    {
        IProgramRepositort programRepo;
        IUserRepository userRepo;
        IGlobalInterface global;
        IMapper mapper;
        IAdminRepository adminRepo;
        public ProgramService(IProgramRepositort repo, IAdminRepository adminRepo, IGlobalInterface c, IMapper m, IUserRepository user)
        {
            this.programRepo = repo;
            this.mapper = m;
            this.userRepo = user;
            this.global = c;
            this.adminRepo = adminRepo;
        }

        public int AddNewProgram(ProgramVM item)
        {
            //     Program p = mapper.Map<Program>(newProgram);
            Program P = new Program();/*= mapper.Map<Program>(item); */
            P.Age = global.convertNameToId("Age", item.Age);
            P.Migdar = global.convertNameToId("Migdar", item.Migdar);
            P.Language = global.convertNameToId("Language", item.Language);
            P.SumOfParticipants = global.convertNameToId("SumOfParticipants", item.SumOfParticipants);
            P.Type = global.convertNameToId("Type", item.Type);
            P.Subject = global.convertNameToId("Subject", item.Subject);
            P.Programer = item.Programer;
            P.Title = item.Title;
            P.Img = item.Img;
            P.Price = item.Price;
            P.Description = item.Description;
            P.PublishDate = item.PublishDate;
            P.Status = -1;
            P.Img = item.Img;

            int prog = programRepo.AddNewProgram(P);
            if (prog > 0)
            {           
                Mail.SendMail(
              "תוכנית חדשה במערכת ממתינה לאישור",
             programRepo.getDetailes(P),
              adminRepo.GetAdmin().Email,
              prog.ToString());
            }

            return prog;
        }


        public List<ProgramVM> GetAllPrograms()
        {
            List<Program> p = programRepo.GetAllPrograms();
            List<ProgramVM> vm = new List<ProgramVM>();
            foreach (var item in p)
            {
                ProgramVM pmv = mapper.Map<ProgramVM>(item);
                //pmv.ProgramerName = userRepo.getUserNameById((int)(item.Programer));
                pmv.Age = global.convert("Age", (int)(item.Age));
                pmv.Migdar = global.convert("Migdar", (int)(item.Migdar));
                pmv.Language = global.convert("Language", (int?)(item.Language));
                pmv.SumOfParticipants = global.convert("SumOfParticipants", (int?)(item.SumOfParticipants));
                pmv.Type = global.convert("Type", (int?)(item.Type));
                pmv.ProgramerName = global.convert("Programer", (int?)(item.Programer));
                pmv.Subject = global.convert("Subject", (int?)(item.Subject));

                vm.Add(pmv);
            }
            return vm;
        }

        public List<string> GetFields(string tableName)
        {
            return global.getAllFiles(tableName);
        }
    }
}
