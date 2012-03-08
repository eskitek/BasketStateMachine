using System.Linq;

namespace BasketStateMachine.BasketStates
{
	public class ContainsStuffState : BasketStateBase
	{
		public ContainsStuffState(IBasket basket)
			: base(basket)
		{
		}

		public override void AddItem(int itemId)
		{
			var item = new BasketItem { Id = itemId };
			_basket.Items.Add(item);
			_basket.State = BasketState.ContainsStuff;
		}

		public override void RemoveItem(int itemId)
		{
			var itemToRemove = _basket.Items.FirstOrDefault(item => item.Id == itemId);
			if (itemToRemove == null)
			{
				return;
			}

			_basket.Items.Remove(itemToRemove);

			if (_basket.Items.Count == 0)
			{
				_basket.State = BasketState.Empty;
			}
		}

		public override void CheckOut()
		{
			_basket.State = BasketState.CheckedOut;
		}

		public override void Archive()
		{
			_basket.State = BasketState.Archived;
		}
	}
}