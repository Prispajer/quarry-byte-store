# Projekt z przedmiotów:
1. **Projektowanie Wielowarstwowych Aplikacji Biznesowych**
2. **Aplikacyjny Projekt Zespołowy**
3. **Automatyzacja i Digitalizacja Procesów Biznesowych**

<div align="center">
  <img src="./public/icons/logo.png" alt="Logo" width="300" height="300" style="vertical-align: middle;"/>
  <h1 style="display: inline; vertical-align: middle;">QuarryByte - Store with Local Database</h1>
</div>

# Introduction
**QuarryByte** is a student project developed in collaboration with a group of peers under our university index numbers. The application is a modern game store built with **ASP.NET Blazor** and follows the **MVC architecture**, with a **SQL database** for managing game and user data.

# Key Features
The application includes a comprehensive set of features for users to enjoy a seamless experience:

## Store Features
- **Fully Responsive Design**: Optimized for devices of all sizes.
- **Cart Management**: Add, remove, and adjust the quantity of games in the cart with dynamic updates.
- **Local Cart Synchronization**: Automatically syncs items between local storage and the database, allowing users to maintain their cart across sessions.
- **Filtering and Sorting**: Filter and sort games or wishlist items by various criteria.
- **Dynamic URL Rendering**: Dynamically updates the URL based on filters and sorting, allowing users to bookmark and share filtered views.
- **State Management**: Blazor dispose functionality and initialization to manage application state and optimize performance.

## User Management
- **Registration and Login**: Secure account creation and login for users.
- **Password Reset**: *In progress* – A feature that will allow users to reset their password via email.
- **Email Verification**: *In progress* – Email verification to confirm user registration.
- **User Data Update**: *In progress* – Users will be able to update their personal data, such as name, email, and profile information.
- **Password Update**: *In progress* – Users will be able to change their password securely from their profile settings.

# Application Screenshots and Demo
- **Home Page**  
  ![Home Page](https://drive.usercontent.google.com/download?id=1ejrPTno7oWGaG5MHKo7fyWudodrNCxj9&export=view&authuser=0)
    
- **Game Page**  
  ![Game Page](https://drive.usercontent.google.com/download?id=1h9cAXMl8N9pZ_tdMW9gQMiHGz-HRmTCe&export=view&authuser=0)
  
- **Register Page**  
  ![Register Page](https://drive.usercontent.google.com/download?id=1Qx7hM4VF0NIo07pto44dPjVdR-1q6I27&export=view&authuser=0)
  
- **Login Page**  
  ![Login Page](https://drive.usercontent.google.com/download?id=1hO-oGJjK9lqUGzHNZ8CWwoaZPsQKxhVm&export=view&authuser=0)

- **Demo**
 <div align="center">
  *In progress*
</div>

# Application Tech Stack
  - C#
  - ASP.NET MVC
  - Blazor
  - Local SQL 
  - REST API

# # Installation Instructions:
1. **Download the project package from GitHub**
   - Download the entire project package from the GitHub repository to your local machine.

2. **Creating the local database in Visual Studio**
   - Open the project in Visual Studio.
   - In the **Solution Explorer**, find the **ECommerce.Server** project.
   - Right-click on the **Connected Services** folder and select the option to create a local database from the migrated files that are included in the project package.

3. **Check if NuGet packages are installed**
   - Make sure that all necessary NuGet packages are installed and added to the project. You can verify this in the **NuGet Package Manager** section.

4. **Run database migrations**
   - In the lower part of Visual Studio, go to **Developer PowerShell**.
   - Run the following commands to update the database:

     ```bash
     cd ECommerce
     cd Server
     dotnet ef database update
     ```

5. **Run the project**
   - Ensure that the **ECommerce.Server** project is set as the startup project.
   - Press **F5** or select the **Run** option in Visual Studio to start the entire project.

---

After completing these steps, the project should be running successfully in your local environment.

