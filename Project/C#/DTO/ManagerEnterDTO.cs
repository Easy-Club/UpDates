using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ManagerEnterDTO
    {
        public int C_id { get; set; }
        public Nullable<int> EnterpId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
    }
}
