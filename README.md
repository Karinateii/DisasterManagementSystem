# Global Disaster Management System

A web platform for coordinating disaster response: incident reports, shelters, sensor monitoring and emergency alerts over SMS, WhatsApp, USSD, voice calls and push notifications.

![.NET](https://img.shields.io/badge/.NET-8-512BD4) [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

## Background

This started as my 2023 final-year project at Babcock University: a flood management system for local government areas in Lagos. In late 2025 I extended it into a platform for several disaster types, adding shelter management, IoT sensor monitoring, alerts over several channels, and analytics.

The idea behind the alert channels is reach. A lot of people in the areas most affected by flooding don't have smartphones or reliable data, so alerts go out over plain SMS, USSD menus and voice calls as well as the web and push notifications.

## Features

**Emergency response**
- Supports floods, earthquakes, fires, hurricanes, tsunamis and landslides
- Citizens can report incidents with photos and GPS location
- Live alerts on dashboards through SignalR
- Separate admin and citizen views

**Shelters**
- Register shelters with location, amenities and accessibility details
- Track capacity and occupancy as people check in and out, individually or as families
- Find nearby shelters on a map

**Alerts and communication**
- Bulk SMS, WhatsApp messages and automated voice calls through Twilio
- USSD menus for feature phones with no internet
- Push notifications through Firebase
- Email through SMTP
- Interface and messages in 8 languages: English, French, Arabic, Spanish, Portuguese, Hausa, Yoruba and Igbo

**Monitoring and prediction**
- REST endpoints for water level, rainfall and weather sensor readings
- Live sensor dashboards with Chart.js
- Threshold alerts when readings cross a danger level
- Flood risk prediction with an ML.NET classifier trained on historical data

## Tech stack

- ASP.NET Core 8 MVC, Entity Framework Core 8
- SQLite (default, for local use)
- SignalR for real-time updates
- ML.NET for flood risk prediction
- Twilio and Africa's Talking, Firebase Cloud Messaging, SMTP email
- Bootstrap 5, Chart.js, Leaflet
- Serilog for logging, Swagger for API docs
- Docker and GitHub Actions

The project has 24 controllers and about 166 API and page endpoints.

## Running it

You need the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
git clone https://github.com/Karinateii/DisasterManagementSystem.git
cd DisasterManagementSystem/FloodManagementSystem
dotnet run
```

The SQLite database (`disastermanagement.db`) is created automatically on first run, along with SMS templates and an admin account:

```
Email:    admin@disastermgt.com
Password: Admin@123
```

Change that password if you deploy it anywhere.

The app runs without any external accounts. To turn on SMS, WhatsApp, voice, push or email, add your Twilio, Firebase and SMTP details in `FloodManagementSystem/appsettings.json`, or better, in environment variables or `dotnet user-secrets` so keys stay out of the repo.

API documentation is at `/api/docs` once it's running.

With Docker:

```bash
docker-compose up -d
```

Deployment notes are in [DEPLOYMENT.md](DEPLOYMENT.md).

Tests (xUnit, 24 tests) run on every push through GitHub Actions:

```bash
dotnet test FloodManagementSystem.Tests
```

## API overview

| Area | Examples |
|---|---|
| Sensors | submit readings, get latest readings, sensor history |
| Alerts | send SMS, WhatsApp and voice alerts, manage templates |
| USSD | session callback for the USSD menu |
| Incidents | create and update reports, upload photos |
| Shelters | list shelters, check people in and out |
| Real time | `/disasterAlertHub`, `/iotMonitoringHub` (SignalR) |

The full list is in Swagger at `/api/docs`.

## Status

Working: the features above.

Still to do:
- Mobile apps
- Evacuation route planning
- More training data for the prediction model

## License

MIT, see [LICENSE](LICENSE).
