# The GadgetHub API System

## Overview
The GadgetHub API System is a distributed RESTful application designed to connect customers with multiple product distributors through a centralized platform. The system collects quotations from different distributors, compares prices and delivery times, and selects the best option automatically.

The solution is built using ASP.NET Core Web APIs and SQL Server, following a clean layered architecture with controllers, services, repositories, and DTOs.

---

## System Architecture
The system consists of one central API (The GadgetHub API) and three distributor APIs:
- ElectroCom API
- TechWorld API
- GadgetCentral API

Each distributor manages its own database and inventory.

---

## Key Features
- Centralized product management
- Distributed quotation comparison
- Automatic best-price selection
- Stock reduction after order confirmation
- RESTful API communication
- Clean separation of concerns using DTOs and repositories

---

## APIs Included
- TheGadgetHubAPI
- ElectroComAPI
- TechWorldAPI
- GadgetCentralAPI

All distributor APIs follow the same structure and endpoints for consistency.

---

## Database Design
The system uses four separate databases:
- TheGadgetHubAPIDB
- ElectroComAPIDB
- TechWorldDB
- GadgetCentralAPIDB

Each distributor database stores its own product and stock data.

---

## Technologies Used
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server / LocalDB  
- RESTful Architecture  

---

## How to Run

1. Open the solution in Visual Studio.

2. Create the databases manually:
   - Open **SQL Server Object Explorer** in Visual Studio.
   - Expand `(localdb)\MSSQLLocalDB`.
   - Right-click → **Add New Database**.
   - Create the following databases:  
     - TheGadgetHubAPIDB  
     - ElectroComAPIDB  
     - TechWorldDB  
     - GadgetCentralAPIDB

3. Update the connection strings in each API project:
   - Right-click your database → **Properties** → copy the **Server name**.
   - In each API project, open `appsettings.json` → find the `"ConnectionStrings"` section.
   - Replace the existing connection string with your server name and the corresponding database name.

4. Run the migration commands in **Package Manager Console**:
   - `Add-Migration InitialCreate`
   - `Update-Database`

5. (Optional) Add the provided SQL product scripts to the `Products` tables for demonstration purposes.

6. Run each API project.

---

## Author
**Pasindu Himasha** – Aspiring Software Developer with an interest in web application development and system design.  

---

## License
This project is created for educational and portfolio purposes. You are free to explore, learn from, and improve the system.
