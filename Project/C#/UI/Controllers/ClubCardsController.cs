using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BL;
namespace UI.Controllers
{
    public class ClubCardsController : ApiController
    {
        [HttpGet]
        public List<ClubCardsDTO> GetViewCards(string password)
        {
            return ClubCardsService.ViewCards(password);
        }
    }
}
