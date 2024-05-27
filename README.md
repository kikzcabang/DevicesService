# DevicesService
Description: SignalR project that acts as intermediary between your webapp and desktop app.

If you are trying to implement a web application that can interface with your desktop application like for example: passport scanners, fingerprint scanners, signature sacnners and more that don't support web interfacing natively. You can use this DevicesService, this is a SignalR project that acts as intermediate between your web app and desktop app.

HOW TO USE

Web service SignalR:

1) Enable IIS
2) Install hosting bundle .Net {version}
3) Deploy this signalR project to the local machine or workstation where you run your desktop app.
4) Use the default website or http:80.
5) Add/Modify the appsettings.json to include your web application host to enable CORS.
6) For most cases you need to allow folder permission to your desktop user in order to write file to wwwroot folder.

Desktop App:

1) You need to adjust you desktop application to use signalR client to connect to this signalR service.
2) Your desktop application should write the output to the C:\inetpub\wwwroot\wwwroot\{specific folder}
3) It is recommended that you use a json, images (png,jpg) and/or any default browser supported formats.
4) We will use the default functionality of the wwwroot to serve your output files. It is like requesting a ccs files or js files from the server like https://webapp/{foldername}/picture.jpg
5) Then depending on your desktop app or console app. You need to run it so it can subscribe to the signalR events.

Web app:

1) Add signalR https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-8.0&tabs=visual-studio
2) Basically you need to configure your web app to connect to our Web service SignalR then subscribe to the events.
3) The workflow is
  WebApp > call signalR start method
  SignalR > notify client_DesktopApp to start method
  DesktopApp > start or do the desired functionality
  DesktopApp > call signalR complete method
  SignalR > notify client_WebApp to complete
  WebApp > retrieves the output using the default static wwwroot resource access:
    http://localhost/{folder}/file.{type} or http://localhost{folder}/picture.jpg
   http://localhost/{folder}/data.{type} or http://localhost{folder}/data.json
  WebApp > can now use the data or file whether to display or save it.
  


