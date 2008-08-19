using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using StockSample.Core.Data;

namespace StockSample.Data
{
	public class StockModelList : ModelListBase<StockModel>, IStockList
	{

		#region IStockList Members

		public IStock CreateNew(string tickersymbol, string name)
		{
			return new StockModel(tickersymbol, name);
		}

		public void Add(IStock stock)
		{
			base.Add(new StockModel(stock));
		}

		public IStock FindByTickerSymbol(string tickersymbol)
		{
			throw new NotImplementedException();
		}

		public new IStock this[int index]
		{
			get { return base[index]; }
		}

		#endregion
	}
}
