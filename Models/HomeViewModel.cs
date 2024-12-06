using dulich.Models;
using System.Collections.Generic;

public class HomeViewModel
{
    public List<ChuyenDuLich> ChuyenDuLichList { get; set; }
    public List<Nhaxe> NhaxeList { get; set; }
    public List<Maybay> MaybayList { get; set; }
    public List<Tau> TauList { get; set; }
    public List<TuyenDuong> TuyenDuongList { get; set; }

    public List<ChuyenDuLich> chuyenDuLiches { get; set; }
}