using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockSample.Core.Modules.StockLister
{
	public partial class StockListerControl : UserControl, IStockListerView
	{
		public StockListerControl()
		{
			InitializeComponent();
		}

		#region IStockListerView Members

		StockSample.Core.Data.IStockList _stocks;

		public StockSample.Core.Data.IStockList Stocks
		{
			get
			{
				return _stocks;
			}
			set
			{
				if (this.Stocks == value) return;

				_stocks = value;
				iStockListBindingSource.DataSource = _stocks;
			}
		}

		#endregion
	}
}
