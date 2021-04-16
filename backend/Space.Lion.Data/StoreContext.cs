using Space.Lion.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Space.Lion.Data
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options)
			: base(options)
		{ }

		public DbSet<Item> Items { get; set; }
	}
}