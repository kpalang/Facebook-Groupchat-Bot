# Facebook Groupchat Bot
This is a little petproject of mine I thought is worth sharing since as far as I know Facebook has no official way for non-Workplace users to create bots in group chats 
The bot responds to commands sent in a group or direct chat, although latter is rather impractical.

## Usage
1. Create a Facebook user. Any account will work, but making a dedicated one is in my opinion more convenient.
2. Download the project
3. Run **_source.sln_** to try and configure the client.
4. Now go to `Form1_Load` method and edit the messenger url to your respective chat url.
```c#
private void Form1_Load(object sender, EventArgs e) {
    WB_MainWindow.ObjectForScripting = this;

    // Set Messenger chat thread URL
    WB_MainWindow.Navigate("https://www.messenger.com/t/xxxxxxxxxxxx");    

     WB_MainWindow.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(NavigationComplete);
}
```
5. Run your program and log in using the preferred account. **Be sure to tick _Keep me signed in in_**
![alt text][logging]
6. Basically your bot is ready. By default it reponds to command _!ping_ with _pong_. However you might want to have more functionality.
7. Find ProcessMessage method.
Parameter _message_ is the incoming message and _senderName_ is the name of the sender in format Firstname Lastname. Nicknames do not work here. The `if...then` first checks if bot isn't already processing a message and then if the sender isn't itself.
Commands can be added by adding `case`s and command prefix can be changed aswell.
Method `SendMessage()` currently sends only string type text. Images may come in the future.
```c#
public void ProcessMessage(string message, string senderName) {
    if (!isWorking && !senderName.Equals("Bot Master")) {				
        String[] args = message.Split();

        switch (args[0]) {
            case "!ping":
              SendMessage("pong");
              break;
    }
}
```
8. Now set up the bot to restart several times a day using Window's Task Scheduler. 
    * Create a batfile that will restart the application
    ```
    taskkill /F /IM FacebookMessenger.exe
    timeout /T 5
    start C:\path\to\FacebookMessenger.exe
    exit
    ```  
      This is needed because right now the JavaScript part is not optimised. For me 2 restarts a day is enough on a laptop with 4GB of RAM. 
      
    * Now create a Task Scheduler task that will run the batfile you created in previous step.
10. That should be it. Pretty much sky should be the limit now. Enjoy!

[logging]: https://i.imgur.com/LKPBmG9.png "Logging in"
[utility]: https://i.imgur.com/afnGJP9.png "Configuring utility.bat"
