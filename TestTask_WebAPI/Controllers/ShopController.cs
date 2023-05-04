using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.DAL.Data;
using TestTask.DAL.Entities;

namespace TestTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopDbContext _db;
        private const string BAD_REQUEST_RESPONCE = "Not Found";

        public ShopController(ShopDbContext db)
        {
            _db = db;
        }

        [HttpGet("getBirthday")]
        public IActionResult GetBirthday(DateTime date)
        {
            var dbSet = _db.Set<Client>();

            var clients = dbSet
                .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day)
                .Select(r => new
                {
                    Id = r.Id,
                    Name = r.Name + " " + r.Surname + " " + r.MiddleName
                })
                .ToList();

            if (clients == null || !clients.Any())
            {
                return BadRequest(BAD_REQUEST_RESPONCE);
            }

            return Ok(clients);
        }
        
        [HttpGet("getSales")]
        public IActionResult GetLastSales(int days)
        {
            var dbSet = _db.Set<Sale>();

            var clients = dbSet
                .Where(s => s.SaleDate >= DateTime.Now.AddDays(-days))
                .Include(s => s.Client)
                .GroupBy(s => s.Client)
                .Select(r => new
                {
                    Id = r.Key.Id,
                    Name = r.Key.Name + " " + r.Key.Surname + " " + r.Key.MiddleName,
                    LastSaleDate = r.Max(s => s.SaleDate)
                })
                .ToList();

            if(clients == null || !clients.Any())
            {
                return BadRequest(BAD_REQUEST_RESPONCE);
            }

            return Ok(clients);
        }
        
        [HttpGet("getTopCategories")]
        public IActionResult GetTopCategories(int clientId)
        {
            var dbSet = _db.Set<Sale>();

            var categories = dbSet
                .Include(s => s.Client)
                .Include(s => s.Cart)
                .ThenInclude(c=>c.Product)
                .ThenInclude(p=>p.Category)
                .Where(s => s.Client.Id == clientId)
                .SelectMany(s => s.Cart)
                .GroupBy(c => c.Product.Category)
                .Select(g => new
                {
                    Category = g.Key.Name,
                    Count = g.Sum(cart => cart.ProductCount)
                })
                .ToList();

            if (categories == null || !categories.Any())
            {
                return BadRequest(BAD_REQUEST_RESPONCE);
            }

            return Ok(categories);

        }
    }
}
