using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL
{
    public class UsersService
    {
        /// <summary>
        /// מקבלת סיסמת משתמש ומאמתת אותה
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static UsersDTO LogIn(string password,string mail)
        {
            Users UserFound = new Users();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                UserFound = db.Users.ToList().FirstOrDefault(x => x.Password == password && x.Email==mail);
                return UserFound == null ? null : Conversion.UsersConversion.ConvertToDTO(UserFound);
            }
        }
        /// <summary>
        /// מקבלת פרטי משתמש ומוסיפה אותו ברשימת הלקוחות 
        /// </summary>
        /// <param name="usersDTO"></param>
        /// <returns></returns>
        public static UsersDTO SighIn(UsersDTO usersDTO)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                try
                {
                    db.Users.Add(Conversion.UsersConversion.ConvertToUser(usersDTO));
                    db.SaveChanges();
                    return usersDTO;
                }
                catch
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// מקבלת סיסמת לקוח ובודקת האם קים ברשימת הלקוחות
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool isPasswordExist(string password)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                if (db.Users.ToList().FirstOrDefault(x => x.Password == password) == null)
                    return true;
                return false;
            }

        }
        /// <summary>
        /// מקבלת כתובת מיל ובודקת האם קים במערכת
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool isEmailExist(string email)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                if (db.Users.ToList().FirstOrDefault(x => x.Email == email) == null)
                    return true;
                return false;
            }

        }
        /// <summary>
        /// מקבלת קוד כרטיס של עסק ות.ז. של לקוח ובודקת האם קים ללקוח הזה כרטיס מועדון הזהה לכרטיס שהתקבל
        /// </summary>
        /// <param name="enterpCardId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool isClubCardExist(int enterpCardId, string userId)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                if (db.ClubCards.FirstOrDefault(x => x.EnterpCardId == enterpCardId && x.UserId == userId) != null)
                    return true;
                return false;
            }
        }
    }
}
