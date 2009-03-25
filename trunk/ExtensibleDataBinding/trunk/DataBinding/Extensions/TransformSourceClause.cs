using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataBinding.Operations;

namespace DataBinding.Extensions
{
	public class TransformSourceClause<TSource, TSink>
	{
		Source<TSource> _source;

		public TransformSourceClause(Source<TSource> source)
		{
			_source = source;
		}

		public TransformSinkClause<TSource, TSink> To(Sink<TSink> sink)
		{
			return new TransformSinkClause<TSource, TSink>(_source, sink);
		}
	}
}
