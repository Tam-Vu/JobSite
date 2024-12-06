

<h1 align="center" style="font-weight: bold;">JobSite (Job search website)</h1>

<p align="center">
<a href="#architecture">Architecture and Design Pattern</a> -
<a href="#structure">Folder Structure</a> -
<a href="#libraries">Libraries</a> -
<a href="#started">Getting Started</a>
</p>


<p align="center">A job search website is an online platform that connects job seekers with employers. It is a useful tool that helps both parties save time and effort in the job search and recruitment process.</p>

<h2 id="architecture">📐Architecture and Design Pattern</h2>


- Clean Architecture:
<div align="center">
    <img src="https://github.com/user-attachments/assets/e7f2d901-ee45-4476-8823-22bb77f0917c" alt="clean_architecture">
</div>
 
- CQRS:

<div align="center">
	<img src="https://github.com/user-attachments/assets/839a4f60-48b9-4b23-a5e6-971612b7507c" alt="CQRS-Pattern">
</div>
<h2 id="structure">📂 Folder Structure</h2>

- Api
  - Is where endpoints are located. 
  - receives input data and passes commands or queries down to the `application` layer. 
- Contract:
  - Holds the input data within a request body. This data, along with parameters or query parameters, is formatted to comply with the input data requirements of the application layer.
  - Invoked by the `Api` layer.
- Application:
  - Common is a place to store configurations for validation, authorization, and logging actions. It also contains security interface (jwt service, identity,...), exceptions, mapping configurations, and return result definitions,...
  - Each entity is divided into 3 folders:
    - Commands folder: Contains 3 files: Command (specifies input data), Handler (processes logic), and Validator (validates input data).
    - Queries folder: Contains 3 files: Query (specifies input data), Handler (processes logic), and Response (defines output data).
    - Common folder: Contains commonly used data such as mappers for entities with input and output data.
  - IRepository folder: Declares interfaces that will be defined in the Infrastructure layer
  - Call the `Infrastructure` layer during data processing.
  - Called by `Api` folder.
- Infrastructure:
  - Common: 
	  - Is the place where common Interface defined.
	  - Contains application database context and database initialized.
  - Each entity has:
	- Configuration: file to define the relationship between two entities.
	- Repository: to define interface in the Irepository folder in Application layer.
	- Background Service(optional): to define background service for specific entities.
  - EntityFrameworkCore: contains interceptors and imgrations.
  - Called by `Application` layer.
- Domain:
  - Represents data structures used within the system.
  -  Can be called by the `Infrastructure` layer.

<h2 id="libraries">💻 Libraries</h2>

- MediatR
- EntityFrameworkCore
- FluentValidation
- Mapster
- FluentEmail
- Authentication.JwtBearer

<h2 id="started">🚀 Getting started</h2>

Here you describe how to run your project locally

<h3>Prerequisites</h3>

Here you list all prerequisites necessary for running your project. For example:

- [ASP.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/)

<h3>Cloning</h3>

How to clone project

```bash
git clone https://github.com/Tam-Vu/JobSite.git
```

<h3>Config .env variables</h2>

Use the `appsettings.Development.json` to create your configuration file 

```yaml
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "JwtSettings": {
    "Secret": "",
    "TokenExpirationInMinutes": ,
    "Issuer": "",
    "Audience": ""
  },
  "EmailSenderSettings": {
    "Server": "smtp.gmail.com",
    "Port": 587,
    "Username": "",
    "Password": "",
    "EnableSsl": true
  },
  "WebServer": {
    "Host": ""
  },
  "DatabaseConfiguration": {
    "ConnectionString": ""
  }
}
```

<h3>Starting</h3>

How to start your project

```bash
cd JobSite
dotnet restore
dotnet run --project src\JobSite.Api
```

