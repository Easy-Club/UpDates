using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EnterpCardsDTO
    {
        public int C_id { get; set; }
        public decimal Cost { get; set; }
        public Nullable<int> CountPoints { get; set; }
        public Nullable<int> PriseForNewId { get; set; }
        public Nullable<int> PriseForBirthDayId { get; set; }
        public byte[] Img { get; set; }
        public Nullable<int> EnterpId { get; set; }
        public string Type { get; set; }
    }
}
