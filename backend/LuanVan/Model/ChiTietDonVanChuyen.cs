using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("ChiTietDonVanChuyen")]
    public class ChiTietDonVanChuyen
    {
        [Key]
        public int MaChiTietDonVanChuyen { get; set; }
        [Required]
        [StringLength(50)]
        public string TenHangHoa { get; set; }

        public float ChieuCao { get; set; }

        public float ChieuRong { get; set; }

        public float TrongLuong { get; set; }

        public float ChieuDai { get; set; }

        public float GiaTri { get; set; }

        public int SoLuong { get; set; }

        public int MaDonVanChuyen { get; set; }
        [ForeignKey("MaDonVanChuyen")]
        public DonVanChuyen? DonVanChuyen { get; set; }

        public int MaLoaiMatHang { get; set; }
        [ForeignKey("MaLoaiMatHang")]
        public LoaiMatHang? LoaiMathang { get; set; }

    }
}
