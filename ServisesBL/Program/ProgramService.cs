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
        IMapper mapper;
        public ProgramService(IProgramRepositort repo,IMapper m,IUserRepository user)
        {
            this.programRepo = repo;
            this.mapper = m;
            this.userRepo = user;
        }
        public List<ProgramVM> getAllPrograms()
        {
            List<Program> p = programRepo.getAllPrograms();
            List<ProgramVM> vm = new List<ProgramVM>();
            foreach (var item in p)
            {
                ProgramVM pmv = mapper.Map<ProgramVM>(item);
                pmv.ProgramerName = userRepo.getUserById((int)(item.Programer));
                vm.Add(pmv);
            }
            return vm;
        }
    }
}
