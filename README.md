# Swagger Integration in Web API  
Swagger Integration in Asp.net Web API using Identity 

# Enable Cors 
To Enable cors 
PM> Install-Package Microsoft.AspNet.WebApi.Cors

# After Install go to WebApiConfig and add below line
config.EnableCors();

# For more info about web api refer this link https://docs.microsoft.com/en-us/aspnet/web-api/

# For Code First Data Migration
PM> enable-migrations (if you haven't already)
PM> add-migration [enter]
PM> nameYourMigration [enter]
(view the migration file to verify your properties are going to be added)
PM> update-database [enter]
Check your AspNetUsers db table to be sure the properties were added correctly

# For Role Based Authentication
http://johnatten.com/2014/10/26/asp-net-web-api-and-identity-2-0-customizing-identity-models-and-implementing-role-based-authorization/#Adding-Role-Based-Authorization-to-the-Web-Api-Application