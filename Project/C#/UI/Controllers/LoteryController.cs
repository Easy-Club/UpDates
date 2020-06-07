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
    public class LoteryController : ApiController
    {
        [HttpGet]
        public List<LoteryDTO> GetViewLoteryForCard(ClubCardsDTO clubCard)
        {
            return LoteryService.ViewLoteryForCard(clubCard);
        }
    }
}
