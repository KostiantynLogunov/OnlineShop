# OnlineShop
This project implemets Microservices architecture.
Here we have such services:
### Authentication Service(IdentityServer)
>_Login/logout of users. Authentication of requests to services._
### -UserManagment Service
>_For managment user and roles: registration, adding client, editing, removing, binding clients with roles etc._
### -Order Service
>_Taking Orders, changing status of order, editing orders, statistics_
### -Goods Service
>_Managment of goods. Adding, editing, removing, statistics_
### -Application API
>_This's the interface for user. Users can't directly reach out any servicer. It's like middleware for services_ 

Also, we have UI part for logining users via their login and password.
And ofcourse tests

### For communicaton between different services we use Event Aggregator.
Services know nothing about each other. Here is communication by events via bus(Event Aggregator).
