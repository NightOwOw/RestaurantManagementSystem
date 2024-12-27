# Restaurant Management System

A comprehensive web application built using ASP.NET Core MVC for managing restaurant operations including reservations, orders, menu, staff, and customer feedback.

##GitHub Repository
https://github.com/NightOwOw/RestaurantManagementSystem

## Features

### Customer Management
- Table reservations with status tracking
- Online ordering system
- Customer feedback and ratings
- User authentication and profile management

### Staff Management
- Staff scheduling and leave management 
- Role-based access control (Admin/User)
- Staff performance tracking
- Department and position management

### Menu Management
- Digital menu with categories
- Item availability status
- Price and description management
- Image support for menu items

### Order Management
- Real-time order tracking
- Multiple payment methods support
- Order status updates
- Split bill functionality

### Feedback System
- Rating system for food and service
- Dish-specific feedback
- Customer reviews management
- Analytics and reporting

## Technologies Used

- **Backend**: ASP.NET Core MVC (.NET 8.0)
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core 9.0
- **Frontend**: Bootstrap 5, jQuery
- **Icons**: Bootstrap Icons

## Required Software & Tools
- Visual Studio 2022 (Community Edition or higher)
- .NET 8.0 SDK
- SQL Server 2019 Express or higher
- SQL Server Management Studio 19
- Git

## Required Libraries/Packages
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.0" />
```

## Frontend Libraries
- Bootstrap 5.1.3
- Bootstrap Icons 1.11.2
- jQuery
- Tailwind CSS

## Setup Instructions

1. Clone repository:
```bash
git clone https://github.com/NightOwOw/RestaurantManagementSystem
cd Project
```

2. Update Database Connection:
- Open `appsettings.json`
- Modify connection string with your SQL Server details:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER\\SQLEXPRESS;Database=RestaurantDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Apply Database Migrations:
- Open Package Manager Console in Visual Studio
- Run:
```bash
Update-Database
```

4. Configure Project:
- Open project in Visual Studio 2022
- Right-click solution → Restore NuGet Packages
- Build solution (Ctrl + Shift + B)

5. Run Application:
- Press F5 to run in debug mode, or
- Ctrl + F5 for non-debug mode

## Default Login Credentials

Administrator:
```
Username: admin
Password: admin123
```

Test User:
```
Username: user1
Password: user123
```

## Project Structure
```
RestaurantSystem/
├── Controllers/         # MVC Controllers
├── Models/             # Database Models
├── Views/              # Razor Views
│   ├── Admin/         # Admin Dashboard Views
│   ├── User/          # User Dashboard Views
│   └── Shared/        # Shared Layouts
├── Data/              # Database Context
└── wwwroot/          # Static Files
    ├── css/          # Stylesheets
    ├── js/           # JavaScript Files
    └── uploads/      # Uploaded Images
```

## Build Instructions
1. Open RestaurantSystem.sln in Visual Studio 2022
2. Select Build Configuration (Debug/Release)
3. Build → Build Solution or press Ctrl + Shift + B
4. Check Output window for build status

## Run Instructions
1. Set RestaurantSystem as Startup Project
2. Select IIS Express or RestaurantSystem profile
3. Press F5 to run with debugging
4. Access application at https://localhost:xxxx

## Troubleshooting
- If database connection fails:
  - Verify SQL Server is running
  - Check connection string in appsettings.json
  - Ensure database exists
- If build fails:
  - Clean solution and rebuild
  - Restore NuGet packages
  - Check Error List window for details

## Key Features Implementation

### Reservation System
- Automated table assignment
- Conflict prevention
- Email notifications
- Status tracking (Pending/Confirmed/Cancelled)

### Order Management
- Real-time order tracking
- Multiple payment methods
- Split bill functionality
- Order history

### Menu Management
- Category-based organization
- Image upload support
- Availability toggling
- Price management

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details
