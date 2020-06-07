using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL.Conversion
{
    /// <summary>
    ///  covert from DAL to DTO and vise versa
    /// </summary>
    public class ManagerEnterConversion
    {
        public static ManagerEnterDTO ConvertToDTO(ManagerEnter managerEnter) {
            ManagerEnterDTO newManagerEnter = new ManagerEnterDTO();
            newManagerEnter.C_id = managerEnter.C_id;
            newManagerEnter.EnterpId = managerEnter.EnterpId;
            newManagerEnter.EnterDate = managerEnter.EnterDate;
            newManagerEnter.Password = managerEnter.Password;
            newManagerEnter.Status = managerEnter.Status;
            return newManagerEnter;
        }
        public static ManagerEnter ConvertToManagerEnter(ManagerEnterDTO managerEnterDTO)
        {
            ManagerEnter newManagerEnter = new ManagerEnter();
            newManagerEnter.C_id = managerEnterDTO.C_id;
            newManagerEnter.EnterpId = managerEnterDTO.EnterpId;
            newManagerEnter.EnterDate = managerEnterDTO.EnterDate;
            newManagerEnter.Password = managerEnterDTO.Password;
            newManagerEnter.Status = managerEnterDTO.Status;
            return newManagerEnter;
        }
    }
}
