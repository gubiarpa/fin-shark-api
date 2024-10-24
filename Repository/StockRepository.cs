using Microsoft.EntityFrameworkCore;
using net8_training.Data;
using net8_training.Helpers;
using net8_training.Interfaces;
using net8_training.Mappers;
using net8_training.Models;
using net8_training.Repository.Base;

namespace net8_training.Repository
{
    public class StockRepository : RepositoryBase, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks
                .Include(x => x.Comments)
                .ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
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
