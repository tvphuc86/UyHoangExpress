using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("DuLieuTinhCuoc")]
    public class DuLieuTinhCuoc
    {
        [Key]
        public int MaDuLieuTinhCuoc { get; set; }

        [Required]
        public float GiaTriNac { get; set; }
        [Required]
        public float GiaCuocNac { get; set; }

        public float TrongLuongBatDau { get; set; }

        public int MaTinhThanhPho { get; set; }
        
        public int MaHinhThucVanChuyen { get; set; }

        public float PhiTangNhanVienGiaoHang { get; set; }

        [ForeignKey("MaHinhThucVanChuyen")]
        public virtual HinhThucVanChuyen? HinhThucVanChuyen { get; set; }
        [ForeignKey("MaTinhThanhPho")]
        public virtual TinhThanhPho? TinhThanhPho { get; set; }
    }
}
