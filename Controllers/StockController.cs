using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net8_training.Data;
using net8_training.Dtos.Stock;
using net8_training.Helpers;
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

            return Ok(stock.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stock = stockDto.ToModel();

            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock is null)
                return NotFound();

            stock.Update(stockDto);
            await _context.SaveChangesAsync();

            return Ok(stock.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock is null)
                return NotFound();

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
