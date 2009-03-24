using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding.Junctions
{
	public class PropertySink<T> : Sink<T>
	{
		object _obj;
		string _propname;
		Action<T> _setter;

		public PropertySink(object obj, string propertyname)
		{
			_obj = obj;
			_propname = propertyname;

			Bind();
		}

		void Bind()
		{
			var propsetter = _obj.GetType().GetProperty(_propname).GetSetMethod();
			_setter = (Action<T>)Delegate.CreateDelegate(typeof(Action<T>), _obj, propsetter);
		}

		public T Value
		{
			set
			{
				_setter(value);
			}
		}
	}
}
