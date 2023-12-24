using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("MatHangCaNhan")]
    public class MatHangCaNhan
    {
        [Key]
        public int MaMatHangCaNhan { get; set; }

        public float ChieuRong { get; set; }
        public float ChieuCao { get; set; }
        public float ChieuDai { get; set; }
        public float GiaTri { get; set; }
        public float TrongLuong { get; set; }

        public DateTime? NgayDuyet {get;set;} 

        public bool Duyet { get;set; }


        [Required]
        [MaxLength(50)]
        public string TenMatHangCaNhan { get; set; }

        public string MaTaiKhoan { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public TaiKhoan? TaiKhoan { get; set; }

        public int MaLoaiMatHang { get; set; }



        [ForeignKey("MaLoaiMatHang")]
        public LoaiMatHang? LoaiMatHang { get; set; }
    }
}
