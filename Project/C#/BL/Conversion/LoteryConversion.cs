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
    public class LoteryConversion
    {
        public static LoteryDTO ConvertToDTO(Lotery lotery)
        {
            LoteryDTO newLotery = new LoteryDTO();
            newLotery.C_id = lotery.C_id;
            newLotery.EnterpCardId = lotery.EnterpCardId;
            newLotery.Description = lotery.Description;
            newLotery.Img = lotery.Img;
            newLotery.Sum = lotery.Sum;
            newLotery.SumType = lotery.SumType;
            return newLotery;
        }
        public static Lotery ConvertToLotery(LoteryDTO loteryDTO)
        {
            Lotery newLotery = new Lotery();
            newLotery.C_id = loteryDTO.C_id;
            newLotery.EnterpCardId = loteryDTO.EnterpCardId;
            newLotery.Description = loteryDTO.Description;
            newLotery.Img = loteryDTO.Img;
            newLotery.Sum = loteryDTO.Sum;
            newLotery.SumType = loteryDTO.SumType;
            return newLotery;
        }
    }
}
