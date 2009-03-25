using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataBinding.Operations;

namespace DataBinding.Extensions
{
	public class ConvertSourceClause<TSource, TSink>
	{
		Source<TSource> _source;

		public ConvertSourceClause(Source<TSource> source)
		{
			_source = source;
		}

		public ConvertSinkClause<TSource, TSink> To(Sink<TSink> sink)
		{
			return new ConvertSinkClause<TSource, TSink>(_source, sink);
		}
	}
}
