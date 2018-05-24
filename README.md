# Entitas-Networking-and-Database-Example
This is a very basic example of an ECS Backend using Entitas, Forge Networking and MongoDB as Database service

To run the test project:
 1.  Go to Unitys build settings, check the MultiplayerMenu as first scene and the ClientTest as second scene, then build  the client.
2. Uncheck the ClientTest scene and check the TestServer scene and run it
3. Click on the button "(h) Host <IP-adress:Port"> on the bottom of the Multiplayer Menu Screen -> this starts the game server 
4. Start your Client build and connect...
5. In the Game Scene click Login User first...take note that a (given) Username, and (given) UserID gets sent to the Server and added as Component in the Gameentity with the specific NetworkID
6. Enter a Health value and press send to add or remove health...the GameEntity is getting destroyed if the Value of health is <=0
7. if Save Database flag is enables it saves the user and every change of health in a collection called "game" on the MongoDB server
8. For Database functionality you need a running MongoDB server on Port 27017 (standard MongoDB port), If your MongoDB server is running on a different port or IP, just setup in the MongoDBController
9. Check the Save Database flag of GameController in the TestServer scene 

To explain how it works:

Just focus on the MNB.cs script, thats the point where new Input Entities are getting created for incoming RPCs as well as new Game Enitites for new connected Players. An RPCInputEmitter system is redirecting the input to the game entities, who are reacting on RPCInput components...I use a [PrimaryEntityIndex] on the networkID component for easily selecting the right entities in the game context.

More infos about Entitas: https://github.com/sschmid/Entitas-CSharp/wiki

More infos about Forge Networking: https://github.com/BeardedManStudios/ForgeNetworkingRemastered

Official Forge Networking Documentation: http://docs.forgepowered.com/

Official MongoDB .NET Driver Documentation: http://mongodb.github.io/mongo-csharp-driver/2.6/

