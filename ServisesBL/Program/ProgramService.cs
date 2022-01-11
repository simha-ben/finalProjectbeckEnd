﻿using System;
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
            return programRepo.AddNewProgram(P);
        }

       
        public List<ProgramVM> GetAllPrograms()
        {
            List<Program> p = programRepo.GetAllPrograms();
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
                pmv.Subject = global.convert("Subject", (int)(item.Subject));               
               
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
