using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace FacebookMessenger
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	[System.Runtime.InteropServices.ComVisibleAttribute(true)]
	public partial class BotMain : Form
	{
		public bool isWorking = false;
		
		public BotMain() {
			InitializeComponent();
		}

		private void NavigationComplete(object sender, WebBrowserDocumentCompletedEventArgs e) {
			Timer_ScriptInsert.Start();
		}

		private void Form1_Load(object sender, EventArgs e) {			
			WB_MainWindow.ObjectForScripting = this;

			// Set Messenger chat thread URL ////////////////////////////////////////////////////////////////////
			WB_MainWindow.Navigate("https://www.messenger.com/t/xxxxxxxxxxxx");
			// //////////////////////////////////////////////////////////////////////////////////////////////////

			WB_MainWindow.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(NavigationComplete);			
		}

		/// <summary>
		/// Process incoming messages
		/// <param name="message">Message sent to group</param>
		/// <param name="senderName">Name of the sender in format: Firstname Lastname (NOT NICKNAME)</param>
		/// </summary>
		public void ProcessMessage(string message, string senderName) {
			if (!isWorking && !senderName.Equals("Bot Master")) {				
				String[] args = message.Split();

				switch (args[0]) {
					case "!ping":
						SendMessage("pong");
						break;
				}
			}
		}

		/// <summary>
		/// Send message to chat thread
		/// <param name="message">Message to send</param>
		/// </summary>
		private async void SendMessage(string message) {
			isWorking = true;
			//wb1.Document.Focus();

			Clipboard.Clear();

			Clipboard.SetText(message.Trim());
			WB_MainWindow.Document.ExecCommand("Paste", false, null);				

			await Sleep(100);
			foreach (HtmlElement el in WB_MainWindow.Document.GetElementsByTagName("a")) {
				if (el.GetAttribute("className").Equals("_30yy _38lh _39bl")) {
					el.InvokeMember("click");
					break;
				}
			}
			isWorking = false;
		}

		/// <summary>
		/// Sleep for given time
		/// <param name="mils">Sleepable time in milliseconds</param>
		/// </summary>
		async Task Sleep(int mils) {
			await Task.Delay(mils);
		}

		/// <summary>
		/// Waits util Messenger's main chat thread element exists and then inserts JavaScript
		/// </summary>
		private void ResetTimer_Tick(object sender, EventArgs e) {
			HtmlElement mainChatElement = WB_MainWindow.Document.GetElementById("js_1");

			if (mainChatElement != null) {
				Timer_ScriptInsert.Stop();
								
				HtmlElement documentHead = WB_MainWindow.Document.GetElementsByTagName("head")[0];
				HtmlElement scriptElement = WB_MainWindow.Document.CreateElement("script");
				scriptElement.SetAttribute("text", File.ReadAllText("messageListener.js"));
				documentHead.AppendChild(scriptElement);
				WB_MainWindow.Document.InvokeScript("setupListeners");
			}			
		}

		/// <summary>
		/// Check if Messenger's composer fails and messages can not be sent anymore. Runs every 2 seconds.
		/// </summary>
		private void Timer_Utility_Tick(object sender, EventArgs e) {
			string documentText = WB_MainWindow.DocumentText;
			string errorMsg = "<DIV class=\"_5jpt _4rv3 _2pen\">Could not display composer.</DIV>";

			if (documentText.Contains(errorMsg)) {
				Timer_Utility.Enabled = false;
				Application.Restart();
			}
		}
	}
}