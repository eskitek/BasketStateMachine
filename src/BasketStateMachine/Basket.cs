using System.Collections.Generic;
using System.Linq;

namespace BasketStateMachine
{
    public interface IBasket
    {
        int Id { get; set; }
        BasketState State { get; set; }
        int ItemCount { get; }
        void AddItem(int itemId);
        void RemoveItem(int itemId);
        void CheckOut();
        void Archive();
    }

    public class Basket : IBasket
    {
        public int Id { get; set; }
        public IList<BasketItem> Items { get; set; }
        public BasketState State { get; set; }

        public virtual int ItemCount { get { return Items.Count; } }

        public Basket()
        {
            Items = new List<BasketItem>();
        }

        public virtual void AddItem(int itemId)
        {
            var item = new BasketItem { Id = itemId };
            Items.Add(item);
        }

        public virtual void RemoveItem(int itemId)
        {
            var itemToRemove = Items.FirstOrDefault(item => item.Id == itemId);

            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public virtual void CheckOut()
        {

        }

        public virtual void Archive()
        {
        }
    }

    public class BasketItem
    {
        public int Id { get; set; }
    }
}
