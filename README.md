# Restaurant Management System

A comprehensive web application built using ASP.NET Core MVC for managing restaurant operations including reservations, orders, menu, staff, and customer feedback.

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

## Prerequisites

- Visual Studio 2022 or later
- .NET 8.0 SDK
- SQL Server 2019 or later
- Node.js (for frontend package management)

## Setup Instructions

1. Clone the repository
```bash
git clone <repository-url>
```

2. Update database connection string in `appsettings.json`:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=RestaurantDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Apply database migrations:
```bash
dotnet ef database update
```

4. Run the application:
```bash
dotnet run
```

## Default Users

- Admin Account:
  - Username: admin
  - Password: admin123

- Test User Account:
  - Username: user1
  - Password: user123

## Project Structure

```
RestaurantSystem/
├── Controllers/           # MVC Controllers
├── Models/               # Data models
├── Views/                # Razor views
├── Data/                 # Database context
├── Enums/               # Enumeration types
├── wwwroot/             # Static files
└── Migrations/          # Database migrations
```

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

## Additional Setup Recommendations

1. **Branch Strategy**:
   - main: Production-ready code
   - develop: Development branch
   - feature/*: Feature branches
   - bugfix/*: Bug fix branches

2. **GitHub Repository Settings**:
   - Enable branch protection rules
   - Set up pull request templates
   - Configure GitHub Actions for CI/CD

3. **Documentation**:
   - Add API documentation
   - Include database schema diagrams
   - Document deployment procedures

4. **Security**:
   - Add security policies
   - Configure dependency scanning
   - Set up vulnerability alerts
  
## License

This project is licensed under the MIT License - see the LICENSE file for details
