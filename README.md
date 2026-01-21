# 📚 BookManagement – ASP.NET Core MVC + ADO.NET CRUD

Учебен проект за курса **„Интернет програмиране“**,  
който демонстрира работа с база данни в уеб приложение чрез:

- ASP.NET Core MVC  
- ADO.NET (SqlConnection, SqlCommand)  
- Repository Pattern  
- Пълен CRUD (Create, Read, Update, Delete)

Проектът е предназначен за ученици от направление  
**„Приложно програмиране“**.

---

## ⚙️ Използвани технологии

- ASP.NET Core MVC  
- .NET 6 / .NET 7 / .NET 8  
- SQL Server  
- ADO.NET  
- NuGet пакет: **Microsoft.Data.SqlClient**

---

## 🗄️ Структура на базата данни

Създайте база:

Изпълнете SQL скрипта:

```sql
CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    Genre NVARCHAR(100) NOT NULL,
    Year INT NOT NULL
);

