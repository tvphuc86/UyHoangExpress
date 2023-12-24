using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LuanVan.Model
{
    [Table("NguoiNhanCap3")]
    public class NguoiNhanCap3 
    {
        [Key]
        public int MaNguoiNhanCap3 { get; set; }
        [Required]
        [StringLength(50)]
        public string TenNguoiNhanCap3 { get; set; }
        [Required]
        [StringLength(200)]

        public string DiaChiNguoiNhanCap3 { get; set; }
      public string SoDienThoaiNguoiNhanCap3 { get; set; }
        public int MaNguoiNhan { get; set; }
        [ForeignKey("MaNguoiNhan")]
        public virtual NguoiNhanCaNhan? NguoiNhanCaNhan { get; set; }

        public long MaXaPhuong { get; set; }
        [ForeignKey("MaXaPhuong")]
        public virtual XaPhuong? XaPhuong { get; set; }
    }
}
