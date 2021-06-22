"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notifications").build();


connection.on("ReceiveMessage", function (user, message) {

   // alert("task" + message + user);
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error("sendButton err"+err.toString());
});

document.getElementById("sendButton").addEventListener("click", async function (event) {

    await connection.invoke("SendMessage", "admin", "Paitent added").catch(function (err) {
        alert( " Paitent added");
        return console.error("SendMessage" + err.toString());
    });
});