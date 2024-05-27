"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost/DevicesHub")
    .withAutomaticReconnect()
    .build();

connection.start().then(function () {

    var lbl = document.getElementById("lblStatus");
    lbl.innerText = "Devices Service Connected.";

}).catch(function (err) {
    var lbl = document.getElementById("lblStatus");
    lbl.innerText = err.toString();
    return console.error(err.toString());
});

connection.on("Client_CompleteSignatureScanning", async function () {
    debugger;
 
    const req = await fetch('http://localhost/signature/scan/data.json');
    const data = await req.json();
    var txt = document.getElementById("txtName");
    txt.value = data.Name;


});





document.getElementById("btnStart").addEventListener("click", function (event) {
    
    connection.invoke("StartSignatureScanning").catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});