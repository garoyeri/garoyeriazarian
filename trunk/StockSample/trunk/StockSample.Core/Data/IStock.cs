using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSample.Core.Data
{
	public interface IStock
	{
		string Name { get; }
		string TickerSymbol { get; }
		decimal CurrentPrice { get; }
		DateTime LastUpdate { get; }
	}
}
