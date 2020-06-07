using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    /// <summary>
    /// מקבלת פרטי עסק נכנס וכתובת מיל של העסק ושולחת מיל לעסק עם סיסמא 
    /// </summary>
    public class EmailService
    {
        public static bool sendMail(ManagerEnter managerEnter, string mail)
        {

            using (MailMessage mm = new MailMessage("easyclub100@gmail.com", mail))
            {

                mm.Body =managerEnter.Password;
                mm.Subject = "EasyClub";
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Timeout = 30 * 1000;
                client.Credentials = new NetworkCredential("easyclub100@gmail.com", "0527627140");
                client.Port = 587;
                client.EnableSsl = true;
                try
                {
                    client.Send(mm);
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
