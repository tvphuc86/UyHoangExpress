using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("HinhThucVanChuyen")]
    public class HinhThucVanChuyen
    {
        [Key]
        [Column("MaHinhThucVanChuyen")]
        public int HinhThucVanCHuyenId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Ten { get;set; }
        [Required, MaxLength(250)]
        public string?  MoTa { get; set; }
        public string? Anh { get; set; }
        public bool TrangThai { get; set; }
        public float MucChia { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageUrl { get; set; }

        public ICollection<CuocPhi>? CuocPhi { get; set; }
    }
}
