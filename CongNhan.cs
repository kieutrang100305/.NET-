using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamKieuTrang_2023602849_LuyenTapV2
{
    public class CongNhan
    {
        public string MaCN { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string NgaySinh { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public float Luong { get; set; }
        public CongNhan() { }
        public CongNhan(string MaCN,string HoTen,string NgaySinh,string GioiTinh,string DiaChi,float Luong)
        {
            this.MaCN = MaCN;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.DiaChi = DiaChi;
            this.Luong = Luong;
        }
    }
}
