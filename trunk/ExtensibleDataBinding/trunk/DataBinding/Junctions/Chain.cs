using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBinding.Junctions
{
	public class Chain
	{
		Dictionary<object, object> _junctions = new Dictionary<object, object>();

		public Junction<T> Link<T>(object id)
		{
			object value;
			if (_junctions.TryGetValue(id, out value))
			{
				Junction<T> junctionfound = value as Junction<T>;
				if (junctionfound != null) return junctionfound;

				throw new ArgumentException("chain link was of the wrong type", "id");
			}

			var junction = new Junction<T>();
			_junctions[id] = junction;
			return junction;
		}
	}
}
