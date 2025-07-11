using AnaGirisPaneli.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AnaGirisPaneli.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(string Ad, string Sifre, string Mail, string Soyad)
        {
            var user = new Kullanici();
            user.Mail = Mail;
            user.Surname = Soyad;
            user.Password = SifreyiBase64le(Sifre);
            user.Name = Ad;

            var mail = _context.Kullanicilar.Where(x => x.Mail == Mail).FirstOrDefault();
            if (mail != null)
            {
                ViewBag.Hata = "Böyle bir kullanıcı zaten kayıtlı!";
                return View();
            }
            else
            {
            _context.Kullanicilar.Add(user);
            _context.SaveChanges();
            return RedirectToAction("GirisYap");
            }
        }

        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GirisYap(string Mail, string Sifre)
        {
            var kullanici1 = _context.Kullanicilar.FirstOrDefault(k => k.Mail == Mail);

            if (kullanici1 == null){ViewBag.Hata = "Böyle bir kullanıcı bulunamadı.";return View();}
            //var hashed = SifreyiBase64le(Sifre);

            if (kullanici1.Password != SifreyiBase64le(Sifre))
            {
                ViewBag.Hata = "Şifre hatalı.";
                return View();
            }
                
            // Giriş 
            return RedirectToAction("Welcome");

        }


        public IActionResult Welcome()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult welcome()
        //{

        //}
        public static string SifreyiBase64le(string Sifre)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Sifre);
            return Convert.ToBase64String(bytes);
        }
    }
}
    