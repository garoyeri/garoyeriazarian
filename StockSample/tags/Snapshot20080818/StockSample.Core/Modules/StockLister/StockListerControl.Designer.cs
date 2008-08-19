namespace StockSample.Core.Modules.StockLister
{
	partial class StockListerControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gridStocks = new System.Windows.Forms.DataGridView();
			this.iStockListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tickerSymbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastUpdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridStocks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.iStockListBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// gridStocks
			// 
			this.gridStocks.AllowUserToAddRows = false;
			this.gridStocks.AllowUserToDeleteRows = false;
			this.gridStocks.AllowUserToOrderColumns = true;
			this.gridStocks.AutoGenerateColumns = false;
			this.gridStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridStocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tickerSymbolDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.currentPriceDataGridViewTextBoxColumn,
            this.lastUpdateDataGridViewTextBoxColumn});
			this.gridStocks.DataSource = this.iStockListBindingSource;
			this.gridStocks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridStocks.Location = new System.Drawing.Point(0, 0);
			this.gridStocks.Name = "gridStocks";
			this.gridStocks.ReadOnly = true;
			this.gridStocks.Size = new System.Drawing.Size(445, 305);
			this.gridStocks.TabIndex = 0;
			// 
			// iStockListBindingSource
			// 
			this.iStockListBindingSource.DataSource = typeof(StockSample.Core.Data.IStockList);
			// 
			// tickerSymbolDataGridViewTextBoxColumn
			// 
			this.tickerSymbolDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.tickerSymbolDataGridViewTextBoxColumn.DataPropertyName = "TickerSymbol";
			this.tickerSymbolDataGridViewTextBoxColumn.HeaderText = "Ticker";
			this.tickerSymbolDataGridViewTextBoxColumn.Name = "tickerSymbolDataGridViewTextBoxColumn";
			this.tickerSymbolDataGridViewTextBoxColumn.ReadOnly = true;
			this.tickerSymbolDataGridViewTextBoxColumn.Width = 62;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// currentPriceDataGridViewTextBoxColumn
			// 
			this.currentPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.currentPriceDataGridViewTextBoxColumn.DataPropertyName = "CurrentPrice";
			this.currentPriceDataGridViewTextBoxColumn.HeaderText = "Price";
			this.currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
			this.currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
			this.currentPriceDataGridViewTextBoxColumn.Width = 56;
			// 
			// lastUpdateDataGridViewTextBoxColumn
			// 
			this.lastUpdateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.lastUpdateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdate";
			dataGridViewCellStyle1.Format = "G";
			dataGridViewCellStyle1.NullValue = null;
			this.lastUpdateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.lastUpdateDataGridViewTextBoxColumn.HeaderText = "Last Updated (UTC)";
			this.lastUpdateDataGridViewTextBoxColumn.Name = "lastUpdateDataGridViewTextBoxColumn";
			this.lastUpdateDataGridViewTextBoxColumn.ReadOnly = true;
			this.lastUpdateDataGridViewTextBoxColumn.Width = 116;
			// 
			// StockListerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridStocks);
			this.Name = "StockListerControl";
			this.Size = new System.Drawing.Size(445, 305);
			((System.ComponentModel.ISupportInitialize)(this.gridStocks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.iStockListBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridStocks;
		private System.Windows.Forms.BindingSource iStockListBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn tickerSymbolDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDataGridViewTextBoxColumn;
	}
}
