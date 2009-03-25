using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataBinding.Operations;

namespace DataBinding.Extensions
{
	public class TransformSinkClause<TSource, TSink>
	{
		Source<TSource> _source;
		Sink<TSink> _sink;

		public TransformSinkClause(Source<TSource> source, Sink<TSink> sink)
		{
			_source = source;
			_sink = sink;
		}

		public Transform<TSource, TSink> Using(Converter<TSource, TSink> converter)
		{
			return new Transform<TSource, TSink>(_source, _sink, converter);
		}
	}
}
