using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("ThongBao")]
    public class ThongBao

    {
        [Key]
        public int MaThongBao { get; set; }

        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime NgayTao { get; set; }

        public string MaTaiKhoan { get; set; }

        public bool DaXem { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public TaiKhoan? TaiKhoan { get;set; }
    }
}
