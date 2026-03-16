# Product Management System API

A RESTful **Product Management System** built with **ASP.NET Core 8** demonstrating the use of **Data Transfer Objects (DTOs)** to separate API contracts from internal domain models.

## Features

* RESTful APIs for managing **Products, Categories, Orders, and Inventory**
* DTO hierarchy for clean API design:

  * `CreateProductDto`
  * `UpdateProductDto`
  * `ProductDetailDto`
  * `ProductSummaryDto`
  * `ProductFilterDto`
* **Entity Framework Core** with an in-memory database
* **AutoMapper** for object mapping
* **FluentValidation & Data Annotations** for request validation
* Filtering, sorting, and pagination support

## Project Structure

```
ProductManagementSystem
│
├── Controllers      # API endpoints
├── Entities         # Core domain models
├── DTOs             # Request and response models
├── Services         # Business logic
├── MappingProfiles  # AutoMapper configuration
└── Data             # DbContext and database setup
```

## Tech Stack

* ASP.NET Core 8
* C#
* Entity Framework Core
* AutoMapper
* FluentValidation

## Purpose

This project demonstrates **best practices for designing scalable APIs**, including DTO usage, clean architecture, and separation of concerns.

## Author

Developed as part of a **hands-on lab for learning DTO-based API design in ASP.NET Core**.
