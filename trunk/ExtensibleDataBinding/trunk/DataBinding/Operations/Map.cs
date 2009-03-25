using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBinding.Extensions;

namespace DataBinding.Operations
{
	public class Map<T>
	{
		Source<T> _source;
		Sink<T> _sink;

		public Map(Source<T> source, Sink<T> sink)
		{
			_source = source;
			_sink = sink;

			Bind();
		}

		void Bind()
		{
			_source.ValueChanged += new EventHandler(Source_ValueChanged);
			_sink.Value = _source.Value;
		}

		void Source_ValueChanged(object sender, EventArgs e)
		{
			_sink.Value = _source.Value;
		}


		public static MapSourceClause<T> From(Source<T> source)
		{
			return new MapSourceClause<T>(source);
		}
	}
}
