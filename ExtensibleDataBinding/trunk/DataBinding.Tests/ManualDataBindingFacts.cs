using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using DataBinding.Junctions;
using DataBinding.Operations;

namespace DataBinding.Tests
{
	public class ManualDataBindingFacts
	{
		[Fact]
		public void can_set_up_simple_property_binding()
		{
			var obj1 = new Sample1 { Name = "One" };
			var obj2 = new Sample1 { Name = "Two" };
			Source<string> src = new PropertySource<string>(obj1, "Name");
			Sink<string> sink = new PropertySink<string>(obj2, "Name");
			var map = new Map<string>(src, sink);

			obj1.Name = "Three";

			Assert.Equal("Three", obj2.Name);
		}

		[Fact]
		public void can_set_up_simple_property_binding_fluently()
		{
			var obj1 = new Sample1 { Name = "One" };
			var obj2 = new Sample1 { Name = "Two" };

			Map<string>
				.From(new PropertySource<string>(obj1, "Name"))
				.To(new PropertySink<string>(obj2, "Name"));

			obj1.Name = "Three";

			Assert.Equal("Three", obj2.Name);
		}


		[Fact]
		public void can_chain_operations_with_junction()
		{
			var obj1 = new Sample1 { Name = "1" };
			var obj2 = new Sample1 { Name = "1" };
			var src = new PropertySource<string>(obj1, "Name");
			var sink = new PropertySink<string>(obj2, "Name");
			var junc1 = new Junction<int>();
			var junc2 = new Junction<string>();
			var convert1 = new Convert<string, int>(src, junc1, s => int.Parse(s));
			var convert2 = new Convert<int, string>(junc1, junc2, i => i.ToString());
			var map = new Map<string>(junc2, sink);

			obj1.Name = "2";

			Assert.Equal("2", obj2.Name);
		}
	}
}
