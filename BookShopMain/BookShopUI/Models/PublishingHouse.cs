using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Models
{
    public class PublishingHouse : IPublishingHouse
    {
        public string Name { get; set; }
        public int CountBook { get; set; }
    }
}
