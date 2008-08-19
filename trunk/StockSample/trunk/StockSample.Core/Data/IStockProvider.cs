using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSample.Core.Data
{
	public interface IStockProvider
	{
		IStockList Stocks { get; }
	}
}
