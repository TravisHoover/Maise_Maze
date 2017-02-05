/*#p/usr/bin/env node
"use strict";

var WebSocketServer = require('websocket').server;
var http = require('http');
var port = process.env.PORT || 5000;

var server = http.createServer(function(request, response) {
    console.log((new Date()) + ' Received request for ' + request.url);
    response.writeHead(404);
    response.end();
});

// player {
//     state: connected,
//     id: id,
//     position: [x,y,z]
// }

var connectedPlayers = [];
var clients = new Set();

server.listen(port, function() {
    console.log((new Date()) + ' Server is listening on port ' + port);
});

let wsServer = new WebSocketServer({
    httpServer: server,
    // You should not use autoAcceptConnections for production
    // applications, as it defeats all standard cross-origin protection
    // facilities built into the protocol and the browser.  You should
    // *always* verify the connection's origin and decide whether or not
    // to accept it.
    autoAcceptConnections: false
});

function originIsAllowed(origin) {
  // put logic here to detect whether the specified origin is allowed.
  return true;
}

wsServer.on('request', function(request) {
    if (!originIsAllowed(request.origin)) {
      // Make sure we only accept requests from an allowed origin
      request.reject();
      console.log((new Date()) + ' Connection from origin ' + request.origin + ' rejected.');
      return;
    }

    var connection = request.accept('', request.origin);
    console.log((new Date()) + ' Connection accepted.');
    clients.add(connection);

    connection.on('message', function(message) {
        if (message.type === 'utf8') {
            console.log('Received Message: ' + message.utf8Data);
            connection.sendUTF(message.utf8Data);
        }
        else if (message.type === 'binary') {
//             console.log('Received Binary Message of ' + message.binaryData.length + ' bytes');
//             // var msg = decode(message.binaryData);
// 	        console.log(message);
// //	for(var propName in message.binaryData) {
// //    		propValue = message.binaryData[propName]
// //		console.log(propName,propValue);
// //	}
//             console.log(message.binaryData.toString());
            try {
                var json = JSON.parse(message.binaryData.toString());
                console.log(json);

                //broadcast the message to all the clients
                for (let client of clients) {
                    //ignore the originator -- because that's awkward
                    if (client != connection) {
                        client.sendUTF(JSON.stringify(json));
                    }
                }
            } catch (Exception) {
                console.log("Hmm, failed, bad json.");
            }

            // console.log(message.asciiWrite());
            // connection.sendUTF("lawl");


        }
    });
    connection.on('close', function(reasonCode, description) {
        clients.delete(connection);
        console.log((new Date()) + ' Peer ' + connection.remoteAddress + ' disconnected.');
        console.log('Clients left: ' + clients.size);
    });
});
*/