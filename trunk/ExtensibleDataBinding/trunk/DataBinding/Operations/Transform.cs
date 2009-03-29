using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBinding.Extensions;

namespace DataBinding.Operations
{
	public class Transform<TFrom, TTo>
	{
		Source<TFrom> _source;
		Sink<TTo> _sink;
		Converter<TFrom, TTo> _converter;

		public Transform(Source<TFrom> source, Sink<TTo> sink, Converter<TFrom, TTo> converter)
		{
			_source = source;
			_sink = sink;
			_converter = converter;

			Bind();
		}

		void Bind()
		{
			_source.ValueChanged += new EventHandler(Source_ValueChanged);
			_sink.Value = _converter(_source.Value);
		}

		void Source_ValueChanged(object sender, EventArgs e)
		{
			_sink.Value = _converter(_source.Value);
		}

		public static TransformSourceClause<TFrom, TTo> From(Source<TFrom> source)
		{
			return new TransformSourceClause<TFrom, TTo>(source);
		}
	}
}
