using System.Collections.Generic;

namespace BasketStateMachine
{
    public class Basket : IBasket
    {
        public int Id { get; set; }
        public IList<BasketItem> Items { get; set; }
        public BasketState State
        {
            get
            {
                if (SmartState is EmptyState)
                {
                    return BasketState.Empty;
                }
                if (SmartState is ContainsStuffState)
                {
                    return BasketState.ContainsStuff;
                }
                if (SmartState is CheckedOutState)
                {
                    return BasketState.CheckedOut;
                }
                if (SmartState is ArchivedState)
                {
                    return BasketState.Archived;
                }
                return BasketState.Unknown;
            }
            set
            {
                switch (value)
                {
                    case BasketState.Empty:
                        SmartState = new EmptyState(this);
                        break;
                    case BasketState.ContainsStuff:
                        SmartState = new ContainsStuffState(this);
                        break;
                    case BasketState.CheckedOut:
                        SmartState = new CheckedOutState(this);
                        break;
                    case BasketState.Archived:
                        SmartState = new ArchivedState(this);
                        break;
                }
            }
        }
        public virtual int ItemCount { get { return Items.Count; } }

        private BasketStateNew SmartState { get; set; }

        public Basket()
        {
            Items = new List<BasketItem>();
            SmartState = new EmptyState(this);
        }

        public virtual void AddItem(int itemId)
        {
            SmartState.AddItem(itemId);
        }

        public virtual void RemoveItem(int itemId)
        {
            SmartState.RemoveItem(itemId);
        }

        public virtual void CheckOut()
        {
            SmartState.CheckOut();
        }

        public virtual void Archive()
        {
            SmartState.Archive();
        }
    }

    public class BasketItem
    {
        public int Id { get; set; }
    }
}
