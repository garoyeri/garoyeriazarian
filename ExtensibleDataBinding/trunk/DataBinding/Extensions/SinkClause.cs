using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding.Extensions
{
	public class SinkClause<T>
	{
		Action<Sink<T>> _completion;

		public SinkClause(Action<Sink<T>> completion)
		{
			_completion = completion;
		}

		public void To(Sink<T> sink)
		{
			_completion(sink);
		}
	}
}
