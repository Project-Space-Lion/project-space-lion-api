using Space.Lion.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Space.Lion.Domain.Orders;

namespace Space.Lion.Data
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options)
			: base(options)
		{ }

		public DbSet<Item> Items { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}