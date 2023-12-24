using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("VaiTro")]
    public class VaiTro
    {
        [Key]
        public int MaVaiTro { get; set; }

        [Required]
        [MaxLength(50)]
        public string? TenVaiTro { get; set; }

        public string? MoTa { get; set; }
        public List<CoVaiTro>? TaiKhoans { get; set; }

        public List<ChiTietVaiTro>? Quyens { get; set; }
    }
}
