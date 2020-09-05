using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VTSMicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            int stausCode;
            UserBL objBL = new UserBL();
            int isCreated = objBL.SaveUser(user);
            if (isCreated > 0)
                stausCode = 200;
            else
                stausCode = 422;
                return StatusCode(stausCode);                 
        }

        // PUT api/<UserController>/5
        [HttpPut("{userid}")]
        public ActionResult Put(int userid, [FromBody] User user)
        {
            int stausCode;
            UserBL objBL = new UserBL();
            int isUpdated = objBL.UpdateUser(userid,user);
            if (isUpdated > 0)
                stausCode = 200;
            else
                stausCode = 422;
            return StatusCode(stausCode);
        }

        // DELETE api/<UserController>/5
        [HttpPut("{userid/photopath}")]
        public ActionResult Put(int userid, string PhotoPath)
        {
            int stausCode;
            UserBL objBL = new UserBL();
            int isUpdated = objBL.UploadPhoto(userid, PhotoPath);
            if (isUpdated > 0)
                stausCode = 200;
            else
                stausCode = 422;
            return StatusCode(stausCode);
        }
    }
}
