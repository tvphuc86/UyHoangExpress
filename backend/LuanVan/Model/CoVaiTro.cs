using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("CoVaiTro")]
    public class CoVaiTro
    {
        public int MaVaiTro { get; set; }
        [ForeignKey("MaVaiTro")]
        public VaiTro? VaiTro { get; set; } = new VaiTro();
        [MaxLength(20)]
        public string MaTaiKhoan { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public TaiKhoan? TaiKhoan { get; set; }
        

    }
}
