using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataBinding.Tests
{
	class SampleBase : INotifyPropertyChanged
	{
		protected void FirePropertyChanged(string propname)
		{
			var propchanged = this.PropertyChanged;
			if (propchanged == null) return;

			propchanged(this, new PropertyChangedEventArgs(propname));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}


	class Sample1 : SampleBase
	{
		string _name, _description;

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

		public string Description
		{
			get { return _description; }
			set
			{
				if (this.Description == value) return;

				_description = value;
				FirePropertyChanged("Description");
			}
		}
	}
}
