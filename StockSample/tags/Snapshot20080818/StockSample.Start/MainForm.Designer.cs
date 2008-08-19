namespace StockSample.Start
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.toolbar = new System.Windows.Forms.ToolStrip();
			this.dockpanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.SuspendLayout();
			// 
			// toolbar
			// 
			this.toolbar.Location = new System.Drawing.Point(0, 0);
			this.toolbar.Name = "toolbar";
			this.toolbar.Size = new System.Drawing.Size(466, 25);
			this.toolbar.TabIndex = 0;
			this.toolbar.Text = "toolStrip1";
			// 
			// dockpanel
			// 
			this.dockpanel.ActiveAutoHideContent = null;
			this.dockpanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockpanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
			this.dockpanel.Location = new System.Drawing.Point(0, 25);
			this.dockpanel.Name = "dockpanel";
			this.dockpanel.Size = new System.Drawing.Size(466, 406);
			this.dockpanel.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 431);
			this.Controls.Add(this.dockpanel);
			this.Controls.Add(this.toolbar);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolbar;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockpanel;
	}
}

