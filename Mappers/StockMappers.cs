using net8_training.Dtos.Stock;
using net8_training.Models;

namespace net8_training.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                PurchasePrice = stockModel.PurchasePrice,
                LastDividend = stockModel.LastDividend,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }
    }
}