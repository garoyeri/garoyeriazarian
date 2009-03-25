using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataBinding.Operations;

namespace DataBinding.Extensions
{
	public class MapSourceClause<T>
	{
		Source<T> _source;

		public MapSourceClause(Source<T> source)
		{
			_source = source;
		}

		public Map<T> To(Sink<T> sink)
		{
			return new Map<T>(_source, sink);
		}
	}
}
