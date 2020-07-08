namespace BookShopUI.Models
{
    public interface IBook
    {
        int AuthorId { get; set; }
        string Description { get; set; }
        int id { get; set; }
        string Name { get; set; }
        int PublishingHouseId { get; set; }
    }
}