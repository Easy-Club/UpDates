using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL
{
    public class EnterprisesService
    {
        /// <summary>
        /// מחזירה רשימה של כל העסקים הרשומים באתר
        /// </summary>
        /// <returns></returns>
        public static List<EnterprisesDTO> ViewEnterprises()
        {

            List<EnterprisesDTO> enterprisesDTO = new List<EnterprisesDTO>();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                db.Enterprises.ToList().ForEach(x =>
                {
                    enterprisesDTO.Add(Conversion.EnterprisesConversion.ConvertToDTO(x));
                });
                return enterprisesDTO;
            }
        }
        /// <summary>
        /// עוברת פעם בחודש על רשימת העסקים ומוחקת עסק לא פעיל
        /// </summary>
        public static void RemoveEnterprises()
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                db.Enterprises.ToList().ForEach(x =>
                {
                    if (x.Active == false)
                        db.Enterprises.Remove(x);
                });
                db.SaveChanges();
            }
        }
        /// <summary>
        /// מקבלת קוד עסק ומחזירה רשימה של כל פרטי הכרטיסים של לקוחות העסק
        /// </summary>
        /// <param name="enterpId"></param>
        /// <returns></returns>
        public static List<ClubCardsDTO> ViewClubCards(int enterpId)
        {
            List<ClubCardsDTO> CardsForEnterprise = new List<ClubCardsDTO>();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                db.ClubCards.ToList().ForEach(x =>
                {
                    if (x.C_id == enterpId)
                        CardsForEnterprise.Add(Conversion.ClubCardsConversion.ConvertToDTO(x));
                });
                return CardsForEnterprise;
            }
        }
       /// <summary>
       /// מקבלת קוד עסק ומחזירה רשימה של לקוחות העסק
       /// </summary>
       /// <param name="enterpId"></param>
       /// <returns></returns>
        public static List<UsersDTO> ViewUsers(int enterpId)
        {
            List<UsersDTO> UsersForEnterprise = new List<UsersDTO>();
            List<ClubCardsDTO> CardsForEnterprise = new List<ClubCardsDTO>();
            CardsForEnterprise = ViewClubCards(enterpId);
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                CardsForEnterprise.ForEach(x =>
                {
                    db.Users.ToList().ForEach(y =>
                    {
                        if (x.UserId == y.C_id)
                            UsersForEnterprise.Add(Conversion.UsersConversion.ConvertToDTO(y));
                    });
                });
                return UsersForEnterprise;
            }
        }
        /// <summary>
        /// מקבלת קוד עסק ומחזירה רשימה של כרטיסי מועדון של העסק
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<EnterpCardsDTO> ViewEnterpCards(int enterpId)
        {
            List<EnterpCardsDTO> enterpCards = new List<EnterpCardsDTO>();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                db.EnterpCards.ToList().ForEach(x =>
                {
                    if (x.EnterpId == enterpId)
                        enterpCards.Add(Conversion.EnterpCardsConversion.ConvertToDTO(x));
                }
                );
            }
            return enterpCards;

        }
    }
}
