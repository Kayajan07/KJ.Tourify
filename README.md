# KJ.Tourify

A web application for tour and travel companies, built with **ASP.NET Core MVC**. All site content (page texts, tours, cities, gallery, testimonials) can be managed through an admin panel.

## Features

**Public site**
- Home, About, Services, Guides and Contact pages
- Tour listing with filtering by city and number of guests
- Tour detail page with customer testimonials
- Visitors can leave testimonials with a profile photo
- Photo gallery organized by categories
- Booking page
- Contact form that sends email via SMTP

**Admin panel (`/Management`)**
- Cookie-based authentication
- Editing of all page contents
- Management of tours, cities, gallery categories, gallery items and testimonials (create / update / delete)
- Image uploads

## Tech Stack

- .NET 10, ASP.NET Core MVC
- Entity Framework Core 10 (SQL Server)
- Cookie Authentication
- Razor Views and View Components
- Bootstrap, jQuery, Owl Carousel, Lightbox

## Project Structure

```
KJ.Tourify.WebUI/
├── Areas/Management/   # Admin panel (controllers and views)
├── Controllers/        # Public pages
├── Models/
│   ├── Entities/       # Database tables
│   └── ViewModels/
├── Migrations/         # EF Core migrations
├── ViewComponents/
├── Utils/              # File upload and helper classes
├── Views/
└── wwwroot/            # CSS, JS, images and uploaded files
_db/                    # Helper SQL scripts
```

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express or LocalDB is enough)

### 1. Clone the repository
```bash
git clone https://github.com/Kayajan07/KJ.Tourify.git
cd KJ.Tourify/KJ.Tourify.WebUI
```

### 2. Configure settings
`appsettings.json` only contains placeholder values. Set your real connection string and SMTP credentials with **user-secrets** so they never end up in the repository:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.\SQLEXPRESS;Database=TourifyDb;Trusted_Connection=True;Encrypt=False;"
dotnet user-secrets set "Smtp:Host" "mail.yourdomain.com"
dotnet user-secrets set "Smtp:Port" "587"
dotnet user-secrets set "Smtp:Email" "contact@yourdomain.com"
dotnet user-secrets set "Smtp:Password" "YOUR_SMTP_PASSWORD"
```

On a server you can use environment variables instead (e.g. `ConnectionStrings__DefaultConnection`, `Smtp__Password`).

### 3. Create the database
```bash
dotnet tool install --global dotnet-ef   # if not installed
dotnet ef database update
```

### 4. Add an admin user
To sign in to the admin panel, insert a record into the `Users` table:

```sql
INSERT INTO Users (Id, Username, Password)
VALUES (NEWID(), 'admin', 'a-strong-password');
```

### 5. Run
```bash
dotnet run
```

- Site: `https://localhost:7066`
- Admin panel: `https://localhost:7066/Management`

## License

This project was developed for personal / portfolio purposes.
