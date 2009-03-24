using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using DataBinding.Junctions;

namespace DataBinding.Tests
{
	public class PropertySourceFacts
	{
		[Fact]
		public void can_get_current_property_value()
		{
			var obj1 = new Sample1 { Name = "One" };
			var source = new PropertySource<string>(obj1, "Name");

			var found = source.Value;

			Assert.Equal("One", found);
		}

		[Fact]
		public void notify_when_value_changed()
		{
			var obj1 = new Sample1 { Name = "One" };
			var source = new PropertySource<string>(obj1, "Name");
			bool fired = false;
			source.ValueChanged += (sender, e) =>
				{
					fired = true;
				};

			obj1.Name = "Two";

			Assert.True(fired);
		}

		[Fact]
		public void dont_notify_when_other_property_changed()
		{
			var obj1 = new Sample1 { Name = "One", Description = "Something" };
			var source = new PropertySource<string>(obj1, "Name");
			bool fired = false;
			source.ValueChanged += (sender, e) =>
			{
				fired = true;
			};

			obj1.Description = "Something else";

			Assert.False(fired);
		}
	}
}
