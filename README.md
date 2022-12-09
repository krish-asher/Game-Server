# Multiplayer Game Server
This project allows multiple players to remotely connect into the same game lobby and play a game.  The server was hosted in unity for simplicity purposes.  This repository is divided into two parts: the PlayerUI/Scripts folder contains the project code for the player while the ServerSide/Scipts contains the 
project code for hosting the server. 

**Skills: C#, Unity, .NET, TCP/IP connections, UDP connections**

## Motivation
My goal initially when creating this game was to learn how to create a multiplayer.  After scouring the internet for a solution, I found that most third-party sites that I could use for a server required paid subscriptions.  Instead of paying for 
one of these services, I decided to make my own server.  What seemed like a simple project pretty soon turned into an intricate yet fruitful project.

## Server
This game is server-side which means that the server runs the real version of the game. This means
that if a player presses a certain button, then the action must be sent to the server and completed on the server.  The server
then sends back the completed action to the player where the action is render onto the player's screen. Unlike client-side servers, if one of the players is lagging all the other players don't experience the affects 
of the lag.

## Client
The client scripts control what the user sees.  When the player enters the server, they choose a server to join. Internally, Unity connects with the server and instantiates
the player using a player prefab.  As the player starts completing certain actions, Unity send this data to the server where this information is processed.
