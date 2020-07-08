using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Web_Api.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublishingHouseId { get; set; }
        [ForeignKey("PublishingHouseId")]
        public PublishingHouse PublishingHouse { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}