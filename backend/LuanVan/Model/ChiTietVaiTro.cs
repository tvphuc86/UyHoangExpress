using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("ChiTietVaiTro")]
    public class ChiTietVaiTro
    {
        public int MaQuyen { get; set; }
        public int MaVaiTro { get; set; }
        [ForeignKey(nameof(MaVaiTro))]
        public VaiTro? VaiTro { get; set; } 
        [ForeignKey(nameof(MaQuyen))]
        public Quyen?  Quyen { get; set; } 
    }
}
