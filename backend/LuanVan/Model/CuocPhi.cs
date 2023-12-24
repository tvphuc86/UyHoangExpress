using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("CuocPhi")]
    public class CuocPhi
    {
        [Key]
        public long MaCuocPhi { get; set; }
        [Required]
        public float GiaCuoc { get; set; }
        public string? ThoiGianGiao { get; set; }
        
        public int MaTrongLuong { get; set; }

        [ForeignKey("MaTrongLuong")]
        public TrongLuong? TrongLuong { get; set; }

        public int MaHinhThucVanChuyen { get; set; }
        [ForeignKey("MaHinhThucVanChuyen")]
        public  HinhThucVanChuyen? HinhThucVanChuyen { get; set; } 
        public ICollection<ChiTietCuocPhi>?  ChiTietCuocPhis{ get; set; }
    }
}
