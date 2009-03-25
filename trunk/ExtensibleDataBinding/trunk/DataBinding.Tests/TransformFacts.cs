using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using DataBinding.Operations;

namespace DataBinding.Tests
{
	public class TransformFacts
	{
		[Fact]
		public void can_convert_from_int_to_string()
		{
			var source = new InjectedSource<int>();
			source.Value = 0;
			var sink = new InjectedSink<string>();
			var convert = new Transform<int, string>(
				source, sink, i => i.ToString());

			source.Value = 5;

			Assert.Equal(5.ToString(), sink.Value);
		}

		[Fact]
		public void can_convert_from_int_to_string_fluently()
		{
			var source = new InjectedSource<int>();
			source.Value = 0;
			var sink = new InjectedSink<string>();

			Transform<int, string>
				.From(source)
				.To(sink)
				.Using(i => i.ToString());

			source.Value = 5;

			Assert.Equal(5.ToString(), sink.Value);
		}
	}
}
