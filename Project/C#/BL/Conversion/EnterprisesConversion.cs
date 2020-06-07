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
    /// covert from DAL to DTO and vise versa
    /// </summary>
    public class EnterprisesConversion
    {
        public static EnterprisesDTO ConvertToDTO(Enterprises Enterprise)
        {
            EnterprisesDTO newEnterprise = new EnterprisesDTO();
            newEnterprise.C_id = Enterprise.C_id;
            newEnterprise.Name = Enterprise.Name;
            newEnterprise.Email = Enterprise.Email;
            newEnterprise.Phone = Enterprise.Phone;
            newEnterprise.Code = Enterprise.Code;
            newEnterprise.Url = Enterprise.Name;
            newEnterprise.Active = Enterprise.Active;
            return newEnterprise;
        }
        public static Enterprises ConvertToEnterprises(EnterprisesDTO EnterpriseDTO)
        {
            Enterprises newEnterprise = new Enterprises();
            newEnterprise.C_id = EnterpriseDTO.C_id;
            newEnterprise.Name = EnterpriseDTO.Name;
            newEnterprise.Email = EnterpriseDTO.Email;
            newEnterprise.Phone = EnterpriseDTO.Phone;
            newEnterprise.Code = EnterpriseDTO.Code;
            newEnterprise.Url = EnterpriseDTO.Name;
            newEnterprise.Active = EnterpriseDTO.Active;
            return newEnterprise;
        }
    }
}
