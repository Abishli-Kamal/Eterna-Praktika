using Microsoft.EntityFrameworkCore;
using Praktika_Template.DAL;
using Praktika_Template.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Praktika_Template.Services
{
    public class LayoutServis
    {
        private readonly AppDbContext _context;

        public LayoutServis(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetDatas()
        {
            List<Contact> contacts = await _context.Contacts.ToListAsync();
          
            return contacts;
        }
        public async Task<List<Statistica>> GetDataStatis()
        {
            List<Statistica> statisticas = await _context.Statics.ToListAsync();

            return statisticas;
        }
    }
}
