using net8_training.Models;

namespace net8_training.Helpers
{
    public static class StockHelpers
    {
        public static void Update(this Stock stock, Stock stockDto)
        {
            stock.Symbol = stockDto.Symbol;
            stock.CompanyName = stockDto.CompanyName;
            stock.PurchasePrice = stockDto.PurchasePrice;
            stock.LastDividend = stockDto.LastDividend;
            stock.Industry = stockDto.Industry;
            stock.MarketCap = stockDto.MarketCap;
        }
    }
}
