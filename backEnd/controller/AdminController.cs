using Common;
using Microsoft.AspNetCore.Mvc;
using ServisesBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController: ControllerBase
    {
        IAdminService adnimService;
        public AdminController(IAdminService adnimService)
        {
            this.adnimService = adnimService;
        }
        [HttpPost("login")]
        public int Login(AdminVM avm)
        {
            return adnimService.login(avm);
        }
        [HttpPost]
        public int CreateNewAdmin(AdminVM avm)
        {
            return adnimService.createNewAdmin(avm);
        }
        [HttpPost("newProgram")]
        public int CreateNewPrpgram(ProgramVM pvm)
        {
            return adnimService.newProgram(pvm);
        }
        [HttpPost("changeStatus")]
        public void changeStatus(int? programId,int?status)
        {
            adnimService.changeProgramStatus(programId, status);
        }


    }
}
