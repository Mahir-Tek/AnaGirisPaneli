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
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(string Ad, string Sifre, string Mail, string Soyad)
        {
            var user = new Kullanici();
            user.KMail = Mail;
            user.Surname = Soyad;
            user.Password = Sifre;
            user.Name = Ad;

            var mail = _context.Kullanicilar.Where(x => x.KMail == Mail).FirstOrDefault();
            if(mail != null)
            {
                throw new Exception("Böyle bir kullanıcı zaten kayıtlı");
            }
            _context.Kullanicilar.Add(user);
            _context.SaveChanges();


            return RedirectToAction("GirisYap");
        }

        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GirisYap(string mail, string sifre)
        {
            var kullanici1 = _context.Kullanicilar.Where(k => k.KMail == mail && k.Password == sifre).FirstOrDefault();
            if(kullanici1 != null) { throw new Exception("Böyle Bir Kullanıcı Bulunamadı"); }
            return RedirectToAction("Welcome");

        }
        [HttpPost]
        public IActionResult KayitOl(Kullanici model)
        {
            // Kayıt işlemleri...
            return RedirectToAction("GirisYap");
        }


        public IActionResult welcome()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult welcome()
        //{
            
        //}
        
    }
}
