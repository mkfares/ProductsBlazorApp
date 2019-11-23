## Products Blazor Application

This application is an example of using Blazor Server side technology and the Entity Framework Core OR/M.

1. Using Visual Studio, create a Blazor server project, name your project ProductsBlazorApp.

2. Create a folder named Services in the root folder of your project. This folder will contain the services that interact with the database.

3. Create two folders named Product and Category under the Pages folder. These folders will contain the components related to each entity.

4. Install the following packages using the Package Manager Console

    ```PowerShell
    PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
    PM> Install-Package Microsoft.EntityFrameworkCore.Tools
    ```
    
5. Build the data model and the dbcontext

    - Create a database on the Localdb instance by executing the sql script in the file ProductsBlazorDatabase.sql
  
    - Generate the data model form the ProductsBlazorDatabase database using the command:
  
    ```PowerShell
    PM> Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=ProductBlazorDatabase;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -ContextDir Data -Context ProductDbContext -DataAnnotations -UseDatabaseNames -Force
    ```
    
6. Change the name of the application in the following files

    - Pages/_Host.cshtml

    - Shared/NavMenu.razor
    
7. Customize the following pages

    - Customize the Pages/index.razor home page
    
    - Customize the NotFound section in App.razor for page not found message 

8. Configure the connection string and the dbcontext

    - Add the connection string to the appsettings.json file
    
    - Add the dbcontext to services to the startup.cs file
    
    - Comment the whole method OnConfiguring() in the ProductDbContext.cs file

9. Create and configure the services

    - Create the classes/services ProductService and CategoryService in the Services folder
    
    - Register the services inside the method ConfigureServices() in Startup.cs file
    ```C#
    services.AddScoped<CategoryService>();
    services.AddScoped<ProductService>();
    ```

10. Add the following namespaces to the _Imports.razor file
    ```C#
    @using ProductsBalzorApp.Services
    @using ProductsBlazorApp.Data
    ```
    
11. Add the CRUD components for each entity, see Pages/Category and Pages/Product folder

12. Add a link to the Category/ListCategory.razor component in the /Shared/NavMenu.razor file
