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
        [HttpGet]
        public IHttpActionResult GetIsEnterpriseExist(string code,string mail)
        {
            EnterprisesDTO enterprise;
           if ((enterprise=ManagerEnterService.isEnterpriseExist(code, mail))== null)
                return BadRequest("Data not vaild");
            return Ok(enterprise);
        }
        [HttpPost]
        public IHttpActionResult PostManagerEnter(EnterprisesDTO enterprise)
        {
            ManagerEnterDTO managerEnter;
            if ((managerEnter = ManagerEnterService.ManagerEnter(enterprise)) == null)
                return BadRequest("System error");
            return Ok( managerEnter);
        }
        [HttpGet]
        public IHttpActionResult GetLogin(ManagerEnterDTO managerEnter,string possword)
        {
            if (ManagerEnterService.logIn(managerEnter, possword))
                return Ok();
            return BadRequest("Data not vaild");
        }
      [HttpPost]
      public IHttpActionResult PostSignIn(EnterprisesDTO enterprise)
        {
            if (ManagerEnterService.signIn(enterprise) == null)
                return BadRequest("System error");
            return Ok("The plugin enterprise successfully");
        }
    }
}
