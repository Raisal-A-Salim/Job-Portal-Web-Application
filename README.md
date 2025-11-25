# JobSiteApplication

A comprehensive ASP.NET MVC web application for managing job postings, companies, applications, and user accounts.

## Project Overview

JobSiteApplication is an enterprise-level job board platform built with ASP.NET MVC and Entity Framework. It provides functionality for job seekers to browse and apply for positions, and enables companies to post job listings and manage applications.

## Technology Stack

- **Framework**: ASP.NET MVC
- **ORM**: Entity Framework 6.2.0
- **Database**: SQL Server
- **Frontend**: 
  - HTML5/CSS3
  - JavaScript with jQuery 3.4.1
  - Bootstrap (via WebGrease)
  - Modernizr 2.8.3 for feature detection
- **Build Tools**: 
  - Roslyn C# compiler
  - Microsoft.CodeDom.Providers.DotNetCompilerPlatform

## Project Structure

```
JobSiteApplication/
├── App_Data/                    # Application data and database files
├── App_Start/                   # Configuration startup files
├── Controllers/                 # MVC Controllers
├── Content/                     # CSS and static assets
├── fonts/                       # Font files
├── Models/
│   ├── Application_Table.cs     # Job application entity
│   ├── Company_Table.cs         # Company entity
│   ├── Job_Table.cs             # Job posting entity
│   ├── Login_Table.cs           # Login/Authentication entity
│   ├── User_Table.cs            # User profile entity
│   ├── Model1.cs                # Entity Framework models
│   ├── Model1.Context.cs        # EF DbContext
│   └── Model1.edmx              # Entity Data Model
├── Views/                       # MVC Views (Razor templates)
├── Global.asax                  # Application startup file
├── Web.config                   # Configuration files
└── JobSiteApplication.csproj    # Project file
```

## Core Models

The application manages the following key entities:

- **User_Table.cs** - User accounts and profiles
- **Login_Table.cs** - Authentication and login information
- **Company_Table.cs** - Company profiles and information
- **Job_Table.cs** - Job listings and descriptions
- **Application_Table.cs** - Job applications submitted by users

## Key Features

- User authentication and account management
- Company registration and profile management
- Job posting creation and management
- Job application submission and tracking
- Responsive web interface with modern UI components

## Dependencies

Key NuGet packages included:

- EntityFramework 6.2.0
- EntityFramework.SqlServer
- ASP.NET MVC
- jQuery 3.4.1
- Modernizr 2.8.3
- Newtonsoft.Json
- WebGrease
- Antlr3.Runtime

## Configuration

Configuration files are managed through:

- **Web.config** - Base configuration
- **Web.Debug.config** - Debug-specific settings
- **Web.Release.config** - Release-specific settings

## Database

The application uses Entity Framework Code-First (or Database-First based on .edmx file) with SQL Server. The data models are defined in Model1.cs and the context in Model1.Context.cs.

## Build & Deployment

The project is built using Visual Studio 2019 (v16 based on .vs directory). 

**Build output**: 
- Binary: `/bin/JobSiteApplication.dll`
- Symbols: `/bin/JobSiteApplication.pdb`

## Getting Started

1. Clone the repository
2. Open `JobSiteApplication.sln` in Visual Studio
3. Restore NuGet packages
4. Update the database connection string in `Web.config`
5. Run migrations if needed via Package Manager Console
6. Build and run the application

## Development

- **IDE**: Visual Studio 2019+
- **Language**: C# (.NET Framework)
- **View Engine**: Razor

