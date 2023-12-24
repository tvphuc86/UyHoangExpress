using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("ChiTietTrangThai")]
    public class ChiTietTrangThai
    {
        public int MaTrangThaiDonVanChuyen { get; set; }
        
        public TrangThaiDonHang? TrangThaiDonHang { get;set; }

        public int MaDonVanChuyen { get; set; }

        public DonVanChuyen? DonVanChuyen { get; set; }

        public string DiaChi { get; set; }

        public DateTime ThoiGian { get; set; }
    }
}
