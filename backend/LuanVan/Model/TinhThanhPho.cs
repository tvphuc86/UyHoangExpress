using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("TinhThanhPho")]
    public class TinhThanhPho
    {
        [Key]
        public int MaTinhThanhPho { get; set; }
        [Required,MaxLength(200)]
        public string TenTinhThanhPho { get; set; }

        public virtual ICollection<QuanHuyen>? QuanHuyens { get; set; }

        public ICollection<DuLieuTinhCuoc>? DuLieuTinhCuoc { get; set; }

    }
}
