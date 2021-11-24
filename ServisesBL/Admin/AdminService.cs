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
        public AdminService(IAdminRepository adminRepo, IMapper mapper)
        {
            this.adminRepo = adminRepo;
            this.mapper = mapper;
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

        public int newProgram(ProgramVM newProgram)
        {  
            Program P = mapper.Map<Program>(newProgram);
            return adminRepo.newProgram(P);
        }
    }
}
