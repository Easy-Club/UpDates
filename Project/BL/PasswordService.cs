using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// הגרלת סיסמא
    /// </summary>
   public class PasswordService
    {
       /// <summary>
       /// מקבלת שני מספרים ומגרילה מספר בתחום שבינהם
       /// </summary>
       /// <param name="min"></param>
       /// <param name="max"></param>
       /// <returns></returns>
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        /// <summary>
        /// מקבלת אורך ומשתנה בוליאני ומגרילה מחרוזת באורך שהתקבל 
        /// אם המשתנה הבוליאני הוא חיובי המחרוזת 
        /// תוגרל באותיות קטנות אחרת תוגרל באותיות גדולות
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        /// <summary>
        /// מחזירה סיסמא מוגרלת ע"י שליחה לפונקציות 
        /// תוים 4 ראשונים באותיות קטנות
        ///אח"כ מספר בין בעל 4 ספרות
        ///ובסוף 2 תוים באותיות גדולות
        /// </summary>
        /// <returns></returns>
        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
    }
}
