using AutoMapper;
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users, UserVM>().ReverseMap().ForPath((f) => f.Id, opt => opt.Ignore());
        }
      
    }
}
