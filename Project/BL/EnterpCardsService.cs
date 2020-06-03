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
            using(ClubCardsEntities db=new ClubCardsEntities())
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
    }
}
