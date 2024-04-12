#Customer support system

- This project is a simple Customer Support System implemented using C#,
- ASP.NET Core, SQLite, and JavaScript. 
- It allows users to submit complaints, view submitted complaints, and mark complaints as solved.

#Neccessities to run
-[.NET SDK](https://dotnet.microsoft.com/download)
- A modern web browser.

## Installation

1. Clone or download the project repository to your local machine.
2. Open a terminal or command prompt and navigate to the project directory.
3. Run the following commands:

- dotnet restore
- dotnet build
- dotnet run

- Open a web browser http://localhost:5042

#Usage:
- Upon accessing the application, you will see a form where you can submit a complaint.
- Select the type of complaint from the dropdown menu and describe the issue in the text area.
- Click the "Submit" button to submit the complaint.
- Submitted complaints will be displayed in a table below the form.
- The table includes details such as complaint ID, appeal type, description, time of entry, and time to solve.
- You can mark a complaint as solved by clicking the "Complete" button in the table row.



#Files:
- program.cs: Contains the C# backend code for handling HTTP requests and interacting with the SQLite database.
- AgileDatabaseScript.sql: SQL script for creating the SQLite database schema and inserting initial data.
- agileworks.js: JavaScript file for handling client-side interactions such as form submission and table population.
- HTML file containing the form and table structure for the user interface.
