using System.Collections.Generic;

namespace BasketStateMachine
{
	public interface IBasket
	{
		int Id { get; set; }
		BasketState State { get; set; }
		IList<BasketItem> Items { get; set; }
		void AddItem(int itemId);
		void RemoveItem(int itemId);
		void CheckOut();
		void Archive();
	}
}