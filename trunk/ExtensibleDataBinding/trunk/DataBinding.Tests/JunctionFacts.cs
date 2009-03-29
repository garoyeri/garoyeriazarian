using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using DataBinding.Operations;
using DataBinding.Extensions;
using DataBinding.Junctions;

namespace DataBinding.Tests
{
	public class JunctionFacts
	{
		[Fact]
		public void can_pass_data_through()
		{
			var junction = new Junction<string>();
			junction.Value = "One";

			junction.Value = "Two";

			Assert.Equal("Two", junction.Value);
		}


		[Fact]
		public void can_fire_event_when_value_changed()
		{
			var junction = new Junction<string>();
			junction.Value = "One";
			bool fired = false;
			junction.ValueChanged += (sender, e) =>
				{
					fired = true;
				};

			junction.Value = "Two";

			Assert.True(fired);
		}
	}
}
