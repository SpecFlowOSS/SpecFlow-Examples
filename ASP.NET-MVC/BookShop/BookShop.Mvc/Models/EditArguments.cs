using System.ComponentModel.DataAnnotations;

namespace BookShop.Mvc.Models
{
    public class EditArguments
    {
        public int BookId { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}