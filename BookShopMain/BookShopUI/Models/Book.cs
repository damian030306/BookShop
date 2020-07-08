using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Models
{
    public class Book : IBook
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublishingHouseId { get; set; }
        public int AuthorId { get; set; }


    }
}
