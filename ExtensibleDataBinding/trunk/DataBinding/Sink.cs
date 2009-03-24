using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding
{
	public interface Sink<T>
	{
		T Value { set; }
	}
}
