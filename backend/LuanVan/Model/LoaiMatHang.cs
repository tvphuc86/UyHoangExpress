using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LuanVan.Model
{
    [Table("LoaiMatHang")]
    public class LoaiMatHang

    {
        [Key]
        public int MaLoaiMatHang { get; set; }

        public string? TenLoaiMatHang { get; set; }

        public string? MoTaLoaiMatHang { get; set; }

        public float KichThuocToiDa { get;set; }

        public float PhuPhiMatHang { get; set; }

        public List<MatHangCaNhan>? MatHangCaNhans { get; set; }

        public List<ChiTietDonVanChuyen>? ChiTietDonVanChuyens { get; set; }


    }
}
