using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("Quyen")]
    public class Quyen
    {
        [Key]
        public int MaQuyen { get; set; }
        [Required,MaxLength(50)]
        public string TenQuyen { get; set; }
        [ MaxLength(200)]
        public string MoTa { get; set; }
        public List<ChiTietVaiTro>? VaiTros { get; set; }
    }
}
