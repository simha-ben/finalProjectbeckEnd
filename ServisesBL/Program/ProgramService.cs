using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Common;
using Repositories.Models;
using Repositories.Repositories;

namespace ServisesBL
{
  public  class ProgramService : IProgramService
    {
        IProgramRepositort programRepo;
        IUserRepository userRepo;
        IGlobalInterface global;
        IMapper mapper;
        public ProgramService(IProgramRepositort repo, IGlobalInterface c, IMapper m,IUserRepository user)
        {
            this.programRepo = repo;
            this.mapper = m;
            this.userRepo = user;
            this.global = c;
        }
        public List<ProgramVM> getAllPrograms()
        {
            List<Program> p = programRepo.getAllPrograms();
            List<ProgramVM> vm = new List<ProgramVM>();
            foreach (var item in p)
            {
                ProgramVM pmv = mapper.Map<ProgramVM>(item);
                //pmv.ProgramerName = userRepo.getUserNameById((int)(item.Programer));
                pmv.Age = global.convert("Age",(int)(item.Age));               
                pmv.Migdar = global.convert("Migdar", (int)(item.Migdar));               
                pmv.Language = global.convert("Language", (int)(item.Language));               
                pmv.SumOfParticipants = global.convert("SumOfParticipants", (int)(item.SumOfParticipants));               
                pmv.Type = global.convert("Type", (int)(item.Type));               
                pmv.ProgramerName = global.convert("Programer", (int)(item.Programer));               
               
                vm.Add(pmv);
            }
            return vm;
        }

        public List<string> getFields(string tableName)
        {
            return global.getAllFiles(tableName);
        }
    }
}
