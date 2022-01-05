using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Common;
using Repositories.Models;
using Repositories.Repositories;

namespace ServisesBL
{
    public class AdminService : IAdminService
    {
        IAdminRepository adminRepo;
        IMapper mapper;
        IGlobalInterface global;
        public AdminService(IAdminRepository adminRepo, IGlobalInterface global,IMapper mapper)
        {
            this.adminRepo = adminRepo;
            this.mapper = mapper;
            this.global = global;
        }

        public void changeProgramStatus(int? programId, int? status)
        {
            if(programId!=null &&status!= null)
                 adminRepo.changeProgramStatus(programId, status);
        }

        public int createNewAdmin(AdminVM newAdmin)
        {
            Admin newA = mapper.Map<Admin>(newAdmin);
            return adminRepo.createNewAdmin(newA);
        }

        public int login(AdminVM newAdmin)
        {
            Admin A = mapper.Map<Admin>(newAdmin);
            return adminRepo.login(A);
        }

        public int newProgram(ProgramVM item)
        {
            Program P=new Program();/*= mapper.Map<Program>(item); */           
            P.Age = global.convertNameToId("Age",item.Age);
            P.Migdar = global.convertNameToId("Migdar", item.Migdar);
            P.Language = global.convertNameToId("Language", item.Language);
            P.SumOfParticipants = global.convertNameToId("SumOfParticipants",item.SumOfParticipants);
            P.Type = global.convertNameToId("Type",item.Type);
            P.Subject = global.convertNameToId("Subject",item.Subject);
            P.Programer = global.convertNameToId("Programer",item.ProgramerName);
            P.Title = item.Title;
            P.Price = item.Price;
            P.Description = item.Description;
            P.PublishDate = item.PublishDate;
            P.Status = -1;
            return adminRepo.newProgram(P);
        }
    }
}
