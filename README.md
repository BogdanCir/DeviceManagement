# Device Management System

A full-stack web application for tracking company mobile devices — their details, location, and current user assignment.

## Tech Stack

- **Backend:** .NET
- **Frontend:** Angular 21
- **Database:** Microsoft SQL Server (Express)
- **Auth:** ASP.NET Core Identity + JWT Bearer tokens
- **AI:** Google Gemini API

## Prerequisites

- [.NET 8 SDK]
- [Node.js]
- [Angular CLI] (`npm install -g @angular/cli`)
- SQL Server Express (local instance `localhost\SQLEXPRESS`)
- A free [Google Gemini API key](https://aistudio.google.com/)

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/<your-username>/DeviceManagement.git
cd DeviceManagement
```

### 2. Configure the backend

Open `DeviceManagement.API/appsettings.json` and update:

- **Connection string** — adjust `Server=localhost\SQLEXPRESS` if your SQL Server instance name is different
- **Gemini API key** — replace the `ApiKey` value with your own key from Google AI Studio

### 3. Run the backend

```bash
cd DeviceManagement.API
dotnet run
```

The API starts at `http://localhost:5213`. On first run, EF Core automatically creates the database, applies migrations, and seeds it with dummy data (10 devices).

### 4. Run the frontend

```bash
cd DeviceManagement.UI
npm install
ng serve
```

Open `http://localhost:4200` in your browser. The Angular dev server proxies API requests to the backend automatically.

## SQL Scripts

Idempotent SQL scripts are available in the `scripts/` folder if you prefer manual DB setup:

```bash
sqlcmd -S localhost\SQLEXPRESS -i scripts/01_create_database.sql
sqlcmd -S localhost\SQLEXPRESS -i scripts/02_create_tables.sql
sqlcmd -S localhost\SQLEXPRESS -i scripts/03_seed_data.sql
```

## Features

### Phase 1 — Backend CRUD + API

- RESTful API for devices (GET, POST, PUT, DELETE)
- EF Core with SQL Server, auto-migration on startup
- Idempotent SQL scripts for DB creation and seeding
- Seed data with 10 realistic devices

### Phase 2 — Angular UI

- Device list with assigned user display
- Device detail view with all specifications
- Create / edit forms with validation and duplicate name check
- Delete with confirmation dialog

### Phase 3 — Authentication + Authorization

- User registration and login with JWT tokens
- Protected routes (create/edit require login)
- Device assign to yourself / unassign from yourself
- Navigation bar with user info and logout

### Phase 4 — AI Integration

- One-click AI description generator using Google Gemini
- Generates professional descriptions from device specs
