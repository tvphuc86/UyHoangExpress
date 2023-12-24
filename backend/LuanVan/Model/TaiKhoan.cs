using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string MaTaiKhoan { get; set; }
        [Required,MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string SDT { get; set; }
        [Required]
        [MaxLength(50)]
        public string HoTen { get; set; }
        public bool? HoatDong { get; set; } = false;
        public DateTime? NgaySinh { get; set; }

        public string? Anh { get;set; }
        [Required]
        public byte[]? MatKhau { get; set; }
        public byte[]? MaBam { get;set; }

        public string? SoTaiKhoan { get; set; }
        public string? CodeXacNhan { get;set; }
        [NotMapped]
        public IFormFile? FileImage { get; set; }
        [NotMapped]
        public string? ImgageUrl { get; set; }

        public List<CoVaiTro>? VaiTros { get; set; }

        public List<SoDiaChi>? DiaChis { get; set; }

        public List<NguoiNhanCaNhan>? NguoiNhans { get; set; }

        public List<MatHangCaNhan>? MatHangCaNhans { get; set; }

        public List<DonVanChuyen>? DonVanChuyens { get; set; }

        public List<DonVanChuyen>? DonNhanGiaos { get; set; }

        public List<DonVanChuyen>? DonDuyets { get; set; }


        public List<ThongBao>? ThongBaos { get; set; }

    }
}
