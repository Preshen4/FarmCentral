# Farm Central

Title: POE Part 2 ST10083954

NOTE : Famrer Login: username: johnwick password: password1 Employee Login: username: robertd password: password11 

Version: 1.0.0

Table of Contents: 
 A - Pre-Requisites.
 B - Description.
 C - Functionality 
 D - How to intall the project.
 E - How to use the project.
 F - Challenges.
 G - What I would like to Add.
 I - References.

A) Pre-Requisites

1) Visual Studio 2022
2) .Net Core 6
3) MudBlazor

B) Description: 

This repository contains a prototype web application developed using Visual Studio and C# to create a Farmers' Marketplace. 
The application provides functionalities for managing farmers and their associated products. It also includes user authentication,
two different user roles (farmer and employee), and various features to enhance usability and data accuracy.

C) Functionality: 

The prototype website offers the following functionality:

Database of Farmers: The website maintains a database of farmers along with their associated products.
User Roles: Two user roles are provided: farmer and employee. Each user role has specific permissions and access rights.
User Authentication: Farmers and employees must log into the website to access user-specific information and perform actions.
Add New Farmer: A logged-in employee can add a new farmer to the database, providing their details.
Add New Product: A logged-in farmer can add a new product to their profile in the database, including relevant information.
View Farmer's Products: A logged-in employee can view the list of all products ever supplied by a specific farmer.
Filter Products: A logged-in employee can filter the displayed list of products supplied by a specific farmer based on the date range or product type.

D) How to intall the project:

To set up the Farmers' Marketplace web application prototype, follow these steps:

1) Clone the repository to your local machine.
2) Open the project in Visual Studio.
3) Ensure that you have the necessary dependencies installed (such as .NET Framework, ASP.NET, and SQL Server).
4) Build the project to resolve any dependencies and compile the application.

E) How to use the project:

1) Click the run button in Visual Studio.

2) This will take you to the login screen. You have to either login with the Employee or Farmer details

3) Once you login you will be shown two options on the NavBar. Farmers will see Products and Product Type, Employees will see Farmer Details and Stock.

4) The user will have the option to either Add, Update or Delete certain values. 

F) Challenges:

1) Implementing the login feature was difficulty and I could not figure out how to use Identities so I decided to use a basic login with a Singleton class.

G) What I would like to add:

1) Better login feature 
2) Animations
3) Better looking login page

I) 
 
1) https://www.mudblazor.com/ Mudblazor components and how to implement them into the code
2) https://www.youtube.com/watch?v=kvnFWqer-OE&list=PLnEAYD8TqY3XDwrPf1_Yj0zr-eCCZjWEZ How to use the MudBlazor components
3) https://www.c-sharpcorner.com/article/repository-design-pattern-in-asp-net-mvc/ How to use Repository design pattern

