# Movies Microservices Project

This repository contains a microservices-based project focused on secure authentication and authorization using IdentityServer4, with the implementation of an API Gateway pattern for enhanced security and modular architecture.

---

## Project Structure

### 1. **IdentityServer**
   - **Purpose**: Handles authentication and authorization.
   - **Technology**: Built with IdentityServer4 to issue JWT tokens and manage secure login/logout functionalities.

### 2. **Movies.API**
   - **Purpose**: Provides CRUD operations on movies.
   - **Authorization**: Access restricted based on authentication and authorization policies enforced by IdentityServer.

### 3. **ApiGateway**
   - **Purpose**: Acts as a gateway to the `Movies.API`, hiding direct access to it and securing communication.
   - **Security**: Validates JWT tokens and forwards them to `Movies.API`.

### 4. **Movies.Client**
   - **Purpose**: Frontend client that interacts with the `ApiGateway` for secure movie data management.
   - **Authentication**: Uses IdentityServer for secure login/logout functionality.

---

## Features

- **Authentication & Authorization**: Managed by IdentityServer4 with JWT tokens.
- **Microservices Architecture**: Independent, modular services for better scalability and maintainability.
- **API Gateway**: Centralized entry point to the system for enhanced security.
- **CRUD Operations**: Complete functionality to manage movie data securely.
- **Client Integration**: Seamless interaction with the backend services via `ApiGateway`.

---

## API Overview

### MoviesController Interface

This is the primary interface of the `Movies.API` project, which provides CRUD operations on movie data. All endpoints are secured using the `ClientIdPolicy` authorization policy.

#### Endpoints:

1. **GET** `/api/Movies`
   - Fetches all movies.

2. **GET** `/api/Movies/{id}`
   - Fetches a specific movie by its ID.

3. **POST** `/api/Movies`
   - Adds a new movie.

4. **PUT** `/api/Movies/{id}`
   - Updates an existing movie by its ID.

5. **DELETE** `/api/Movies/{id}`
   - Deletes a movie by its ID.

#### Authorization:
All endpoints require a valid JWT token issued by IdentityServer and are protected using the `[Authorize("ClientIdPolicy")]` attribute.

---

## Prerequisites

To run this project, ensure you have the following installed:

- .NET 5.0 SDK or later
- A code editor like Visual Studio or VS Code
- Postman or any API testing tool (optional)

---

## Getting Started

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/vasimsunni/SecureMicroserviceWithIdentityServer4.git
   cd SecureMicroserviceWithIdentityServer4
   ```

2. **Build and Run Services:**
   - Use Docker Compose to build and run the services.
   ```bash
   docker-compose up --build
   ```

3. **Access Services:**
   - **IdentityServer**: `http://localhost:5005`
   - **ApiGateway**: `http://localhost:5010`
   - **Movies.API**: `http://localhost:5012` (Accessible only through the ApiGateway).
   - **Movies.Client**: `http://localhost:5001`

4. **Testing the API:**
   - Use Postman or similar tools to test the `ApiGateway` endpoints.
   - Ensure you acquire a valid JWT token from IdentityServer before making requests.

---

## Technologies Used

- **Backend**: .NET 8.0, IdentityServer4, ASP.NET Core
- **Frontend**: ASP.NET Razor Pages (Movies.Client)
- **API Gateway**: Ocelot
- **Authentication**: JWT Token-based
- **Database**: Entity Framework Core with SQL Server

---

## Folder Structure

```
├── IdentityServer
│   ├── Controllers
│   ├── Configurations
│   └── Startup.cs
├── Movies.API
│   ├── Controllers
│   ├── Data
│   ├── Models
│   └── Startup.cs
├── ApiGateway
│   ├── ocelot.json
│   └── Startup.cs
├── Movies.Client
│   ├── wwwroot
│   ├── Controllers
│   ├── Views
│   └── Startup.cs
└── docker-compose.yml
```

---

## Contributions

Contributions are welcome! Please fork the repository and submit a pull request for review.

---

## Contact

For any queries, please contact:

- **Name**: Vasim Sunni
- **Email**: sunni.vasim@gmail.com
- **GitHub**: [vasimsunni](https://github.com/vasimsunni)

