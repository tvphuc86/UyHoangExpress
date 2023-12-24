using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("NguoiNhanCaNhan")]
    public class NguoiNhanCaNhan
    {
        [Key]
        public int MaNguoiNhanCaNhan { get; set; }
        [Required]
        [StringLength(50)]
        public string TenNguoiNhanCaNhan { get; set; }
        [Required]
        [StringLength(200)]
        
         public string DiaChiNguoiNhanCaNhan { get; set; }
        [MaxLength(20)]
        public string MaTaiKhoan { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public virtual TaiKhoan? TaiKhoan { get; set; }

        public List<NguoiNhanCap3>? NguoiNhanCap3s { get; set; }

        public string SoDienThoaiCaNhan { get;set; }
        public long MaXaPhuong { get; set; }
        [ForeignKey("MaXaPhuong")]
        public virtual XaPhuong? XaPhuong { get; set; }
    }
}
