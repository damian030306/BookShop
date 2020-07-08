using System;

namespace BookShopUI.Models
{
    public interface IPublishingHouse
    {
        int id { get; set; }
        string Name { get; set; }
        DateTime OpeningDate { get; set; }
    }
}