using LuanVan.Data;
using LuanVan.Model;
using LuanVan.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/tai-khoan")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ISMSService _sms;
        private readonly AppSettings _option;

        public AccountController(MyDbContext context, IWebHostEnvironment env, ISMSService sMSService, IOptionsMonitor<AppSettings> options) {
            _context = context;
            _env = env;
            _sms = sMSService;
            _option = options.CurrentValue;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IActionResult getTaiKhoan(string id)
        {
            return Ok(_context.TaiKhoans.Where(m => m.MaTaiKhoan == id).Select(m => new
            {
                HoTen = m.HoTen,
                sdt = m.SDT
            }));
        }
     
        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            var taiKhoan = _context.TaiKhoans.Include(m => m.VaiTros).Where(m => m.MaTaiKhoan == id).Single();

            taiKhoan.ImgageUrl = String.Format("{0}://{1}{2}/Images/TaiKhoan/{3}", Request.Scheme, Request.Host, Request.PathBase, taiKhoan.Anh);
            var role = _context.CoVaiTros.Where(m => m.MaTaiKhoan == taiKhoan.MaTaiKhoan).Include(m => m.VaiTro.Quyens).ToList();
            var data = new
            {
                taiKhoan = taiKhoan,
                role = role,
            };
            return Ok(data);
        }
        [NonAction]
        private void AddVaiTro(string maTaiKhoan, int MaVaiTro)
        {
            var obj = new CoVaiTro();
            obj.MaTaiKhoan = maTaiKhoan;
            obj.TaiKhoan = null;
            obj.VaiTro = null;
            obj.MaVaiTro = MaVaiTro;
            _context.CoVaiTros.Add(obj);
            _context.SaveChanges();
        }
        [HttpPost("GuiMaDienThoai")]
        public IActionResult GuiSMS(string phoneNumber)
        {
            var random = new Random();
            var DTO = random.Next(1000, 10000);
            var result = _sms.Send(phoneNumber,DTO.ToString() );
            if(!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);
            return Ok(result);
        }
        [NonAction]
        public bool GuiOPT(string mailTo, TaiKhoan user)
        {
            try
            {
                
                var random = new Random();
                int otp = random.Next(10000, 100000);

                user.CodeXacNhan = otp.ToString();
                _context.TaiKhoans.Update(user);
                _context.SaveChanges();

                var fromAddress = new MailAddress("tvphuc860@gmail.com");
                var toAddress = new MailAddress(mailTo);
                const string Subject = "UY HOANG OTP CODE";
                const string frompass = "uyfjahjbbmtstlqb";
                string body = "Opt: " + otp.ToString()  ;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();
                mail.From = fromAddress;
                mail.To.Add(toAddress);
                mail.Subject = Subject;
                mail.Body = body;
                SmtpServer.UseDefaultCredentials = false;
                NetworkCredential NetworkCred = new NetworkCredential(fromAddress.Address, frompass);
                SmtpServer.Credentials = NetworkCred;
                SmtpServer.EnableSsl = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.Send(mail);

                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        [HttpPost("xacminhotp")]
        public IActionResult XacMinhOtp(string otp, string email) {

            var TaiKhoan = _context.TaiKhoans.Where(m => m.Email.ToUpper().Equals(email.ToUpper())).FirstOrDefault();
            if (TaiKhoan == null)
            {
                return NotFound();
            }
            if(TaiKhoan.CodeXacNhan == otp)
            {
                TaiKhoan.HoatDong = true;
                _context.TaiKhoans.Update(TaiKhoan);
                _context.SaveChanges();
           
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = null,
                    Messgae = "Xác minh thành công"
                }) ;
            }
            else return Ok(new ResponseModel()
            {
                Result = false,
                Data = null,
                Messgae = "Mã xác nhận sai"
            });


        }
        // POST api/<AccountController>
        [HttpPost("dang-ky")]
        public IActionResult Post( UserModel newRecord)
        {
            if (_context.TaiKhoans.Where(m=> m.Email.ToUpper().Equals(newRecord.Email.ToUpper()) 
            || m.SDT.ToUpper().Equals(newRecord.Sdt.ToUpper())).Any())
            {
                return Ok(new ResponseModel
                {
                    Data = null,
                    Messgae = "Email hoặc số điện thoại đã được sử dụng. Vui lòng đăng ký bằng email khác",
                    Result = false
                }
            );
            }

            CreatedPasswordHash(newRecord.MatKhau, out byte[] passwordHash,out  byte[] passwordSalt);
            var newTaiKhoan = new TaiKhoan();
            newTaiKhoan.Email = newRecord.Email;
            newTaiKhoan.SDT = newRecord.Sdt;
            newTaiKhoan.HoatDong = false;
            newTaiKhoan.HoTen = newRecord.HoTen;
            newTaiKhoan.MaBam = passwordSalt;
            newTaiKhoan.MatKhau = passwordHash;
            newTaiKhoan.MaTaiKhoan = "KH" + DateTime.Now.ToString("yymmssfff");
            newTaiKhoan.VaiTros = null;
            newTaiKhoan.VaiTros = new List<CoVaiTro>();
            _context.TaiKhoans.Add(newTaiKhoan);
            _context.SaveChanges();
            AddVaiTro(newTaiKhoan.MaTaiKhoan, 2);

            return Ok(new ResponseModel
            {
                Data = newTaiKhoan,
                Messgae = "Tạo thành công tài khoản",
                Result = true
            }
            );
        }
        private bool VerifyPassword(string password,  byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatedPasswordHash(string password, out  byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash =hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        
        [HttpPost("dang-nhap")]
        public IActionResult DangNhap (UserModel user)
        {
            var TaiKhoan = _context.TaiKhoans.Where(m=>m.Email.Equals(user.Email)).FirstOrDefault();
            
            if (TaiKhoan == null)
            {
                return Ok( new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Email sai"
                });
            }
            

            if (VerifyPassword(user.MatKhau, TaiKhoan.MatKhau, TaiKhoan.MaBam))
            {
                if (!TaiKhoan.HoatDong ==true)
                {
                    if (GuiOPT(TaiKhoan.Email,TaiKhoan))
                    {
                        return Ok(new ResponseModel()
                        {
                            Result = false,
                            Data = 0,
                            Messgae = "Tài khoản của bạn chưa được xác minh email. Vui lòng xác minh emaiil để đăng nhập"
                        });
                    }
                    else
                    {
                        return Ok(new ResponseModel()
                        {
                            Result = false,
                            Data = 0,
                            Messgae = "Có lỗi khi đăng nhập"
                        });
                    }
                }

                var stringRole = "";
                var Quyens = new List<Quyen>();
                var VaiTro1 = new List<ChiTietVaiTro>();

                var VaiTro = _context.CoVaiTros.Where(m => m.MaTaiKhoan == TaiKhoan.MaTaiKhoan).ToList();

                foreach (var item in VaiTro)
                {
                    VaiTro1 = _context.ChiTietVaiTros.Where(m => m.MaVaiTro == item.MaVaiTro).ToList();
                }
                foreach (var item in VaiTro1)
                {
                    var Quyen = _context.Quyens.Where(m => m.MaQuyen == item.MaQuyen).First();
                    Quyens.Add(Quyen);
                }
                foreach (var item in Quyens)
                {
                    stringRole = stringRole + item.TenQuyen + ",";
                }

                var result = GennerateToken(TaiKhoan);
                var data = new
                {
                    role = stringRole,
                    username = TaiKhoan.HoTen,
                    maTaiKhoan = TaiKhoan.MaTaiKhoan,
                    sdt= TaiKhoan.SDT,
                    image =  String.Format("{0}://{1}{2}/Images/TaiKhoan/{3}", Request.Scheme, Request.Host, Request.PathBase, TaiKhoan.Anh)
            };
              
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = data,
                    Messgae = "Đăng nhập thành công"
                });
            }
            else
            {
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = 1,
                    Messgae = "Sai mật khẩu"
                });
            }
        }
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id ,[FromForm] TaiKhoan taiKhoan)
        {
            var obj = _context.TaiKhoans.Where(m=>m.MaTaiKhoan==taiKhoan.MaTaiKhoan).FirstOrDefault();
            if (obj == null)
            {
                return BadRequest();
            }
            if (taiKhoan.FileImage != null)
            {
                DeleteImage(taiKhoan.Anh);
                taiKhoan.Anh = await SaveImage(taiKhoan.FileImage);
            }
            _context.TaiKhoans.Update(taiKhoan);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var taiKhoan = _context.TaiKhoans.Where(m => m.MaTaiKhoan == id).FirstOrDefault();
            if (taiKhoan == null) { return BadRequest(); }
            _context.TaiKhoans.Remove(taiKhoan);
          
            _context.SaveChanges();
            DeleteImage(taiKhoan.Anh);
            return Ok(taiKhoan);
        }
        [NonAction]
        private async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_env.ContentRootPath, "Images/TaiKhoan", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        [NonAction]
        private void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_env.ContentRootPath, "Images/TaiKhoan", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
        private string GennerateToken (TaiKhoan taiKhoan)
        {
            var stringRole = "";
            var Quyen = new List<Quyen>();
            var VaiTro1 = new List<ChiTietVaiTro>();

            var VaiTro = _context.CoVaiTros.Where(m => m.MaTaiKhoan == taiKhoan.MaTaiKhoan).ToList();

            foreach (var item in VaiTro)
            {
                VaiTro1 = _context.ChiTietVaiTros.Where(m => m.MaVaiTro == item.MaVaiTro).ToList();
            }
            foreach (var item in VaiTro1)
            {
                Quyen = _context.Quyens.Where(m => m.MaQuyen == item.MaQuyen).ToList();
            }
            foreach (var item in Quyen)
            {
                stringRole += item.TenQuyen + ",";
            }
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKet = Encoding.UTF8.GetBytes(_option.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, taiKhoan.HoTen),
                    new Claim("maTaiKhoan", taiKhoan.MaTaiKhoan),
                    new Claim("quyen",stringRole),

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKet),SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

    }
}
