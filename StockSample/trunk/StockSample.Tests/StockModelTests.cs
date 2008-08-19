using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace StockSample.Tests
{
	[TestFixture]
	public class StockModelTests
	{
		[Test]
		public void should_create_new_stock_model_with_properties()
		{
			var stock = new StockSample.Data.StockModel();
			stock.TickerSymbol = "GOOG";
			stock.Name = "Google";
			stock.CurrentPrice = 100.0m;
			stock.LastUpdate = new DateTime(2008, 3, 10, 9, 8, 50, 100, DateTimeKind.Utc);

			Assert.That(stock.TickerSymbol == "GOOG");
			Assert.That(stock.Name == "Google");
			Assert.That(stock.CurrentPrice == 100.0m);
			Assert.That(stock.LastUpdate == new DateTime(2008, 3, 10, 9, 8, 50, 100, DateTimeKind.Utc));
		}

		[Test]
		public void should_create_new_stock_model_with_constructor()
		{
			var stock = new StockSample.Data.StockModel("GOOG","Google");

			Assert.That(stock.TickerSymbol == "GOOG");
			Assert.That(stock.Name == "Google");
			Assert.That(stock.CurrentPrice == 0.0m);
		}

		[Test]
		public void should_compare_stocks_for_equality()
		{
			var stock1 = new StockSample.Data.StockModel() { Name = "Google", TickerSymbol = "GOOG" };
			var stock2 = new StockSample.Data.StockModel() { Name = "Microsoft", TickerSymbol = "MSFT" };
			var stock3 = new StockSample.Data.StockModel() { Name = "Google", TickerSymbol = "GOOG" };

			Assert.That(stock1.Equals(stock3));
			Assert.That(!stock1.Equals(stock2));
			Assert.That(!stock2.Equals(stock1));
			Assert.That(!stock2.Equals(stock3));
			Assert.That(stock3.Equals(stock1));
			Assert.That(!stock3.Equals(stock2));
		}

		[Test]
		public void should_get_list_of_stocks_from_provider()
		{
			StockSample.Core.Data.IStockProvider stockprovider = new SampleStockProviderModel();

			var stocks = stockprovider.Stocks;
			Assert.That(stocks.Count == 3);
			foreach (StockSample.Core.Data.IStock stock in stocks)
			{
				Assert.That(stock != null);
			}

			DateTime updatetimestamp = new DateTime(2008, 8, 10, 9, 36, 30, DateTimeKind.Utc);

			Assert.That(stocks.Contains(new StockSample.Data.StockModel()
				{ Name = "Google", TickerSymbol = "GOOG", CurrentPrice = 100.0m, LastUpdate =  updatetimestamp}));
			Assert.That(stocks.Contains(new StockSample.Data.StockModel()
				{ Name = "Microsoft", TickerSymbol = "MSFT", CurrentPrice = 90.0m, LastUpdate = updatetimestamp }));
			Assert.That(stocks.Contains(new StockSample.Data.StockModel()
				{ Name = "Southwest Airlines", TickerSymbol = "LUV", CurrentPrice = 120.0m, LastUpdate = updatetimestamp }));
		}

		[Test]
		public void should_fire_property_change_notifications()
		{
			string changedproperty = null;

			var stock = new StockSample.Data.StockModel("GOOG", "Google", 100.0m);
			stock.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(
				delegate(object sender, System.ComponentModel.PropertyChangedEventArgs e)
				{
					Assert.That(stock == sender);
					changedproperty = e.PropertyName;
				});

			changedproperty = null;
			stock.Name = "Microsoft";
			Assert.That(changedproperty == "Name");
			Assert.That(stock.Name == "Microsoft");

			changedproperty = null;
			stock.TickerSymbol = "MSFT";
			Assert.That(changedproperty == "TickerSymbol");
			Assert.That(stock.TickerSymbol == "MSFT");

			changedproperty = null;
			stock.CurrentPrice = 120.0m;
			Assert.That(changedproperty == "CurrentPrice");
			Assert.That(stock.CurrentPrice == 120.0m);

			changedproperty = null;
			stock.LastUpdate = new DateTime(2007, 8, 8, 8, 8, 8, DateTimeKind.Utc);
			Assert.That(changedproperty == "LastUpdate");
			Assert.That(stock.LastUpdate == new DateTime(2007, 8, 8, 8, 8, 8, DateTimeKind.Utc));

			// now make sure the property change is not fired if the property doesn't change
			changedproperty = null;
			stock.Name = "Microsoft";
			Assert.That(changedproperty == null);
			Assert.That(stock.Name == "Microsoft");

			changedproperty = null;
			stock.TickerSymbol = "MSFT";
			Assert.That(changedproperty == null);
			Assert.That(stock.TickerSymbol == "MSFT");

			changedproperty = null;
			stock.CurrentPrice = 120.0m;
			Assert.That(changedproperty == null);
			Assert.That(stock.CurrentPrice == 120.0m);

			changedproperty = null;
			stock.LastUpdate = new DateTime(2007, 8, 8, 8, 8, 8, DateTimeKind.Utc);
			Assert.That(changedproperty == null);
			Assert.That(stock.LastUpdate == new DateTime(2007, 8, 8, 8, 8, 8, DateTimeKind.Utc));			
		}
	}
}
