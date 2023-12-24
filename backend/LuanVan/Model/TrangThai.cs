using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("TrangThaiDonVanChuyen")]
    public class TrangThaiDonHang
        
    {
        [Key]
        public int MaTrangThaiDonVanChuyen { get; set; }

        [Required,StringLength(50)]
        public string TenTrangThai { get; set; }
        public string MoTaTrangThai { get;set; }
        [ForeignKey("MaDonVanChuyen")]
        public List<ChiTietTrangThai>? ChiTietTrangThais { get; set; }
    }
}
