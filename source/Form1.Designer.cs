namespace FacebookMessenger
{
	partial class FacebookBot
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookBot));
			this.WB_MainWindow = new System.Windows.Forms.WebBrowser();
			this.Timer_ScriptInsert = new System.Windows.Forms.Timer(this.components);
			this.Timer_Utility = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// WB_MainWindow
			// 
			this.WB_MainWindow.AllowWebBrowserDrop = false;
			this.WB_MainWindow.Location = new System.Drawing.Point(12, 12);
			this.WB_MainWindow.MinimumSize = new System.Drawing.Size(20, 20);
			this.WB_MainWindow.Name = "WB_MainWindow";
			this.WB_MainWindow.ScrollBarsEnabled = false;
			this.WB_MainWindow.Size = new System.Drawing.Size(1063, 613);
			this.WB_MainWindow.TabIndex = 0;
			this.WB_MainWindow.WebBrowserShortcutsEnabled = false;
			// 
			// Timer_ScriptInsert
			// 
			this.Timer_ScriptInsert.Interval = 1000;
			this.Timer_ScriptInsert.Tick += new System.EventHandler(this.ResetTimer_Tick);
			// 
			// Timer_Utility
			// 
			this.Timer_Utility.Enabled = true;
			this.Timer_Utility.Interval = 2000;
			this.Timer_Utility.Tick += new System.EventHandler(this.Timer_Utility_Tick);
			// 
			// FacebookBot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1087, 637);
			this.Controls.Add(this.WB_MainWindow);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FacebookBot";
			this.Text = "Facebook Messenger Groupchat Bot";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser WB_MainWindow;
		private System.Windows.Forms.Timer Timer_Utility;
		private System.Windows.Forms.Timer Timer_ScriptInsert;
	}
}

