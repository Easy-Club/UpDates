using DAL;
using DTO;
using System;
using System.Linq;
namespace BL
{
    public class ManagerEnterService
    {
        /// <summary>
        /// מקבלת עסק ומבצעת הגרלת סיסמא לעסק ושליחתה במייל למנהל
        /// ManagerEnter ומחזירה אוביקט חדש מסוג 
        /// </summary>
        /// <param name="enterprise"></param>
        /// <returns></returns>
        public static ManagerEnterDTO ManagerEnter(EnterprisesDTO enterprise)
        {
            ManagerEnter managerEnter = new ManagerEnter();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {

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
            return Conversion.ManagerEnterConversion.ConvertToDTO(managerEnter);
        }
        /// <summary>
        /// מקבלת קוד עסק וכתובת מייל ובודקת האם הנתונים תקינים
        /// null אם כן מחזירה את העסק אחרת מחזירה 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="mail"></param>
        /// <returns></returns>
        public static EnterprisesDTO isEnterpriseExist(string code, string mail)
        {
            Enterprises enterprise = new Enterprises();
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                enterprise = db.Enterprises.FirstOrDefault(x => x.Code == code && x.Email == mail);
                return enterprise != null ? Conversion.EnterprisesConversion.ConvertToDTO(enterprise) : null;
            }
        }
        /// <summary>
        /// וסיסמא שנשלחה למייל ManagerEnter מקבלת אוביקט מסוג 
        /// ובודקת האם לא עבר שעה מזמן שליחת הסיסמא אם לא בודקת האם הסיסמא תקינה  
        /// false אחרת תחזיר true אם כן מחזירה   
        /// </summary>
        /// <param name="managerEnter"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool logIn(ManagerEnterDTO managerEnter, string password)
        {
            if (DateTime.Now.Hour - ((DateTime)managerEnter.EnterDate).Hour <= 1)
                if (password == managerEnter.Password)
                    return true;
            return false;
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
        /// <summary>
        /// ומבצעת רישום של העסק לטבלת עסקים EnterprisesDTO מקבלת אוביקט מסוג 
        /// </summary>
        /// <param name="enterpriseDTO"></param>
        /// <returns></returns>
        public static EnterprisesDTO signIn(EnterprisesDTO enterpriseDTO)
        {
            using (ClubCardsEntities db = new ClubCardsEntities())
            {
                try
                {
                    db.Enterprises.Add(Conversion.EnterprisesConversion.ConvertToEnterprises(enterpriseDTO));
                    db.SaveChanges();
                    return enterpriseDTO;
                }
                catch
                {
                    return null;
                }
            }
        }




    }
}
