using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding.Extensions
{
	public static class MapExtension
	{
		public static SinkClause<T> Map<T>(this Source<T> source)
		{
			var sinkclause = new SinkClause<T>(sink =>
				{
					DataBinding.Operations.Map<T>.From(source).To(sink);
				});
			return sinkclause;
		}
	}
}
