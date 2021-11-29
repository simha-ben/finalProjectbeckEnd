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
            return userRepository.getUserById(id);
        }

        public int login(UserVM newUser)
        {
            int id = -1;
            if (newUser == null || newUser.Email == null || newUser.UserName == null)
                return id;
           List<Users> context = userRepository.getAllUsers();
            //מחזיר -1 אם לא קיים כזה משתמש
            foreach (var item in context)
            {
                if (newUser.UserName.Equals(item.UserName))
                {
                    if (item.Email.Equals(newUser.Email.Trim()))
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
