using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dulich.Models
{
    public class OrderVehicle
    {
        public DateTime NgayDat { get; set; }
        public string Ten {  get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoNguoi { get; set; }
        public DateTime NgayVe {  get; set; }
        public int TuyenDuongDi {  get; set; }
        public string Loai { get; set; }

        public int BrandID { get; set; }
    }
}