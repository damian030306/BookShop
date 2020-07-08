using System;

namespace BookShopUI.Models
{
    public interface IAuthor
    {
        DateTime DateOfBirth { get; set; }
        string FirstName { get; set; }
        int id { get; set; }
        string LastName { get; set; }
       // string Token { get; set; }
    }
}