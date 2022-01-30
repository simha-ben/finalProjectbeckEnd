using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public int CreateNewProgram([FromForm] FileModel file, [FromForm] string jsonString)
        {
            ProgramVM pvm = JsonConvert.DeserializeObject<ProgramVM>(jsonString);
            try{
                if (Directory.GetCurrentDirectory() != null)
                {

                    var x = file.FileName.Split('.');
                    var type = x[x.Length - 1];
                    file.FileName = pvm.Title + "." + type;
                    pvm.Img = file.FileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.FormFile.CopyTo(stream);
                    }
                    return programService.AddNewProgram(pvm);

                }
            }
            catch(Exception err)
            {}
            return -1;
        }
    }
}
