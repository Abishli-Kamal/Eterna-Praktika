using Praktika_Template.Models;
using System.Collections.Generic;

namespace Praktika_Template.ViewModels
{
    public class ServisVM
    {
        public List<Cart> Carts { get; set; }
        public List<Contact> Contacts { get; set; }
        public Skill  Skills { get; set; } 
        public List<Statistica> Statisticas { get; set; }
    }
}
