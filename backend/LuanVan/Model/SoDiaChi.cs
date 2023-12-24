using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("SoDiaChi")]
    public class SoDiaChi
    {
        [Key]
        public int MaSoDiaChi { get; set; }
        [Required]
        [MaxLength(200)]
        public string? DiaChi { get; set; }
        [Required]
        [MaxLength(50)]

        public string? Ten { get; set; }
        public long? MaXaPhuong { get; set; }
        [ForeignKey("MaXaPhuong")]
        public XaPhuong? XaPhuong { get; set; }

        public string? MaTaiKhoan { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public TaiKhoan? TaiKhoan { get;set; }
    }
}
