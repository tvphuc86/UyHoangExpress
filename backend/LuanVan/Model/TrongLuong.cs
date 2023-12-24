using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("TrongLuong")]
    public class TrongLuong
    {
        [Key]
        public int MaTrongLuong { get;set; }

        public float TrongLuongBatDau { get;set; }
        public float TrongLuongKetThuc { get;set; }

        public float PhiNhanVienGiaoHang { get; set; }

        public List<CuocPhi>? CuocPhiList { get; set; }

    }
}
