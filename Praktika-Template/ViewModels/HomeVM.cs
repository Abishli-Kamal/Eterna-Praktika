using Praktika_Template.Models;
using System.Collections.Generic;

namespace Praktika_Template.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Card>  Cards { get; set; }
        public About Abouts { get; set; }
        public List<AboutInfo> AboutInfos { get; set; }
        public List<HomeCard> HomeCards { get; set; }
        public Client Clients { get; set; }
        public List<ClientImage> ClientImages { get; set; }
    }
}
