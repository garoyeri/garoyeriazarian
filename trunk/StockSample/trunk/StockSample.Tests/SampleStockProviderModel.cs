using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StockSample.Core.Data;
using StockSample.Data;

namespace StockSample.Tests
{
	public class SampleStockProviderModel : IStockProvider
	{
		StockModelList _stocks;

		public SampleStockProviderModel()
		{
			_stocks = new StockModelList();

			DateTime updatetimestamp = new DateTime(2008, 8, 10, 9, 36, 30, DateTimeKind.Utc);

			_stocks.Add(new StockSample.Data.StockModel("GOOG", "Google", 100.0m, updatetimestamp));
			_stocks.Add(new StockSample.Data.StockModel("MSFT", "Microsoft", 90.0m, updatetimestamp));
			_stocks.Add(new StockSample.Data.StockModel("LUV", "Southwest Airlines", 120.0m, updatetimestamp));
		}

		public IStockList Stocks
		{
			get { return _stocks; }
		}
	}
}
