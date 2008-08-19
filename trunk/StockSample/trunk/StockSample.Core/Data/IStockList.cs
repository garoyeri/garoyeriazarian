using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StockSample.Core.Data
{
	public interface IStockList : IBindingList
	{
		IStock CreateNew(string tickersymbol, string name);
		void Add(IStock stock);
		IStock FindByTickerSymbol(string tickersymbol);
		new IStock this[int index] { get; }
	}
}
