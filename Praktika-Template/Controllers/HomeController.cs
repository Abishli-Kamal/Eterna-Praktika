using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktika_Template.DAL;
using Praktika_Template.ViewModels;
using System.Threading.Tasks;

namespace Praktika_Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController( AppDbContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Home()
        {
            HomeVM model = new HomeVM
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Cards=await _context.Cards.ToListAsync(),             
                Abouts =await _context.Abouts.FirstOrDefaultAsync(),
                AboutInfos=await _context.AboutInfos.ToListAsync(),
                HomeCards=await _context.HomeCards.ToListAsync(),
                Clients = await _context.Clients.FirstOrDefaultAsync(),
                ClientImages=await _context.ClientImages.ToListAsync(),

            };
            return View(model);
        }
    }
}
