using AutoMapper;
using Common;
using Repositories.Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServisesBL
{
    public class UserServise : IUserServise
    {
        IUserRepository userRepository;
        IMapper mapper;
        public UserServise(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

       
        public int createNewUser(UserVM uvm)
        {
            Users newU = mapper.Map<Users>(uvm);
            return userRepository.createNewUser(newU);
        }

        public List<string> getAllUsersName()
        {
            return userRepository.getAllUsersName();
        }

        public string getUserById(int id)
        {
            return userRepository.getUserNameById(id);
        }

        public int login(UserVM uvm)
        {
            //מחזיר -1 אם לא קיים כזה משתמש
            //מחזיר -2 אם יש שדה ריק
            //מחזיר -ID 
            int id = -1;
            if (uvm == null || uvm.Email == null || uvm.UserName == null || uvm.Password==null)
                return -2;
           List<Users> context = userRepository.getAllUsers();
           
            foreach (var item in context)
            {
                if (uvm.UserName.Equals(item.UserName))
                {
                    if (item.Email.Equals(uvm.Email.Trim()))
                    {
                        id = item.Id;
                        break;
                    }
                }
            }
            return id;
        }
    }
}
