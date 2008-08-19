using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using StockSample.Core.Framework;
using StockSample.Core.Data;

namespace StockSample.Core.Modules.StockLister
{
	public class StockListerPresenter : AbstractPresenter
	{
		IStockProvider _stockprovider;

		public StockListerPresenter(IStockProvider stockprovider,
			IStockListerView view, ISynchronizeInvoke affinity)
			: base(view, affinity)
		{
			_stockprovider = stockprovider;

			BindToView(_stockprovider, "Stocks", "Stocks");
		}
	}
}
