using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BL
{
   
    /// <summary>
    /// מקבלת ת.ז. של לקוח ומחזירה רשימת כרטיסי מועדון השיכים ללקוח הזה
    /// </summary>
    public class ClubCardsService
    {
        public static List<ClubCardsDTO> ViewCards(string id)
        {
            List<ClubCardsDTO> MyCardsDTO = new List<ClubCardsDTO>();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                db.ClubCards.ToList().ForEach(x =>
                {
                    if (x.UserId == id)
                        MyCardsDTO.Add(Conversion.ClubCardsConversion.ConvertToDTO(x));
                });
                return MyCardsDTO;
            }
        }
    }
   
}
