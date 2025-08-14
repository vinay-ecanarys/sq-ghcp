# Restaurant Directory

A simple ASP.NET MVC application for managing a restaurant directory with full CRUD operations.

## Features

- View all restaurants in a card-based layout
- Add new restaurants with detailed information
- Edit existing restaurant details
- View detailed information for each restaurant
- Delete restaurants with confirmation
- Star-based rating system
- Responsive Bootstrap UI

## Project Structure

- **Models**: Restaurant entity and view models
- **Controllers**: HomeController and RestaurantController with CRUD operations
- **Services**: In-memory data service for restaurant management
- **Views**: Razor views for all CRUD operations

## Key Components

### Edit Functionality
The Edit action is implemented with both GET and POST methods:
- GET method retrieves the restaurant data and displays the edit form
- POST method validates and updates the restaurant information
- Includes proper model validation and error handling

### Restaurant Model
Includes validation attributes for:
- Required fields (Name, Address)
- String length limits
- Rating range validation (1-5 stars)

## Running the Application

1. Ensure you have .NET 8.0 SDK installed
2. Open the project in Visual Studio Code
3. Run `dotnet restore` to restore packages
4. Run `dotnet run` to start the application
5. Navigate to `https://localhost:5001` or `http://localhost:5000`

## Technologies Used

- ASP.NET Core MVC
- Entity Framework (In-Memory for demo)
- Bootstrap 5 for UI
- jQuery for client-side validation
