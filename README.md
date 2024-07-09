# BookLibraryAPI

## Overview

BookLibraryAPI is a .NET 8-based RESTful API for managing books, authors, and genres in a library system. It uses SQLite as the database and Entity Framework Core for data access.

## Technology Stack

- **.NET 8**: The application is built using the latest .NET 8 framework, which provides improved performance and new features for modern applications.
- **SQLite**: A lightweight, file-based database used for data storage.
- **Entity Framework Core (EF Core)**: An ORM (Object-Relational Mapper) used to interact with the SQLite database.
- **AutoMapper**: A library used to map between domain models and DTOs (Data Transfer Objects).
- **Serilog**: A logging library for structured logging.
- **Swagger**: A tool for API documentation and testing.

## Features

- **Authors**:
  - **Get all authors**: Retrieve a list of all authors.
  - **Get author by ID**: Retrieve a specific author by their ID.
  - **Create author**: Add a new author to the system.
  - **Update author**: Modify an existing author by their ID.
  - **Delete author**: Remove an author by their ID.

- **Books**:
  - **Get all books**: Retrieve a list of all books.
  - **Get book by ID**: Retrieve a specific book by its ID.
  - **Create book**: Add a new book to the system.
  - **Update book**: Modify an existing book by its ID.
  - **Delete book**: Remove a book by its ID.

- **Genres**:
  - **Get all genres**: Retrieve a list of all genres.
  - **Get genre by ID**: Retrieve a specific genre by its ID.
  - **Create genre**: Add a new genre to the system.
  - **Update genre**: Modify an existing genre by its ID.
  - **Delete genre**: Remove a genre by its ID.

## Getting Started

### Running the Application

#### Using Command Line

1. **Navigate to the project directory**:
   ```bash
   cd BookLibraryAPI
   ```

2. **Restore the project dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

#### Using Visual Studio

1. **Open the project in Visual Studio**.

2. **Restore the project dependencies**:
   - Right-click on the solution in Solution Explorer and select `Restore NuGet Packages`.

3. **Start the application**:
   - Press `F5` or click on the `Start` button in Visual Studio to build and run the application.

### Database

- **Database File**: The SQLite database file is named `BookLibrary.db` and is located in the project directory. This file contains all the data for the application.

### Swagger Documentation

Swagger is integrated for API documentation and testing. It allows you to interact with the API endpoints directly from your browser.

- **URL**: `/swagger/index.html`
- **Features**:
  - Provides a web-based UI to explore and test API endpoints.
  - Displays detailed information about each API method, including parameters and responses.
  - Supports executing API calls and viewing responses directly within the Swagger UI.

### Logging

Logging is handled using Serilog. Logs are stored in the `Logs` directory with files named `log-YYYY-MM-DD.txt`. This allows for structured and detailed logging of application events.

- **Log Path**: `Logs/log-.txt`
- **Configuration**: The logging configuration is read from the `appsettings.json` file, allowing for flexible logging settings.
