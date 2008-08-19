using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StockSample.Core.Data;

namespace StockSample.Core.Modules.StockLister
{
	public interface IStockListerView
	{
		IStockList Stocks { get; set; }
	}
}
