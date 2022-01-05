using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServisesBL;
using Common;

namespace BackEndAPI.controler
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        IUserServise userSer;

        public UserController(IUserServise userSer)
        {
            this.userSer = userSer;
        }
        [HttpGet]
        public List<string> GetAllNames()
        {
            return userSer.getAllUsersName();
        }
        [HttpPost("login")]
        public int Login(UserVM uvm)
        {
            return userSer.login(uvm);
        }
        [HttpPost]
        public int CreateNewUser(UserVM uvm)
        {
            return userSer.createNewUser(uvm);
        }
        [HttpGet("getName/{id}")]
        public string getUsernamebyId(int id)
        {
            return userSer.getUserById(id);
        }
    }
}
