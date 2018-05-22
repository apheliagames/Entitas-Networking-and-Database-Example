# Entitas-Networking-and-Database-Example
This is a very basic example of an ECS Backend using Entitas, Forge Networking and MongoDB as Database service

To run the test project:
 1.  Go to Unitys build settings, check the MultiplayerMenu as first scene and the ClientTest as second scene, then build  the client.
2. Uncheck the ClientTest scene and check the TestServer scene and run it
3. click on the bottom down button "Host" 
4. Start your Client build and connect...
5. For Database functionality you have to have a running MongoDB server, so if you don't, just uncheck the MongoDB Controller in the TestServer scene and remove the DatabaseSystem from the GameFeature
