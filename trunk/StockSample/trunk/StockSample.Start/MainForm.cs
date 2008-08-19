using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockSample.Start
{
	public partial class MainForm : Form
	{
		ApplicationController _controller;


		public MainForm()
		{
			InitializeComponent();

			_controller = new ApplicationController(this);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// add the known views
			AddView(_controller.LoadStockLister(), "Stocks");
		}


		protected void AddView(Control ctrl, string name)
		{
			WeifenLuo.WinFormsUI.Docking.DockContent content = new WeifenLuo.WinFormsUI.Docking.DockContent();
			content.Text = name;
			ctrl.Dock = DockStyle.Fill;
			content.Controls.Add(ctrl);

			content.Show(dockpanel);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_controller != null)
			{
				_controller.Dispose();
				_controller = null;
			}
		}
	}
}
