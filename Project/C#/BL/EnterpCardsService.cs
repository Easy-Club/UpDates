using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL
{
    public class EnterpCardsService
    {
        /// <summary>
        ///מקבלת קוד כרטיס של עסק ובודקת האם קים כרטיס כזה ברשימת הלקוחות אם כן בודקת האם הכרטיס עדין
        /// בתוקף.אם כן לא תנתן אפשרות למחוק את הכרטיס אחרת תשלח אישור למחיקה
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool okToRemove(int id)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                if (db.ClubCards.Where(x => x.EnterpCardId == id && x.ExpireDate >= DateTime.Now) != null)
                    return false;
                return true;
            }
        }
        /// <summary>
        /// מקבלת קוד כרטיס של עסק ומוחקת אותו 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool removeEnterpCard(int id)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                db.EnterpCards.ToList().Remove(db.EnterpCards.FirstOrDefault(x => x.C_id == id));
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// ומבצעת הוספה  של הכרטיס לטבלת כרטיסים לעסק EnterpCardsDTO  מקבלת משתנה מסוג 
        /// </summary>
        /// <param name="enterpCardDTO"></param>
        /// <returns></returns>
        public static EnterpCardsDTO buyEnterpCard(EnterpCardsDTO enterpCardDTO)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                try
                {
                    db.EnterpCards.Add(Conversion.EnterpCardsConversion.ConvertToEnterpCards(enterpCardDTO));
                    db.SaveChanges();
                    return enterpCardDTO;
                }
                catch
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// מקבלת כרטיס בעסק ובודקת האם קיים לעסק כזה כרטיס
        /// </summary>
        /// <param name="enterpCardDTO"></param>
        /// <returns></returns>
        public static bool isEnterpCardExist(EnterpCardsDTO enterpCardDTO)
        {

            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                EnterpCards enterpCard = Conversion.EnterpCardsConversion.ConvertToEnterpCards(enterpCardDTO);
                if (db.EnterpCards.FirstOrDefault(x => x.EnterpId == enterpCard.EnterpId && x.Type == enterpCard.Type) != null)
                    return true;
                return false;
            }
        }
    }
}
