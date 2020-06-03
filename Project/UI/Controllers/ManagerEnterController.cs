using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BL;
using DTO;
namespace UI.Controllers
{
    public class ManagerEnterController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostSingIn(EnterprisesDTO enterprises)
        {
            if (enterprises == null)
            {
                return BadRequest();//404
            }
            if (ManagerEnterService.isCodeExist(enterprises.Name))
            {
                return BadRequest("Enterprise Code is exist");
            }
            if (ManagerEnterService.isEmailExist(enterprises.Email))
            {
                return BadRequest("email is exist");
            }

            ManagerEnterService.ManagerEnter(enterprises);
            return Ok(enterprises);//200

        }
    }
}
