using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("XaPhuong")]
    public class XaPhuong
    {
        [Key]
        public long MaXaPhuong { get; set; }
        [Required,MaxLength(200)]
        public string? TenXaPhuong { get;set; }

        public long MaQuanHuyen { get; set; }
        [ForeignKey("MaQuanHuyen")]
        public virtual QuanHuyen? QuanHuyen { get; set; }

        public virtual List<NguoiNhanCap3>? NguoiNhanCap3s { get; set; }
    }
}
