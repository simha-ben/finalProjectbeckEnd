using AutoMapper;
using Common;
using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL.Profiles
{
    public class ProgramProfile : Profile
    {
        IGlobalInterface convert;
        public ProgramProfile(IGlobalInterface convert)
        {
            this.convert = convert;
        }
        public ProgramProfile()
        {
            CreateMap<Program, ProgramVM>().ReverseMap();
                //.ForPath((f) => f.Id, opt => opt.Ignore())
                //.ForMember((f) => f.Programer, opt => opt.Ignore());
            //.ForMember(pVM => pVM.Migdar, act => act.MapFrom(p =>convert.convert("Migdar",(int) (p.Migdar))))
            //.ForMember(pVM => pVM.Language, act => act.MapFrom(p =>convert.convert("Language", (int) (p.Language))))
            //.ForMember(pVM => pVM.Subject, act => act.MapFrom(p =>convert.convert("Subject", (int) (p.Subject))))
            //.ForMember(pVM => pVM.Age, act => act.MapFrom(p =>convert.convert("Age",(int) (p.Age))))
            //.ForMember(pVM => pVM.ProgramerName, act => act.MapFrom(p =>convert.convert("Programer", (int) (p.Programer))))
            //.ForMember(pVM => pVM.SumOfParticipants, act => act.MapFrom(p =>convert.convert("SumOfParticipants", (int) (p.SumOfParticipants))))
            //.ForMember(pVM => pVM.Type, act => act.MapFrom(p =>convert.convert("Type",(int) (p.Type))));

            //.ForMember(pVM => pVM.Migdar, act => { act.PreCondition(src => (src.Migdar != null)); act.MapFrom(p => convert.convert("Migdar", (int)(p.Migdar))); })
            //   .ForMember(pVM => pVM.Language, act => { act.PreCondition(src => (src.Language != null)); act.MapFrom(p => convert.convert("Language", (int)(p.Language))); })
            //   .ForMember(pVM => pVM.Subject, act => { act.PreCondition(src => (src.Migdar != null)); act.MapFrom(p => convert.convert("Subject", (int)(p.Subject))); })
            //   .ForMember(pVM => pVM.Age, act => { act.PreCondition(src => (src.Migdar != null)); act.MapFrom(p => convert.convert("Age", (int)(p.Age))); })
            //   .ForMember(pVM => pVM.ProgramerName, act => { act.PreCondition(src => (src.Migdar != null)); act.MapFrom(p => convert.convert("Programer", (int)(p.Programer))); })
            //   .ForMember(pVM => pVM.SumOfParticipants, act => { act.PreCondition(src => (src.Migdar != null)); act.MapFrom(p => convert.convert("SumOfParticipants", (int)(p.SumOfParticipants))); })
            //   .ForMember(pVM => pVM.Type, act => { act.PreCondition(src => (src.Migdar != null)); act.MapFrom(p => convert.convert("Type", (int)(p.Type))); });


        }

    }
}
