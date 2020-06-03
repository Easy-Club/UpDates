using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using DTO;
namespace UI.Controllers
{
    public class EnterpCardsController : ApiController
    {
        /// <summary>
        /// מחיקת כרטיס מועדון 
        /// בדיקה שהכרטיס לא פעיל
        /// הפונקציה מחזירה אישור או סיבת בעיה
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult RemoveEnterpCard(int id)
        {
            if (EnterpCardsService.okToRemove(id))
            {
                return BadRequest("There are cards used");
            }
            var d = EnterpCardsService.removeEnterpCard(id);
            if(d)
           return Ok();
            return BadRequest("System error, please try later");
        }
    }
}
