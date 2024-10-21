using Microsoft.EntityFrameworkCore;
using net8_training.Data;
using net8_training.Helpers;
using net8_training.Interfaces;
using net8_training.Models;

namespace net8_training.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, Stock stock)
        {
            var existingStock = await _context.Stocks.FindAsync(id);

            if (existingStock is null)
                return null;

            existingStock.Update(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock is null)
                return null;

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }
    }
}
