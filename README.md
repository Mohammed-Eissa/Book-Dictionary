# 📚 Book Dictionary

> A comprehensive book management system that allows users to organize their book collection, manage authors and genres, with a clean and responsive interface. Developed as part of ITI summer training graduation project.

##📖 About
Book Dictionary is a web-based application that combines book management features with dictionary functionality, allowing users to manage their book collections while providing quick access to word definitions and meanings.
---

## ✨ Features

🔹 **Book Management** - Add, edit, and delete books with ease  
🔹 **Author Management** - Comprehensive author database management  
🔹 **Genre Management** - Organize books by multiple genres  
🔹 **Responsive Design** - Clean, card-based UI using Bootstrap  
🔹 **Database Integration** - Robust data handling with Entity Framework Core  
🔹 **Advanced Relationships** - Many-to-many book-genre associations  

---

## 🛠️ Technologies Used

| Technology | Purpose |
|------------|---------|
| **ASP.NET Core MVC** | Web framework for building the application |
| **Entity Framework Core** | Object-Relational Mapping (ORM) for database access |
| **C#** | Primary programming language |
| **SQL Server** | Database management system |
| **Bootstrap** | CSS framework for responsive UI styling |
| **HTML & CSS** | Front-end structure and custom styling |
| **Razor Pages** | View engine for dynamic HTML generation |

---

## 🚀 Getting Started

### 📋 Prerequisites

Make sure you have the following installed:

- ✅ **.NET SDK** (Version 9.0 or higher)
- ✅ **SQL Server** (LocalDB or full version)
- ✅ **IDE** (Visual Studio or Visual Studio Code)

### 📥 Installation

**1. Clone the repository**
```bash
git clone https://github.com/Mohammed-Eissa/Book-Dictionary.git
```

**2. Navigate to project directory**
```bash
cd Book-Dictionary
```

**3. Configure database connection**

Open `appsettings.json` and update the connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BookDictionaryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**4. Apply database migrations**
```bash
dotnet ef database update
```

**5. Run the application**
```bash
dotnet run
```

🎉 **Success!** Your application will be available at `http://localhost:5294`

---

## 👨‍💻 Author

<div align="center">

**Mohammed Eissa**

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Mohammed-Eissa)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](#)
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](#)

</div>

---

## 🙏 Acknowledgments

- 🎓 **ITI (Information Technology Institute)** - For providing an excellent summer training program
- 👨‍🏫 **Instructors & Mentors** - For their invaluable guidance and support throughout the training
- 👥 **Fellow Trainees** - For their collaboration, knowledge sharing, and continuous support
- 💡 **Open Source Community** - For the amazing tools and resources that made this project possible

---

## 📞 Contact

<div align="center">

**Got questions? Suggestions? Let's connect!**

[![Email](https://img.shields.io/badge/📧_Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mohamedeissa615@gmail.com)
[![GitHub Issues](https://img.shields.io/badge/🐛_Issues-181717?style=for-the-badge&logo=github&logoColor=white)](github.com/Mohammed-Eissa/Book-Dictionary/issues)
[![LinkedIn](https://img.shields.io/badge/💼_LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](linkedin.com/in/mohamed-eissaa)

</div>