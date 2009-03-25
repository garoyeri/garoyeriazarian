using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using DataBinding.Operations;

namespace DataBinding.Tests
{
	public class MapFacts
	{
		[Fact]
		public void can_map_simple_values()
		{
			var source = new InjectedSource<string>();
			var sink = new InjectedSink<string>();
			source.Value = "One";
			var map = new Map<string>(source, sink);

			source.Value = "Two";

			Assert.Equal("Two", sink.Value);
		}

		[Fact]
		public void can_map_simple_values_fluently()
		{
			var source = new InjectedSource<string>();
			var sink = new InjectedSink<string>();
			source.Value = "One";

			Map<string>
				.From(source)
				.To(sink);

			source.Value = "Two";

			Assert.Equal("Two", sink.Value);
		}
	}

	class InjectedSource<T> : Source<T>
	{
		T _value;

		public T Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value.Equals(this.Value)) return;

				_value = value;

				var changed = this.ValueChanged;
				if (changed == null) return;

				changed(this, EventArgs.Empty);
			}
		}

		public event EventHandler ValueChanged;
	}

	class InjectedSink<T> : Sink<T>
	{
		public T Value
		{
			get;
			set;
		}
	}
}
