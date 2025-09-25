# ATM Management System

A **.NET 8.0** console application built using **C#** and **Entity Framework Core (Code-First)**  
to simulate a simple ATM environment where customers can perform transactions and
administrators can manage ATMs, customers, bank accounts, and cards.

---

## 📋 Project Overview
The ATM Management System demonstrates:
- **ATM Management** – track ATM locations and cash balances.
- **Customer & Bank Account Management** – store customer details and account balances.
- **Transactions** – deposit, withdraw, and log customer operations.
- **ATM Card Management** – issue cards and link customers to cards.
- Implementation of **CRUD** (Create, Read, Update, Delete) operations.

---

## 🎯 Objectives
- Build a functional database using Entity Framework Core (Code-First).
- Implement **One-to-One**, **One-to-Many**, and **Many-to-Many** relationships.
- Perform migrations to generate and update SQL Server tables.
- Verify and manage data using SQL Server Management Studio (SSMS).

---

## 🏗️ Technology Stack
| Component           | Details                       |
|---------------------|--------------------------------|
| Language            | C#                             |
| Framework           | .NET 8.0                        |
| ORM                 | Entity Framework Core          |
| Database            | SQL Server (LocalDB/Express)   |
| IDE                 | Visual Studio                  |

---

## 📂 Project Structure
DotnetProject/
├─ Controllers/              # API/Controller files (if used for routing or logic)
├─ Data/                      # DbContext and EF Core configuration
│   └─ AppDbContext.cs
├─ Models/                    # Entity classes (ATM, Customer, BankAccount, etc.)
├─ Properties/                # Project properties and launch settings
├─ bin/Debug/net8.0/          # Build output (should be ignored in .gitignore)
├─ obj/                        # Intermediate build files (should be ignored in .gitignore)
├─ DotnetProject.csproj        # Main project file
├─ DotnetProject.csproj.user   # User-specific settings
├─ DotnetProject.http          # HTTP request examples (if any)
├─ Program.cs                  # Entry point with CRUD operations
├─ WeatherForecast.cs          # Sample class/template
├─ appsettings.json            # Database connection & configuration
└─ appsettings.Development.json# Development-specific settings



---

## 🗄️ Database Design
Main entities and relationships:
- **ATM** – Location, CashBalance
- **Customer** – Name, Pin, AccountBalance
- **BankAccount** – One-to-One with Customer
- **Transaction** – One-to-Many with both ATM and Customer
- **ATMCard** – Many-to-Many with Customer (via CustomerATMCard)

---

## ⚡ Getting Started

### Prerequisites
- Visual Studio 2022 (or later)
- .NET 8.0 SDK
- SQL Server / LocalDB
- EF Core tools (`dotnet ef`)

### Setup & Run
1. Clone the repository:
   ```bash
   git clone https://github.com/Abhinaya-Ch02/ATM-Management-System.git
   cd ATM-Management-System/DotnetProject
