using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding.Junctions
{
	public class Junction<T> : Source<T>, Sink<T>
	{
		T _value;

		public T Value
		{
			get { return _value; }
			set
			{
				_value = value;

				var changed = this.ValueChanged;
				if (changed == null) return;

				changed(this, EventArgs.Empty);
			}
		}

		public event EventHandler ValueChanged;
	}
}
