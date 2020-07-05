# Description
This project is a simple a person store. There are two folders:
* **PersonStore** is a BE project (.NET Core C#) 
* **person-store** is a FE project (react, hooks)

Backend is using SQL Lite, which is included as a part of a project. There is no need to configure anything in order to run the application, no external data source is needed.

One can just open VS and click run (`IIS Express`) to run the backend, and run `npm run start` to run frontend. Backend has CORS enabled to allowed calls from FE.

On a backed following operations are exposed.
![alt text](https://github.com/sagasu/PersonStore/blob/master/SimpleOperations.png?raw=true)

On a fronted user is able to add and search for people.
![alt text](https://github.com/sagasu/PersonStore/blob/master/ListingAllPeopleWithCreationTime.png?raw=true)

Simple loading message and error handling is supported.
![alt text](https://github.com/sagasu/PersonStore/blob/master/ErrorHandlingAndLoading.png?raw=true)

# person-store FE
Currently FE is really simple. I feel like a form is already a good candidate to split into smaller files.

# PersonStore BE
1) I like to think as an API project (PersonStore) as an entry point, it should be as simple as possible.
2) I like to extract everything I can to a Service project (like DI config, automapper config, etc...).
3) Folders DTO and Data are good candidates to be extracted to a separate projects in a future. To save time and also because the scope of this work is so small I kept Data management responsibility (Repository/EF) and Service layer in this same project. Again if this solution would grow, I will extract it to a separate project.
4) I don't use transactions for a single insert operation. If I were to insert into multiple tables/data stores at this same time, I would wrap it in a transaction.

5) I don't see point in writing unit tests/integration/system tests in C# for entry point project (PersonStore).
6) I like unit testing guidelines from Roy book. This is what I try to follow.
7) StoreController exposes a method to create a Person table, in case if someone would like to drop provided SQL Lite database and create it from scratch.