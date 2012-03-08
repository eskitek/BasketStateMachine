using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketStateMachine
{
	public class Basket_no_state_machine_example : IBasket
	{
		public int Id { get; set; }
		public IList<BasketItem> Items { get; set; }
		public BasketState State { get; set; }

		public Basket_no_state_machine_example()
		{
			Items = new List<BasketItem>();
			State = BasketState.Empty;
		}

		public virtual void AddItem(int itemId)
		{
			throw new NotImplementedException();
		}

		public virtual void RemoveItem(int itemId)
		{
			switch(State)
			{
				case BasketState.ContainsStuff:
				{
					var itemToRemove = Items.FirstOrDefault(item => item.Id == itemId);
					if (itemToRemove == null)
					{
						return;
					}

					Items.Remove(itemToRemove);

					if (Items.Count == 0)
					{
						State = BasketState.Empty;
					}
				}
					break;
				case BasketState.CheckedOut:
				{
					throw new InvalidOperationException("Can't remove an item from a basket that's been checked out.");
				}
				case BasketState.Empty:
				{
					throw new InvalidOperationException("Can't remove an item from an empty basket.");
				}
				case BasketState.Archived:
				{
					throw new InvalidOperationException("Can't remove an item from a basket that's been archived.");
				}
				default:
				{
					throw new InvalidOperationException("Unexpected Basket State");
				}
			}
		}

		public virtual void CheckOut()
		{
			throw new NotImplementedException();
		}

		public virtual void Archive()
		{
			throw new NotImplementedException();
		}
	}
}
