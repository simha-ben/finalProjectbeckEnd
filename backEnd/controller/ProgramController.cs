using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServisesBL;

namespace BackEndAPI.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        IProgramService programService;
        public ProgramController(IProgramService programService)
        {
            this.programService = programService;
        }
        [HttpGet]
        public List<ProgramVM> getAll()
        {
            return programService.GetAllPrograms();
        }
        [HttpGet("getFields/{TableName}")]
        public List<string> getfieleds(string TableName)
        {
            return programService.GetFields(TableName);
        }

        [HttpPost]
        public int CreateNewProgram(ProgramVM uvm)
        {
            return programService.AddNewProgram(uvm);
        }
    }
}
