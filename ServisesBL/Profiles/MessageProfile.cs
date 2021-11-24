using AutoMapper;
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL.Profiles
{
    public class MessageProfile : Profile
    {
        //IUserServise userServ;
        //public MessageProfile(IUserServise userServ)
        //{
        //    this.userServ = userServ;
        //}
        public MessageProfile()
        {
            CreateMap<Message, MessageVM>()
                .ForPath((f) => f.FromUserName, opt => opt.Ignore())
                .ForPath((f) => f.ToUserName, opt => opt.Ignore())
                .ReverseMap();
            //       .ForMember(mvm => mvm.ToUser, op => op.MapFrom(m=> userServ.getUserById(m.Id) ))
            //       .ForMember(mvm => mvm.FromUserName, op => op.MapFrom(m => userServ.getUserById(m.Id)));

        }
    }
}
