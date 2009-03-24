using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using DataBinding.Junctions;

namespace DataBinding.Tests
{
	public class PropertySinkFacts
	{
		[Fact]
		public void can_set_sink_value()
		{
			var obj1 = new Sample1 { Name = "One" };
			var sink = new PropertySink<string>(obj1, "Name");

			sink.Value = "Two";

			Assert.Equal("Two", obj1.Name);
		}
	}
}
