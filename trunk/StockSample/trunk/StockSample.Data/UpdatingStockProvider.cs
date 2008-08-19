using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StockSample.Core.Data;

namespace StockSample.Data
{
	public class UpdatingStockProvider : ModelBase, IStockProvider
	{
		Random _random = new Random();
		StockModelList _stocks = new StockModelList();

		public UpdatingStockProvider()
		{
			CreateStockList();
		}

		private void CreateStockList()
		{
			_stocks.Add(new StockModel("GOOG", "Google Inc.", 510.15m));
			_stocks.Add(new StockModel("MSFT", "Microsoft Corporation", 27.80m));
			_stocks.Add(new StockModel("LUV", "Southwest Airlines Co.", 15.64m));
			_stocks.Add(new StockModel("DELL", "Dell Inc.", 25.06m));
			_stocks.Add(new StockModel("HPQ", "Hewlett-Packard Company", 45.59m));
			_stocks.Add(new StockModel("BHI", "Baker Hughes Incorporated", 77.76m));
			_stocks.Add(new StockModel("SLB", "Schlumberger Limited", 91.47m));
			_stocks.Add(new StockModel("HAL", "Halliburton Company", 43.61m));
			_stocks.Add(new StockModel("BJS", "BJ Services Company", 26.15m));
		}

		public void UpdatePrices()
		{
			foreach (StockModel stock in this.Stocks)
			{
				stock.CurrentPrice = GenerateNextPrice(stock.CurrentPrice);
				stock.LastUpdate = DateTime.UtcNow;
			}
		}

		private decimal GenerateNextPrice(decimal currentprice)
		{
			decimal offset = ((decimal)_random.Next(-1000, 1000)) / 100.0m;
			return currentprice + offset;
		}

		public IStockList Stocks
		{
			get { return _stocks; }
		}
	}
}
