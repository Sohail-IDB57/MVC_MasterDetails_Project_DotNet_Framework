**MVC_MasterDetails_Project_DotNet_Framework**

#### Overview

This project is an ASP.NET MVC application designed to demonstrate a master-detail view pattern using the .NET Framework. It includes features like user authentication, data management, and a sample implementation of Entity Framework for database interactions.

#### Features

- **Master-Detail View**: Allows users to view a list of entities and their details.
- **Authentication**: Utilizes ASP.NET Identity for user management and authentication.
- **Entity Framework**: ORM framework used for database operations.
- **Bootstrap Integration**: For responsive and modern UI design.
- **Owin Middleware**: For authentication and other middleware functionalities.

#### Prerequisites

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework)
- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/)
- [SQL Server Express or LocalDB](https://docs.microsoft.com/en-us/sql/sql-server/editions-and-components/sql-server-express-edition)
- [NuGet Package Manager](https://www.nuget.org/)

#### Getting Started

1. **Clone the Repository**

  
   git clone https://github.com/Sohail-IDB57/MVC_MasterDetails_Project_DotNet_Framework.git
  

2. **Open the Project**

   Open the solution file `MVCProject_1280293.sln` in Visual Studio.

3. **Restore NuGet Packages**

   Right-click on the solution in Solution Explorer and select `Restore NuGet Packages`.

4. **Update Connection Strings**

   Ensure your `Web.config` file has the correct connection string for your local database:

   
   <connectionStrings>
     <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MVCProjectDB_1280293.mdf;Initial Catalog=MVCProjectDB_1280293;Integrated Security=True" providerName="System.Data.SqlClient" />
   </connectionStrings>
   

5. **Build and Run the Application**

   Build the project by pressing `Ctrl+Shift+B` and start debugging by pressing `F5`. The application will start using IIS Express and can be accessed at `https://localhost:44390/`.

#### Key Files

- **`Startup.cs`**: Configures OWIN middleware and authentication settings.
- **`Web.config`**: Contains application configuration including database connection strings and authentication settings.
- **`Controllers/`**: Contains the MVC controllers for handling requests and responses.
- **`Models/`**: Defines the data models and view models used in the application.
- **`Views/`**: Contains the Razor view files for the application's user interface.
- **`Migrations/`**: Includes Entity Framework migrations for database schema changes.

#### Authentication Configuration

- **Email**: `idbahmad18@gmail.com`
- **Password**: `uwws lsyo dogn xyiu`

These credentials are used for authentication in the application. Ensure to update these credentials before deploying the application in a production environment.

#### Troubleshooting

- **Missing NuGet Packages**: Run `Update-Package -reinstall` in the Package Manager Console.
- **Database Connection Issues**: Verify the connection string in `Web.config` and ensure that SQL Server is running.


#### License

This project is licensed under the [MIT License](LICENSE).

---

For more information on ASP.NET MVC and Entity Framework, refer to their respective [documentation](https://docs.microsoft.com/en-us/aspnet/mvc) and [guides](https://docs.microsoft.com/en-us/ef/).
