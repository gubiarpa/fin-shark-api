using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net8_training.Data;
using net8_training.Mappers;

namespace net8_training.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _context.Stocks.Select(x => x.ToDto()).ToListAsync();

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
                return NotFound();

            return Ok(stock);
        }
    }
}