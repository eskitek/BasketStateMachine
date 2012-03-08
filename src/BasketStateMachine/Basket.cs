using System.Collections.Generic;
using BasketStateMachine.BasketStates;

namespace BasketStateMachine
{
	public class Basket : IBasket
	{
		private readonly IBasketStateFactory _basketStateFactory;

		public int Id { get; set; }
		public IList<BasketItem> Items { get; set; }
		public BasketState State { get; set; }

		public Basket()
			: this(new BasketStateFactory())
		{
		}

		public Basket(IBasketStateFactory basketStateFactory)
		{
			Items = new List<BasketItem>();
			State = BasketState.Empty;
			_basketStateFactory = basketStateFactory;
		}

		public virtual void AddItem(int itemId)
		{
			GetBasketState().AddItem(itemId);
		}

		public virtual void RemoveItem(int itemId)
		{
			GetBasketState().RemoveItem(itemId);
		}

		public virtual void CheckOut()
		{
			GetBasketState().CheckOut();
		}

		public virtual void Archive()
		{
			GetBasketState().Archive();
		}

		private BasketStateBase GetBasketState()
		{
			return _basketStateFactory.Create(this);
		}
	}

	public enum BasketState
	{
		Empty,
		ContainsStuff,
		CheckedOut,
		Archived,
		Unknown
	}
}
