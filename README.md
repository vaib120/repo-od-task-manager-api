# Task Management API  

Task Management API is a simple ASP.NET Core Web API application for managing tasks. This project demonstrates CRUD operations, database connectivity using Entity Framework Core with PostgreSQL, and containerization using Docker.  

---

## Features  
- Add, view, and delete tasks  
- PostgreSQL integration for data persistence  
- Dockerized backend for seamless deployment  

---

## Prerequisites  
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [PostgreSQL](https://www.postgresql.org/download/)  
- [Docker](https://www.docker.com/products/docker-desktop)  

---

## Setting Up the Project  

### 1. Replace PostgreSQL Connection String  
- Open `appsettings.json` in the project directory.  
- Replace the placeholder `Host=localhost;Database=taskdb;Username=yourusername;Password=yourpassword` with your actual PostgreSQL database connection string.  

### 2. Run Database Migrations  
To apply database migrations, run:  
```bash
dotnet ef database update
```
This will create the necessary tables in your PostgreSQL database.

---

## Running the Application
1. Using Docker
Build the Docker Image
Run the following command to build the Docker image:
```bash
docker build -t taskmanagementapi .
```

## Run the Docker Container
Start the container using:
```bash
docker run -d -p 8080:8080 --name taskmanagementapi taskmanagementapi
```
The API will be available at http://localhost:8080 or http://localhost:19551.

## API Endpoints

| Method | Endpoint          | Description           |
|--------|-------------------|-----------------------|
| GET    | `/api/tasks`      | Retrieve all tasks    |
| POST   | `/api/tasks`      | Add a new task        |
| DELETE | `/api/tasks/{id}` | Delete a task by ID   |

---


## Docker Configuration Details
1. Base Image: Uses the official .NET 8.0 runtime image for deployment.
2. Build Stage: Utilizes a multi-stage build process for smaller, optimized Docker images.
3. User: Runs the container as a non-root user (app) for enhanced security.
4. Port Exposure: Exposes port 8080 within the container, mapped to 8080 on the host machine.
5. Database Migration: Automatically applies database migrations during container startup.

---


## Development Notes
1. Ensure PostgreSQL is running and accessible before starting the application.
2. Check Docker logs for debugging if the container does not start correctly:

```bash
docker logs taskmanagementapi
```

---

## License
This project is open-source and available under the MIT License.

