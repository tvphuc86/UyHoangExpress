using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuanVan.Model
{
    [Table("ChiTietCuocPhi")]
    public class ChiTietCuocPhi
    {
        public long? MaCuocPhi { get; set; }

        public long? MaQuanHuyen { get; set; }
        [ForeignKey("MaQuanHuyen")]
        public virtual QuanHuyen? QuanHuyen { get; set; }
        [ForeignKey("MaCuocPhi")]
        public virtual CuocPhi? CuocPhi { get; set; }


    }
}
