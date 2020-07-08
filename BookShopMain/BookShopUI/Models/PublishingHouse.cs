using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Models
{
    public class PublishingHouse : IPublishingHouse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime OpeningDate { get; set; }
    }
}
