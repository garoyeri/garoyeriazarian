using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBinding.Operations;

namespace DataBinding.Extensions
{
	public static class TransformExtension
	{
		public static SinkClause<TTo> Transform<TFrom, TTo>(this Source<TFrom> source, Converter<TFrom, TTo> converter)
		{
			var sinkclause = new SinkClause<TTo>(sink =>
				{
					new Transform<TFrom, TTo>(source, sink, converter);
				});

			return sinkclause;
		}
	}
}
