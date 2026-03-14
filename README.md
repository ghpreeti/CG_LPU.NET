# Student Management System

A **Student Management System** built using **ASP.NET MVC** that allows administrators to manage student records efficiently.  
The system includes authentication and CRUD operations for maintaining student data.

---

## Features

- Authentication and Login
- Add new students
- View all students
- Edit student details
- Delete student records
- Database integration using Entity Framework

---

## Project Structure

```
StudentManagementSystem
│
├── Controllers
│   └── Handles HTTP requests
│
├── Models
│   └── Contains student entity and DbContext
│
├── Views
│   └── Razor UI pages
│
├── wwwroot
│   └── Static files (CSS, JS, images)
│
└── Program.cs / Startup
    └── Application configuration
```

---

## Technologies Used

- ASP.NET MVC
- C#
- Entity Framework
- SQL Server
- Razor Views
- HTML / CSS / Bootstrap

---

## How to Run the Project

### 1. Clone the repository

```bash
git clone https://github.com/yourusername/StudentManagementSystem.git
```

### 2. Open the project

Open the solution file in **Visual Studio**

```
StudentManagementSystem.sln
```

### 3. Configure Database

Update the connection string in **appsettings.json**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=StudentDB;Trusted_Connection=True;"
}
```

### 4. Apply migrations

Run in Package Manager Console:

```bash
Update-Database
```

### 5. Run the application

Press **F5** in Visual Studio.

---

## Learning Objectives

This project demonstrates:

- ASP.NET MVC architecture
- Entity Framework integration
- Authentication implementation
- CRUD operations
- Database connectivity using DbContext

---

## Author

**Preeti**  
Engineering Student  
Learning **ASP.NET & Backend Development**

---

## Future Improvements

- Role-based authentication
- Search and filtering for students
- Pagination
- Improved UI design
