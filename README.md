# E-CommerceApi

## 📌 About the Project

**ECommerceApi** is a modular and layered e-commerce backend project built with **ASP.NET Core 9 Web API** using **N-tier architecture**.  
It includes essential features like user authentication, product management, and business logic separation through services, repositories, and entities.

---

##  Technologies Used

- ASP.NET Core 8 Web API
- Entity Framework Core
- Microsoft SQL Server
- AutoMapper
- Autofac (Dependency Injection)
- FluentValidation
- JWT Authentication


---

## 📁 Project Structure

- `ECommerce.Core` – Core interfaces and base entities
- `ECommerce.Entities` – DTOs and request/response models
- `ECommerce.DataAccess` – Repository implementations using EF Core
- `ECommerce.Business` – Business logic and service layer
- `ECommerce.WebAPI` – Controllers and API endpoints

---

## 🗃️ Database Schema

Below is a visual representation of the database schema used in this project.  
It includes the main tables such as `Users`, `Products`, `Orders`, and the relationships between them.



### 🖼️ Schema Preview

![Ekran görüntüsü 2025-06-22 203505](https://github.com/user-attachments/assets/b2424a1e-b2e3-4030-8fe3-bb01836b990b)


## How to Run Backend

1. **Requirements:**  
   - You must have .NET SDK installed (for example, .NET 6 or higher)  
   - MSSQL Server must be running  

2. **Setup Database:**  
   - Database will be created automatically by Entity Framework Code First when you run migrations  
   - Run migrations to create database and tables  

3. **Change Connection String:**  
   - Open the `DbContext` class in the `DataAccess` project  
   - Update the connection string directly inside the DbContext or constructor, for example:  
     ```
     Server=YOUR_SERVER;Database=ExpenseDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;
     ```

4. **Run Migrations:**  
   - Open terminal in backend project folder  
   - Run these commands to create and apply migrations:  
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

5. **Run Backend:**  
   - Run the backend API with:  
     ```bash
     dotnet run
     ```  
   - Backend will start

6. **Test API:**  
   - Use Postman or other tools to test API  
   - Or connect frontend to backend to check
