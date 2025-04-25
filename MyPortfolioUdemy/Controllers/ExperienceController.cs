using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioContext context;

        public ExperienceController(DbContextOptions<MyPortfolioContext> options)
        {
            context = new MyPortfolioContext(options);
        }
        public IActionResult ExperienceList()
        {
            var values = context.Experiences.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            context.Experiences.Add(experience);// Ekleme İşlemi
            context.SaveChanges();// Değişiklikleri Kaydet 
            return RedirectToAction("ExperienceList"); // Listeleme Sayfasına Yönlendir.
        }
        public IActionResult DeleteExperience(int id)
        {
            var value = context.Experiences.Find(id); // Silinecek Değer
            if (value != null)
            {
                context.Experiences.Remove(value); // Silme İşlemi
                context.SaveChanges(); // Değişiklikleri Kaydet
            }
            return RedirectToAction("ExperienceList");// Listeleme Sayfasına Yönlendir.
        }   

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = context.Experiences.Find(id);// Güncellenecek Değer
            return View(value);// Güncelleme Sayfasına Gönder
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            context.Experiences.Update(experience);// Güncelleme İşlemi
            context.SaveChanges();// Değişiklikleri Kaydet
            return RedirectToAction("ExperienceList");// Listeleme Sayfasına Yönlendir.
        }
    }
}
