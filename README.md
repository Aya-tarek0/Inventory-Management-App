# 🗃️ Inventory Management System - ASP.NET Core

As part of my backend development training, I designed and implemented a modern **Inventory Management System** using **ASP.NET Core Web API**, with a focus on scalable architecture and enterprise-ready features.

---

## 🚀 Tech Stack & Concepts

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **CQRS** (Command Query Responsibility Segregation) – for better separation of concerns
- **Hangfire** – scheduled background jobs
- **JWT Authentication** – with role-based access control
- **SQL Server** – for data storage

---

## 🔐 Authentication & Authorization

- JWT-based token authentication
- Role-based access control (Admin, Manager, etc.)
- Restricted access to sensitive features (e.g., report generation, product deletion)

---

## 📦 Key Features

### 🧾 Product Management
- Create, update, retrieve, and delete products
- Input validation and data consistency

### 🔄 Inventory Transactions
- Add, remove, or transfer stock between locations
- All actions are logged for auditing

### 📊 Dynamic Reporting
- Low-stock reports
- Inventory and transaction history

### ⚙️ Background Jobs (via Hangfire)
- Automated low-stock alerts
- Periodic data archiving and cleanup

---

## 🧠 What I Learned

This project helped me deepen my understanding of:

- The **CQRS pattern** and how to separate command and query responsibilities
- **Background job scheduling** using Hangfire
- Secure **JWT authentication** and role-based authorization
- Building **scalable and maintainable** backend systems

---


