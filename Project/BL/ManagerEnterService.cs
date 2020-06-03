using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL
{
    public class ManagerEnterService
    {
        /// <summary>
        /// מקבלת עסק ומבצעת כניסת מנהל הכוללת הגרלת סיסמא ושליחתה במיל למנהל
        /// </summary>
        /// <param name="enterprise"></param>
        /// <returns></returns>
        public static EnterprisesDTO ManagerEnter(EnterprisesDTO enterprise)
        {

            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                ManagerEnter managerEnter = new ManagerEnter();
                managerEnter.EnterDate = new DateTime();
                managerEnter.EnterpId = enterprise.C_id;
                managerEnter.Password = PasswordService.RandomPassword();
                managerEnter.Status = false;
                try
                {
                    db.ManagerEnter.Add(managerEnter);
                    db.Enterprises.Add(Conversion.EnterprisesConversion.ConvertToEnterprises(enterprise));
                    db.SaveChanges();
                }
                catch
                {
                    return null;
                }
                EmailService.sendMail(managerEnter, enterprise.Email);
            }
            return enterprise;
        }
        public static EnterprisesDTO isEnterpriseExist(string code)
        {
            Enterprises enterprise = new Enterprises();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                enterprise = db.Enterprises.FirstOrDefault(x => x.Code == code);
                return enterprise != null ? Conversion.EnterprisesConversion.ConvertToDTO(enterprise) : null;
            }
        }
        public static  logIn(int enterpId,int managerEnterId, string password)
        {

        }
        /// <summary>
        /// מקבלת מספר עוסק מורשה ובודקת האם קים ברשימת העסקים
        /// </summary>
        /// <param name="EnterpCode"></param>
        /// <returns></returns>
        public static bool isCodeExist(string EnterpCode)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                if (db.Enterprises.ToList().FirstOrDefault(x => x.Name == EnterpCode) == null)
                    return true;
                return false;
            }

        }
        /// <summary>
        /// מקבלת כתובת מיל ובודקת האם קים ברשימת העסקים
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool isEmailExist(string email)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                if (db.Enterprises.ToList().FirstOrDefault(x => x.Email == email) == null)
                    return true;
                return false;
            }

        }




    }
}
