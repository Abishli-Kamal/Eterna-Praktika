using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktika_Template.DAL;
using Praktika_Template.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Praktika_Template.Areas.EternaAdmin.Controllers
{
    [Area("EternaAdmin")]
    public class CardController : Controller
    {
        private readonly AppDbContext _context;

        public CardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Card> card = await _context.Cards.ToListAsync();
            return View(card);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Card card)
        {

            await _context.AddAsync(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Card cards=await _context.Cards.FirstOrDefaultAsync(s=>s.Id==id);
            if (cards==null) return NotFound();
            return View(cards);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Card card=await _context.Cards.FirstOrDefaultAsync(s=>s.Id==id);
            if(card==null) return NotFound();
            return View(card);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit( Card card, int id)
        {
            Card existedcard=await _context.Cards.FirstOrDefaultAsync(s=>s.Id==id);
            if(existedcard==null) return NotFound();
            if(card.Id!=id) return BadRequest();

            existedcard.Title=card.Title;
            existedcard.Description=card.Description;
            existedcard.Icon=card.Icon;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            Card card= await _context.Cards.FirstOrDefaultAsync(s=>s.Id==id);
            if( card==null) return NotFound();
            return View(card);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteCard(int id)
        {
            Card card=await _context.Cards.FirstOrDefaultAsync(s=>s.Id==id);
            if(card==null) return NotFound();

             _context.Cards.Remove(card);
             await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
