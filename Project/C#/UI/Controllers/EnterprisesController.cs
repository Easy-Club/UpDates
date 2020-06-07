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
    public class EnterprisesController : ApiController
    {
        [HttpGet]
        public List<EnterprisesDTO> GetViewEnterprises()
        {
            return EnterprisesService.ViewEnterprises();
        }
        [HttpGet]
        public List<ClubCardsDTO> GetViewClubCards(int enterpId)
        {
            return EnterprisesService.ViewClubCards(enterpId);
        }
        [HttpGet]
        public List<UsersDTO> GetViewUsers(int enterpId)
        {
            return EnterprisesService.ViewUsers(enterpId);
        }
        [HttpGet]
        public List<EnterpCardsDTO> GetViewEnterpCards(int id)
        {
            return EnterprisesService.ViewEnterpCards(id);
        }
    }
}
