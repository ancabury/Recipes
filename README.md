The application's purpose is to practice SQL Queries.
There are 4 tables interconnected.

I`ve added 2 scripts (one for table creation and one to fill them with some data).
The main application is written in C#. It uses both ADO.NET Objects and DataReaders.


Problem statement:

Given a database with the following tables:

Categories (codC, nameC)
Food (codP, codC (FK), nameP, price, preparation_time)
Ingredients (codI, nameI, unit)
Recipes (codP (FK), codI (FK), quantity)

Create the above mentioned tables and insert data in the Categorii table. (SQL script)
Create a .NET application which can do the following:

- list the categories
- when selecting a category -> list the food in that category
- when selecting a food -> list it`s info and the recipe (ingredients with their names and quantities)
- add / update / delete for a food (if you delete a food, then it`s recipe is also deleted)
- list of ingredients, when selecting an ingredient list the unit and the food from which recipe it appears
- add / update / delete for an ingredient (don`t delete an ingredient if there are recipes which contains it)
- add / delete for ingredients for a food (update recipe)

Observations:

a) PK = underlined columns
b) FK = they keep the name from the columns they refer to
c) It is required to use: ADO.NET Objects, Connection, Command, DataReader, DataAdapter and DataSet.
