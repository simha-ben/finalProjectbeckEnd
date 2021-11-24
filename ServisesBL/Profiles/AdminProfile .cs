using AutoMapper;
using Common;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminVM>().ReverseMap().ForPath((f) => f.Id, opt => opt.Ignore());
        }
      
    }
}
