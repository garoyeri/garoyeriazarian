using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using StockSample.Data;
using StockSample.Core.Framework;

namespace StockSample.Start
{
	public class ApplicationController : IDisposable
	{
		ISynchronizeInvoke _affinity;
		bool _bStopUpdater = false;
		System.Threading.Thread _threadUpdater;
		
		List<AbstractPresenter> _presenters = new List<AbstractPresenter>();
		UpdatingStockProvider _stockprovider = new UpdatingStockProvider();

		public ApplicationController(ISynchronizeInvoke affinity)
		{
			_affinity = affinity;

			// start background stuff
			StartUpdatingThread();
		}

		private void StartUpdatingThread()
		{
			_threadUpdater = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
			_threadUpdater.IsBackground = true;
			_threadUpdater.Start();
		}

		private void ThreadProc()
		{
			while (!_bStopUpdater)
			{
				try
				{
					System.Threading.Thread.Sleep(10000);

					_affinity.BeginInvoke(new Action(_stockprovider.UpdatePrices), new object[0]);
				}
				catch (System.Threading.ThreadInterruptedException)
				{
					// interrupted, need to end the thread
					return;
				}
				catch (Exception except)
				{
					// TODO: log these sorts of exceptions
				}
			}
		}

		public Control LoadStockLister()
		{
			var ctrl = new StockSample.Core.Modules.StockLister.StockListerControl();

			var presenter = new StockSample.Core.Modules.StockLister.StockListerPresenter(
				_stockprovider, ctrl, _affinity);

			_presenters.Add(presenter);
			return ctrl;
		}

		#region IDisposable Members

		public void Dispose()
		{
			_bStopUpdater = true;
			if (_threadUpdater != null)
			{
				_threadUpdater.Interrupt();
				_threadUpdater.Join();
				_threadUpdater = null;
			}
		}

		#endregion
	}
}
