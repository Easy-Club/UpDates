using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL.Conversion
{
    /// <summary>
    /// covert from DAL to DTO and vise versa
    /// </summary>
    public class EnterpCardsConversion
    {
        public static EnterpCardsDTO ConvertToDTO(EnterpCards EnterpCard)
        {
            EnterpCardsDTO newEnterpCard = new EnterpCardsDTO();
            newEnterpCard.C_id = EnterpCard.C_id;
            newEnterpCard.Cost = EnterpCard.Cost;
            newEnterpCard.EnterpId = EnterpCard.EnterpId;
            newEnterpCard.Type = EnterpCard.Type;
            newEnterpCard.Img = EnterpCard.Img;
            newEnterpCard.CountPoints = EnterpCard.CountPoints;
            newEnterpCard.PriseForBirthDayId = EnterpCard.PriseForBirthDayId;
            newEnterpCard.PriseForNewId = EnterpCard.PriseForNewId;
            return newEnterpCard;
        }
        public static EnterpCards ConvertToEnterpCards(EnterpCardsDTO EnterpCardDTO)
        {

            EnterpCards newEnterpCard = new EnterpCards();
            newEnterpCard.C_id = EnterpCardDTO.C_id;
            newEnterpCard.Cost = EnterpCardDTO.Cost;
            newEnterpCard.EnterpId = EnterpCardDTO.EnterpId;
            newEnterpCard.Type = EnterpCardDTO.Type;
            newEnterpCard.Img = EnterpCardDTO.Img;
            newEnterpCard.CountPoints = EnterpCardDTO.CountPoints;
            newEnterpCard.PriseForBirthDayId = EnterpCardDTO.PriseForBirthDayId;
            newEnterpCard.PriseForNewId = EnterpCardDTO.PriseForNewId;
            return newEnterpCard;
        }
    }
}
