using eshop.Services.DataTransferObjects.Response;

namespace eshop.MVC.Models
{
    public class CardItem
    {
        public ProductCardResponse Product { get; set; }
        public int Quantity { get; set; }
    }
    public class ShoppingCardCollection
    {
        public List<CardItem> CardItems { get; set; } = new List<CardItem>();
        public void Add(CardItem cardItem)
        {
            var existingItem = CardItems.Find(c => c.Product.Id == cardItem.Product.Id);
            if (existingItem == null)
            {
                CardItems.Add(cardItem);
            }
            else
            {
                existingItem.Quantity += cardItem.Quantity;
            }

        }

        public void Clear() => CardItems.Clear();
        public void Remove(CardItem cardItem) => CardItems.RemoveAll(c => c.Product.Id == cardItem.Product.Id);
        public decimal TotalPrice() => CardItems.Sum(c => c.Product.Price * c.Quantity);
        public int TotalCount { get => CardItems.Sum(c => c.Quantity); }


    }
}
