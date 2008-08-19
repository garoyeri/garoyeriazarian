using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSample.Data
{
	public class StockModel : ModelBase, StockSample.Core.Data.IStock
	{
		public StockModel()
		{
		}

		public StockModel(StockSample.Core.Data.IStock stock)
		{
			this.TickerSymbol = stock.TickerSymbol;
			this.Name = stock.Name;
			this.CurrentPrice = stock.CurrentPrice;
			this.LastUpdate = stock.LastUpdate;
		}

		public StockModel(string tickersymbol, string name)
			: this(tickersymbol, name, 0.0m)
		{
		}

		public StockModel(string tickersymbol, string name, decimal currentprice)
			: this(tickersymbol, name, currentprice, DateTime.UtcNow)
		{
		}

		public StockModel(string tickersymbol, string name, decimal currentprice, DateTime lastupdate)
		{
			this.TickerSymbol = tickersymbol;
			this.Name = name;
			this.CurrentPrice = currentprice;
			this.LastUpdate = lastupdate;
		}

		string _name;
		string _tickersymbol;
		decimal _currentprice;
		DateTime _lastupdate;

		public string Name
		{
			get { return _name; }
			set
			{
				if (this.Name == value) return;

				_name = value;
				FirePropertyChanged("Name");
			}
		}

		public string TickerSymbol
		{
			get { return _tickersymbol; }
			set
			{
				if (this.TickerSymbol == value) return;

				_tickersymbol = value;
				FirePropertyChanged("TickerSymbol");
			}
		}

		public decimal CurrentPrice
		{
			get { return _currentprice; }
			set
			{
				if (this.CurrentPrice == value) return;

				_currentprice = value;
				FirePropertyChanged("CurrentPrice");
			}
		}

		public DateTime LastUpdate
		{
			get { return _lastupdate; }
			set
			{
				if (this.LastUpdate == value) return;

				_lastupdate = value;
				FirePropertyChanged("LastUpdate");
			}
		}

		public override string ToString()
		{
			return (this.TickerSymbol ?? "????") + " - " + (this.Name ?? "<no name>");
		}

		public override bool Equals(object obj)
		{
			StockModel other = obj as StockModel;
			if (other == null) return false;

			return this.Name == other.Name && this.TickerSymbol == other.TickerSymbol &&
				this.CurrentPrice == other.CurrentPrice && this.LastUpdate == other.LastUpdate;
		}

		public override int GetHashCode()
		{
			return this.TickerSymbol.GetHashCode();
		}
	}
}
