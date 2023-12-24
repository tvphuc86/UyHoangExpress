using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("QuanHuyen")]
    public class QuanHuyen
    {
        [Key]
        public long MaQuanHuyen { get; set; }
        [Required,MaxLength(200)]
        public string? TenQuanHuyen { get;set; }
        public int? MaTinhThanhPho { get; set; }
        [ForeignKey("MaTinhThanhPho")]
        public virtual TinhThanhPho? TinhThanhPho { get; set; }
        public virtual ICollection<XaPhuong>? XaPhuongs { get; set; }

        public virtual ICollection<ChiTietCuocPhi>? ChiTietCuocPhis { get; set; }
    }
}
