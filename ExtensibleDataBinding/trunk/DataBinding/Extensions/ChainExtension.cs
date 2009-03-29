using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBinding.Junctions;

namespace DataBinding.Extensions
{
	public static class ChainExtension
	{
		public static Source<T> Then<T>(this SinkClause<T> sinkclause)
		{
			var junction = new Junction<T>();
			sinkclause.To(junction);

			return junction;
		}
	}
}
