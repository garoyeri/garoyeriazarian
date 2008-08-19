using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StockSample.Data
{
	public class ModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void FirePropertyChanged(string propertyname)
		{
			if (this.PropertyChanged == null) return;

			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
		}
	}
}
