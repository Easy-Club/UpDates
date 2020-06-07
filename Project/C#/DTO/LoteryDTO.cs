using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoteryDTO
    {
        public int C_id { get; set; }
        public byte[] Img { get; set; }
        public Nullable<int> Sum { get; set; }
        public Nullable<int> SumType { get; set; }
        public string Description { get; set; }
        public Nullable<int> EnterpCardId { get; set; }

    }
}
