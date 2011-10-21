using System;

namespace BasketStateMachine
{
    public class ArchivedState : BasketStateNew
    {
        public const string ADD_ERROR_MESSAGE = "Can't add an item to a basket that's been archived.";
        public const string REMOVE_ERROR_MESSAGE = "Can't remove an item from a basket that's been archived.";
        public const string CHECKOUT_ERROR_MESSAGE = "Can't check out a basket that's been archived.";
        public const string ARCHIVE_ERROR_MESSAGE = "Can't archive out a basket that's already been archived.";

        public ArchivedState(IBasket basket)
            : base(basket)
        {
        }

        public override void AddItem(int itemId)
        {
            throw new InvalidOperationException(ADD_ERROR_MESSAGE);
        }

        public override void RemoveItem(int itemId)
        {
            throw new InvalidOperationException(REMOVE_ERROR_MESSAGE);
        }

        public override void CheckOut()
        {
            throw new InvalidOperationException(CHECKOUT_ERROR_MESSAGE);
        }

        public override void Archive()
        {
            throw new InvalidOperationException(ARCHIVE_ERROR_MESSAGE);
        }
    }
}