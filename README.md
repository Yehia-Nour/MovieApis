# 🎬 Movies API

The **Movies API** is a RESTful web service built with **ASP.NET Core** and **Entity Framework Core**. It allows users to manage movies and genres efficiently by providing a set of CRUD (Create, Read, Update, Delete) endpoints. This project follows best practices like the **Repository Pattern** and **Unit of Work** to maintain clean and scalable code architecture.


## 🛠️ Technologies Used
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- Repository Pattern
- Unit of Work Pattern

## 📄 API Endpoints

### 🎥 Movies Endpoints
- **GET** `/api/movies` - Get all movies  
- **GET** `/api/movies/{id}` - Get a movie by ID  
- **POST** `/api/movies` - Create a new movie  
- **PUT** `/api/movies/{id}` - Update a movie  
- **DELETE** `/api/movies/{id}` - Delete a movie  

### 📚 Genres Endpoints
- **GET** `/api/genres` - Get all genres  
- **POST** `/api/genres` - Create a new genre  
- **PUT** `/api/genres/{id}` - Update a genre  
- **DELETE** `/api/genres/{id}` - Delete a genre  


## 🛡️ Validation
- Validates image file types (`.jpg`, `.png`).
- Maximum allowed image size: **1MB**.

## 🛠️ Future Improvements
- Authentication and Authorization.
- Improved error handling and logging.
