using Microsoft.Build.Framework;

namespace LuanVan.Model
{
    public class UserModel
    {
        [Required]
        public string Email { get; set; }
        public string? Sdt { get; set; }
        public string? HoTen { get; set; }
        public string MatKhau { get; set; }
    }
}
