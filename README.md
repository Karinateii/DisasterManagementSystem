# 🌍 Global Disaster Management System (GDMS)

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red.svg)](https://www.microsoft.com/sql-server)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED.svg)](https://www.docker.com/)

A comprehensive disaster management and emergency response platform supporting multiple disaster types (floods, earthquakes, fires, hurricanes, tsunamis). Built with ASP.NET Core 8.0, ML.NET, SignalR for real-time communications, and IoT sensor integration.

## 🎓 Project Background

This started as my 2023 Babcock University Computer Science final-year project, a flood management system for Lagos local government areas. In late 2025 I extended it into a multi-disaster platform, adding shelter management, IoT sensor monitoring, multi-channel alerts (SMS, USSD, WhatsApp, voice) and analytics.

**Original project:** Babcock University, Computer Science Final Year Project (2023)  
**Extended:** November 2025 to January 2026  
**Status:** In Development

---

## ✨ Key Features

### 🚨 Multi-Disaster Emergency Response
- **Multi-disaster support**: floods, earthquakes, fires, hurricanes, tsunamis, landslides
- **Real-time alerts**: SignalR-powered instant notifications
- **Incident reporting**: Citizen reports with photo uploads and GPS geolocation
- **Emergency shelter management**: Real-time capacity tracking, check-in/check-out system
- **Interactive dashboards**: Admin and citizen views with live data
- **Evacuation planning**: Dynamic route planning based on current conditions

### 📱 Multi-Channel Communication System
- **SMS Notifications** - Bulk SMS via Twilio for mass emergency alerts
- **USSD Gateway** - Feature phone support for offline/low-connectivity areas
- **WhatsApp Integration** - Rich media messages via Twilio Business API
- **Voice/IVR System** - Automated multilingual voice calls for critical alerts
- **Push Notifications** - Firebase Cloud Messaging for mobile apps
- **Multi-Language Support** - 8 languages: English, French, Arabic, Spanish, Portuguese, Hausa, Yoruba, Igbo

### 🌐 IoT Real-Time Monitoring
- **Water level sensors**: Live flood monitoring with threshold alerts
- **Rainfall tracking**: Intensity measurement and forecasting
- **Weather stations**: Temperature, humidity, wind speed, pressure
- **Real-time dashboards**: Chart.js visualizations with SignalR updates
- **Historical data**: Time-series analysis and trend detection
- **REST API**: Sensor data ingestion endpoints

### 🤖 Machine Learning & Predictions
- **ML.NET integration**: Fast Tree binary classifier for flood risk prediction
- **Historical analysis**: Pattern detection from past disaster data
- **Risk scoring**: Automated threat level assessment
- **Alert automation**: Threshold-based notifications
- **Weather forecasting**: Integration with external weather APIs

### 🏢 Shelter Management System
- **Shelter registration**: Comprehensive facility information
- **Capacity tracking**: Real-time occupancy monitoring
- **Check-in/Check-out**: Individual and family tracking
- **Occupant management**: View and manage current residents
- **Facility details**: Amenities, contact info, accessibility features
- **Geographic mapping**: Location-based shelter search

---

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: SQL Server 2022 with Entity Framework Core 8.0
- **Machine Learning**: ML.NET 3.0 (Fast Tree Classifier)
- **Real-time**: SignalR for live updates
- **Logging**: Serilog with file and console sinks
- **Authentication**: ASP.NET Core Identity with role-based authorization

### Communication Services
- **SMS/WhatsApp/Voice**: Twilio API integration
- **Push Notifications**: Firebase Cloud Messaging (FCM)
- **Email**: SMTP with MailKit

### Frontend
- **UI Framework**: Bootstrap 5.3
- **Charts**: Chart.js 4.4 for data visualization
- **Maps**: Leaflet.js for geographic features
- **Real-time Client**: SignalR JavaScript client
- **Icons**: Font Awesome 6

### DevOps & Testing
- **Containerization**: Docker & Docker Compose
- **CI/CD**: GitHub Actions
- **Testing**: xUnit for unit tests
- **API Documentation**: Swagger/OpenAPI 3.0

---

## 📊 Current Implementation Status

### ✅ Completed Features
- Core disaster management system (multiple disaster types)
- User authentication and authorization (admin/citizen roles)
- Incident reporting with photo upload and GPS
- Emergency shelter management with check-in/check-out
- SMS notification system via Twilio
- USSD interactive menus
- WhatsApp Business API integration
- Voice/IVR system with multilingual support
- Push notification infrastructure (Firebase)
- IoT sensor monitoring (water level, rainfall, weather)
- Real-time dashboards with SignalR
- Multi-language support (8 languages)
- ML-based flood prediction system
- REST API with Swagger documentation
- Admin dashboard with analytics

### 🚧 In Progress
- Mobile applications (iOS/Android)
- Advanced analytics dashboard
- Evacuation route optimization
- Extended ML model training

### 📅 Planned
- Community engagement features
- Volunteer coordination system
- Resource allocation optimization
- Integration with government emergency systems

---

## 🚀 Quick Start

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server 2022](https://www.microsoft.com/sql-server) or SQL Server Express
- [Node.js](https://nodejs.org/) (for frontend tools, optional)
- IDE: Visual Studio 2022, VS Code, or Rider

### Local Development Setup

```bash
# 1. Clone the repository
git clone https://github.com/Karinateii/FloodManagementSystem.git
cd FloodManagementSystem

# 2. Update database connection string in appsettings.json
# Edit: FloodManagementSystem/appsettings.json
# Update: ConnectionStrings:DefaultConnection

# 3. Configure external services (optional but recommended)
# Update appsettings.json with your keys:
#   - Twilio (SMS/WhatsApp/Voice)
#   - Firebase (Push notifications)
#   - SMTP (Email)

# 4. Restore dependencies
dotnet restore

# 5. Apply database migrations
cd FloodManagementSystem
dotnet ef database update

# 6. Run the application
dotnet run

# Access the application at:
# - Web: https://localhost:5001 or http://localhost:5293
# - API Docs: https://localhost:5001/api/docs
```

### Docker Setup

```bash
# Build and run with Docker Compose
docker-compose up -d

# Access at: http://localhost:8080
# Swagger: http://localhost:8080/api/docs

# View logs
docker-compose logs -f

# Stop containers
docker-compose down
```

### Default Admin Credentials
```
Email: admin@gdms.com
Password: Admin@123
```

⚠️ **Important**: Change default admin password on first login!

---

## 📚 API Documentation

The system exposes RESTful APIs for external integrations:

### IoT Sensor Endpoints
```http
POST   /api/IoTSensor/{type}/register        # Register new sensor
POST   /api/IoTSensor/{deviceId}/{type}      # Submit sensor reading
GET    /api/IoTSensor/{sensorId}/latest      # Get latest reading
GET    /api/IoTSensor/{sensorId}/history     # Historical data
GET    /api/IoTSensor/active                 # List active sensors
```

### Communication APIs
```http
POST   /api/Sms/send                         # Send SMS
POST   /api/Sms/send-bulk                    # Bulk SMS
POST   /api/WhatsApp/send                    # WhatsApp message
POST   /api/Voice/call                       # Voice call
POST   /api/Push/send                        # Push notification
```

### Emergency Management
```http
GET    /api/Incidents                        # List incidents
POST   /api/Incidents                        # Report incident
GET    /api/Incidents/{id}                   # Incident details
PUT    /api/Incidents/{id}                   # Update incident
GET    /api/Shelters                         # List shelters
GET    /api/Shelters/nearby                  # Find nearby shelters
POST   /api/Shelters                         # Create shelter (admin)
GET    /api/Predictions/flood-risk/{cityId}  # Flood risk prediction
```

### SignalR Hubs (WebSocket)
- `DisasterAlertHub` - Real-time disaster alerts and notifications
- `IoTMonitoringHub` - Live sensor data streaming

**Full API Documentation**: Access Swagger UI at `/api/docs` when running the application.

---

## 🏛️ System Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                        Presentation Layer                    │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐     │
│  │  MVC Views   │  │  REST API    │  │  SignalR     │     │
│  │  (Razor)     │  │  (JSON)      │  │  (WebSocket) │     │
│  └──────────────┘  └──────────────┘  └──────────────┘     │
└─────────────────────────────────────────────────────────────┘
                           │
┌─────────────────────────────────────────────────────────────┐
│                      Application Layer                       │
│  ┌──────────────────────────────────────────────────────┐  │
│  │              Controllers (30+)                        │  │
│  │  Admin • Incidents • Shelters • IoT • Analytics      │  │
│  └──────────────────────────────────────────────────────┘  │
│  ┌──────────────────────────────────────────────────────┐  │
│  │              Services (15+)                           │  │
│  │  Incident • Shelter • IoT • SMS • ML • Analytics     │  │
│  └──────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
                           │
┌─────────────────────────────────────────────────────────────┐
│                         Data Layer                           │
│  ┌──────────────────────────────────────────────────────┐  │
│  │       Repositories (Repository Pattern)               │  │
│  └──────────────────────────────────────────────────────┘  │
│  ┌──────────────────────────────────────────────────────┐  │
│  │       Entity Framework Core (ORM)                     │  │
│  └──────────────────────────────────────────────────────┘  │
│  ┌──────────────────────────────────────────────────────┐  │
│  │       SQL Server Database                             │  │
│  │  50+ Tables • Migrations • Stored Procedures          │  │
│  └──────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
                           │
┌─────────────────────────────────────────────────────────────┐
│                    External Integrations                     │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐  ┌──────────┐  │
│  │  Twilio  │  │ Firebase │  │  ML.NET  │  │   IoT    │  │
│  │ SMS/Voice│  │   FCM    │  │ Predict  │  │ Sensors  │  │
│  └──────────┘  └──────────┘  └──────────┘  └──────────┘  │
└─────────────────────────────────────────────────────────────┘
```

### Key Design Patterns
- **MVC Pattern**: Separation of concerns (Model-View-Controller)
- **Repository Pattern**: Data access abstraction
- **Dependency Injection**: Loose coupling and testability
- **Service Layer**: Business logic encapsulation
- **Unit of Work**: Transaction management

---

## 🗂️ Project Structure

```
FloodManagementSystem/
├── Controllers/              # MVC & API Controllers (30+)
│   ├── AdminController.cs
│   ├── IncidentController.cs
│   ├── ShelterController.cs
│   ├── IoTMonitoringController.cs
│   └── API/                  # REST API Controllers
├── Models/                   # Data models and entities (50+)
│   ├── Incident.cs
│   ├── EmergencyShelter.cs
│   ├── IoTSensorReading.cs
│   └── DTO/                  # Data transfer objects
├── Views/                    # Razor views
│   ├── Incident/
│   ├── Shelter/
│   ├── Admin/
│   └── Shared/
├── Services/                 # Business logic
│   ├── Interfaces/
│   └── Implementations/
├── Repositories/             # Data access
│   ├── Interfaces/
│   └── Implementations/
├── Data/                     # EF Core context & migrations
│   ├── DisasterDbContext.cs
│   ├── Migrations/
│   └── Seeders/
├── Hubs/                     # SignalR hubs
│   ├── DisasterAlertHub.cs
│   └── IoTMonitoringHub.cs
├── Resources/                # Multi-language resources
│   ├── SharedResource.en.resx
│   ├── SharedResource.fr.resx
│   └── ... (8 languages)
├── wwwroot/                  # Static files
│   ├── css/
│   ├── js/
│   └── uploads/
└── appsettings.json          # Configuration

FloodManagementSystem.Tests/  # Unit tests
├── Controllers/
├── Services/
└── Repositories/

docs/                         # Documentation
├── progress/                 # Development progress logs
│   ├── PHASE_4_MOBILE_APPS_PROGRESS.md
│   └── PHASE_5_ANALYTICS_COMPLETE.md
├── DEPLOYMENT.md             # Deployment guide
└── QUICK_START.md            # Quick start guide
```

---

## 🧪 Testing

The project includes a comprehensive test suite using xUnit:

```bash
# Run all tests
cd FloodManagementSystem.Tests
dotnet test

# Run tests with coverage
dotnet test /p:CollectCoverage=true /p:CoverageReportFormat=cobertura

# Run specific test class
dotnet test --filter "FullyQualifiedName~ShelterControllerTests"
```

### Test Coverage
- Controllers: Unit tests for all major controllers
- Services: Business logic validation
- Repositories: Data access tests
- Integration: End-to-end API tests

---

## 🐳 Docker Deployment

### Using Docker Compose (Recommended)

```bash
# Start all services
docker-compose up -d

# View logs
docker-compose logs -f app

# Stop services
docker-compose down

# Rebuild after changes
docker-compose up -d --build
```

### Manual Docker Build

```bash
# Build image
docker build -t gdms:latest .

# Run container
docker run -d -p 8080:8080 \
  -e ConnectionStrings__DefaultConnection="your-connection-string" \
  gdms:latest
```

---

## 📖 Additional Documentation

- **[Quick Start Guide](QUICK_START.md)** - Detailed setup instructions
- **[Deployment Guide](DEPLOYMENT.md)** - Production deployment
- **[API Documentation](https://localhost:5001/api/docs)** - Interactive Swagger docs
- **[Progress Logs](docs/progress/)** - Development history and phase completions

---

## 🤝 Contributing

This is a personal project that began as academic work. Contributions, suggestions, and feedback are welcome!

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 🙏 Acknowledgments

- **Babcock University** - Computer Science Department, where the original project began
- **Twilio** - Communication APIs
- **Firebase** - Push notification infrastructure
- **Microsoft** - .NET platform and Azure services
- **Open Source Community** - Various libraries and tools

---

## 📞 Contact

**Author:** Ebenezer Doutimiwei ([@Karinateii](https://github.com/Karinateii))  
**Original project:** Babcock University, Ilishan-Remo, Ogun State, Nigeria (2023)

**Repository:** [https://github.com/Karinateii/FloodManagementSystem](https://github.com/Karinateii/FloodManagementSystem)

---

## 📊 Project Statistics

- **Lines of Code**: ~50,000+
- **Controllers**: 30+
- **Models**: 50+
- **Services**: 15+
- **Database Tables**: 50+
- **API Endpoints**: 100+
- **Supported Languages**: 8
- **Test Coverage**: Growing

---

**Built by Ebenezer**
