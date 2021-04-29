using Microsoft.AspNetCore.Mvc;
using Space.Lion.Data;
using Space.Lion.Domain.Catalog;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;





namespace Space.Lion.Api.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;
        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State shirt.", "Nike", "/images/d1.jpg", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", "/images/d1.jpg", 44.99m)

            };

            return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {

            	var item = _db.Items.Find(id);
                if (item == null)
                {
                    return NotFound();
                    }
                    return Ok();
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            	_db.Items.Add(item);
                _db.SaveChanges();
                return Created($"/catalog/{item.Id}", item);

        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            if (_db.Items.Find(id) == null)
            {
                return NotFound();
            }

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }
    
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }
    }
}