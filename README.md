# PersonStore BE
1) I like to think as an API project (PersonStore) as an entry point, it should be as simple as possible.
2) I like to extract everything I can to a Service project (like DI config, automapper config, etc...).
3) Folders DTO and Data are good candidates to be extracted to a separate projects in a future. To save time and also because the scope of this work is so small I kept Data management responsibility (Repository/EF) and Service layer in this same project. Again if this solution would grow, I will extract it to a separate project.
4) I don't use transactions for a single insert operation. If I were to insert into multiple tables/data stores at this same time, I would wrap it in a transaction.

5) I don't see point in writing unit tests/integration/system tests in C# for entry point project (PersonStore).
6) I like unit testing guidelines from Roy book. This is what I try to follow.
