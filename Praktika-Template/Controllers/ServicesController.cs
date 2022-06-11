using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktika_Template.DAL;
using Praktika_Template.Models;
using Praktika_Template.ViewModels;
using System.Threading.Tasks;

namespace Praktika_Template.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ServisVM model = new ServisVM
            {
                Carts = await _context.Carts.ToListAsync(),
                Contacts = await _context.Contacts.ToListAsync(),
                Skills = await _context.Skills.FirstOrDefaultAsync(),
                Statisticas=await _context.Statics.ToListAsync()

            };
            return View(model);

        }
    }
}

