I coded using .Net 6. I created only two projects. I thinks it's enough for this excercise and It's clean.
You can find an Auth folder with the context and the Authorization Service. There you'll find all the authentication functionality. I used OAuth JWT Token with Identity Server. There are two roles, regular and admin. You'll have to register an Admin user to be able to use the CRUD API.
I used TDD for the VehiclesProcessor class. This processor has CRUD functionalities. I've implemented unit tests using XUnit and MOQ library.
The business logic was created in a different datacontet to split the concerns.
There is a swagger tool to document all the API methods, but I couldn't manage to add the bearer token to the CRUD methods by using Swagger. So, I had to test it by using Postman. 
In the appsettings you'll find the Connection String. For testing purpose, you'll have to update it with your own server's settings.
There is some seed data in order to facilitate the testing.

The model has two tables, Vehicles and Plates. My idea is to create a new Vehicle by adding a Plate which is already created in the Database (there is no CRUD for Plates, that's why I added some seed data).
This vehicle table, has some properties like Color, Type (just as an example) and it is related with the Plate table.

By using the GET method you'll be able to list all the Vehicles with their plates.


I think this solution fits your requeriments.

Ps: I run out of time to add docker to this solution.

Regards