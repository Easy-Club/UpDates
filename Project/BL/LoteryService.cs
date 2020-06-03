using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL
{
    public class LoteryService
    {
       /// <summary>
       // מקבלת כרטיס מועדון ומחזירה רשימה של כל המבצעים בכרטיס הזה
       /// </summary>
       /// <param name="clubCard"></param>
       /// <returns></returns>
        public static List<LoteryDTO> ViewLoteryForCard(ClubCardsDTO clubCard)
        {
            List<LoteryDTO> loteriesDTO = new List<LoteryDTO>();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                if (clubCard.StatusPriseForNew == true)
                    loteriesDTO.Add(Conversion.LoteryConversion.ConvertToDTO(db.Lotery.FirstOrDefault(y => y.C_id == (db.EnterpCards.FirstOrDefault(x => x.C_id == clubCard.EnterpCardId).PriseForNewId))));
                if (clubCard.StatusPriseForBirthDay == true)
                    loteriesDTO.Add(Conversion.LoteryConversion.ConvertToDTO(db.Lotery.FirstOrDefault(y => y.C_id == (db.EnterpCards.FirstOrDefault(x => x.C_id == clubCard.EnterpCardId).PriseForBirthDayId))));
                db.Lotery.ToList().ForEach(x =>
                {
                    if (x.EnterpCardId == clubCard.EnterpCardId)
                        loteriesDTO.Add(Conversion.LoteryConversion.ConvertToDTO(x));
                });
                loteriesDTO.Add(Conversion.LoteryConversion.ConvertToDTO(db.Lotery.FirstOrDefault(x => x.C_id == clubCard.AppLoteryId)));
            }
            return loteriesDTO;
        }

    }
}
