using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("BaoHiemDonVanChuyen")]
    public class BaoHiemDonVanChuyen
    {
        [Key]
        public int MaBaoHiemDonVanChuyen { get; set; }

        public float GiaTriBatDau { get; set; }

        public float GiaTriKetThuc { get;set; }

        public float PhiBaoHiem { get; set; }


        public List<DonVanChuyen>?   DonVanChuyens { get; set; }

    }
}
