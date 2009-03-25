using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBinding.Extensions;

namespace DataBinding.Operations
{
	public class Convert<TFrom, TTo>
	{
		Source<TFrom> _source;
		Sink<TTo> _sink;
		Converter<TFrom, TTo> _converter;

		public Convert(Source<TFrom> source, Sink<TTo> sink, Converter<TFrom, TTo> converter)
		{
			_source = source;
			_sink = sink;
			_converter = converter;

			Bind();
		}

		void Bind()
		{
			_source.ValueChanged += new EventHandler(Source_ValueChanged);
		}

		void Source_ValueChanged(object sender, EventArgs e)
		{
			_sink.Value = _converter(_source.Value);
		}

		public static ConvertSourceClause<TFrom, TTo> From(Source<TFrom> source)
		{
			return new ConvertSourceClause<TFrom, TTo>(source);
		}
	}
}
