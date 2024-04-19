# DotNetCoreMvcCrud

CRUD app with .net core mvc

## Tech stack

- .Net Core MVC (.net 8.0)
- Microsoft Sql Server
- Entity Framework Core

## How to run this Project?

- Open command prompt. Go to a directory where you want to clone this project. Use this command to clone the project.
  
  `git clone https://github.com/rd003/DotNetCoreMvcCrud`
  
- Go to the directory where you have cloned this project, open the directory `BookShoppingCart-Mvc`. You will find a file with name `BookShoppingCartMvc.sln`. Double click on this file and this project will be opened in Visual Studio.

- Open `appsettings.json` file and update connection string
  "ConnectionStrings": {
    "conn": "data source=your_server_name;initial catalog=MovieStoreMvc; integrated security=true;encrypt=false"
  }

- Delete Migrations folder

- Open `Tools > Package Manager > Package manager console`.
  
  Run these 2 commands
  
  ```
    (i) add-migration init
    (ii) update-database
  ```

- Now you can run this project

Thank's for ⭐ 😅
