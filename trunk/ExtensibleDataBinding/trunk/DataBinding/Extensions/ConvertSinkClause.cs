using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataBinding.Operations;

namespace DataBinding.Extensions
{
	public class ConvertSinkClause<TSource, TSink>
	{
		Source<TSource> _source;
		Sink<TSink> _sink;

		public ConvertSinkClause(Source<TSource> source, Sink<TSink> sink)
		{
			_source = source;
			_sink = sink;
		}

		public Convert<TSource, TSink> Using(Converter<TSource, TSink> converter)
		{
			return new Convert<TSource, TSink>(_source, _sink, converter);
		}
	}
}
