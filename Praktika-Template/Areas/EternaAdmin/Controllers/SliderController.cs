using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktika_Template.DAL;
using Praktika_Template.FileUtilities;
using Praktika_Template.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Praktika_Template.Areas.EternaAdmin.Controllers
{
    [Area("EternaAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController( AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> slider= await _context.Sliders.ToListAsync();
            return View(slider);
        }
       
        public async Task<IActionResult> Detail(int id) {
            Slider sliders = await _context.Sliders.FirstOrDefaultAsync(s=>s.Id==id);
            if(sliders==null) return NotFound();
           
            return View(sliders);
        }

        public async Task<IActionResult> Create()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(Slider slider, int id)
        {
            if (!ModelState.IsValid) return View();
            if (slider.Photo!=null)
            {
                if (!slider.Photo.ContentType.Contains("image"))
                {
                    return View();
                }
                if (slider.Photo.Length > 1024 * 1024)
                {
                    return View();
                }   

            }
            slider.Image = await slider.Photo.FileCreate(_env.WebRootPath, @"assets/img");
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction (nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            Slider slider= await _context.Sliders.FirstOrDefaultAsync(s=>s.Id==id); 
            if(slider==null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(Slider slider, int id)
        {
            Slider existedslider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (existedslider == null) return NotFound();
            if (slider.Id != id) return BadRequest();
            existedslider.Title = slider.Title;
            existedslider.Description = slider.Description;
            existedslider.Photo = slider.Photo;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            Slider slider=await _context.Sliders.FirstOrDefaultAsync(s=>s.Id==id);
            if(slider==null) return NotFound();
            return  View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteSlider(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
