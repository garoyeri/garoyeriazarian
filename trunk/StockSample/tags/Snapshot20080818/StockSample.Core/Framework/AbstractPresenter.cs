using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StockSample.Core.Framework
{
	public abstract class AbstractPresenter
	{
		ISynchronizeInvoke _affinity;
		object _view;

		private AbstractPresenter()
		{
		}

		public AbstractPresenter(object view, ISynchronizeInvoke affinity)
		{
			_view = view;
			_affinity = affinity;
		}


		protected void BindToView(object model, string modelproperty, string viewproperty)
		{
			SimpleBinding.Bind(model, modelproperty, _view, viewproperty, _affinity);
		}
	}
}
