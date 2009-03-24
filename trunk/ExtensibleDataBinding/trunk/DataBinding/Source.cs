using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding
{
	public interface Source<T>
	{
		T Value { get; }
		event EventHandler ValueChanged;
	}
}
