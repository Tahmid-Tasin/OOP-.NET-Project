# 🏪 Departmental Store Management System

A desktop-based application built with **C# (Object-Oriented Programming 2)** that manages store operations like customers, products, orders, employees, branches, and inventory in one centralized system.  

This project was developed as part of **CSC2210: Object-Oriented Programming 2** (Summer 2024-25) at **AIUB**.

---

## 📌 Features

### 👤 Customer
- Create account & log in securely  
- Place product orders  
- Check product details before purchase  
- Review products  
- View purchase history  

### 🏢 Company Manager
- Manage branches  
- Add & update stock  
- View stock with filters (low stock alerts, availability, etc.)  
- Track order history & revenue analytics  

### 👨‍💻 Admin
- Manage products (add, edit, update)  
- Manage company managers & employees  
- Manage companies & their branches  
- Access analytics (monthly revenue, top-selling products, etc.)  

---

## 🗄 Database Design
- **Normalized up to 3NF** for efficiency and reduced redundancy  
- Entities include:
  - Customer
  - Product
  - Category
  - Company
  - Branch
  - Employee
  - Order & OrderLine
  - Review
  - Inventory
  - Admin  

### 🔗 Example Relationships
- Customer → Review (1:M)  
- Customer → Order History (1:M)  
- Order → Product (1:M)  
- Company → Employee (1:M)  
- Employee → Branch (1:M)  
- Branch → Inventory (1:M)  

---

## 📊 Sample Queries

- **Customer Login Verification**
```sql
SELECT 1 
FROM dbo.customer 
WHERE email = @Email AND password = @Password;
Monthly Revenue Trend

sql
Copy code
SELECT FORMAT(created_at, 'yyyy-MM') AS Month,
       SUM(quantity * unit_price) AS TotalRevenue
FROM dbo.order_history
GROUP BY FORMAT(created_at, 'yyyy-MM')
ORDER BY Month ASC;
Low Stock Alert

sql
Copy code
SELECT p.name AS ProductName, b.name AS BranchName, i.quantity
FROM dbo.inventory i
JOIN dbo.product p ON i.product_id = p.id
JOIN dbo.branch b ON i.branch_id = b.id
WHERE i.quantity < 10
ORDER BY i.quantity ASC;
🖼 Screenshots
Login page (Customer, Manager, Admin)

Customer product purchase & review pages

Manager stock management dashboard

Admin product & company management panels

👥 Team Members
Md. Mushtak Tahmid Tasin – ID: 23-52348-2

Adiba Nawar – ID: 23-54739-3

Tanjim Hossen Rakib – ID: 23-52308-2

Supervisor: Dr. Md. Iftekharul Mobin

⚙ Tech Stack
Language: C#

Framework: Windows Forms (GUI)

Database: SQL Server

Paradigm: Object-Oriented Programming (Encapsulation, Inheritance, Polymorphism)

📌 How to Run
Clone this repository:

bash
Copy code
git clone https://github.com/your-username/DepartmentalStoreManagementSystem.git
Open the project in Visual Studio.

Set up the database using the provided schema & queries.

Run the application.

🏆 Academic Outcome
This project demonstrates:

OOP principles in a real-world desktop application

Proper use of normalization & ERD for database integrity

GUI-based form validation and verification

Full workflow of a departmental store system with scalability
