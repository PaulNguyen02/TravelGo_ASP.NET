using System.Collections.Generic;

namespace dulich.Models
{
    public class ChuyenDuLichDatVeViewModel
    {
        public ChuyenDuLich ChuyenDuLich { get; set; }
        public DatVe DatVe { get; set; } = new DatVe(); 

        public List<TuyenDuong> TuyenDuongs { get; set; }
    }
}