using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DataBinding.Junctions
{
	public class PropertySource<T> : Source<T>
	{
		INotifyPropertyChanged _obj;
		string _propname;
		Func<T> _getter;

		public PropertySource(INotifyPropertyChanged obj, string propertyname)
		{
			_obj = obj;
			_propname = propertyname;
			Bind();
		}

		void Bind()
		{
			var propgetter = _obj.GetType().GetProperty(_propname).GetGetMethod();
			_getter = (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), _obj, propgetter);
			_obj.PropertyChanged += new PropertyChangedEventHandler(Source_PropertyChanged);
		}

		void Source_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != _propname) return;

			var changed = this.ValueChanged;
			if (changed == null) return;

			changed(this, EventArgs.Empty);
		}

		public event EventHandler ValueChanged;

		public T Value
		{
			get { return _getter(); }
		}
	}
}
