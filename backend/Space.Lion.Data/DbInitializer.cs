using Space.Lion.Domain.Catalog;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Space.Lion.Data
{
	public static class DbInitializer
	{
		public static void Initialize(StoreContext context, ILogger logger)
		{
			if (!context.Items.Any())
			{
				var items = new Item[]
				{
				new Item("T-Shirt", "Ohio State Block O", "Nike", 39.99m),
				new Item("Shorts", "Casual shorts", "Nike", 49.99m)
				};
				context.Items.AddRange(items);
				context.SaveChanges();
			}
		}
	}
}