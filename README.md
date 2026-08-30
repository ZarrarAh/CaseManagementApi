# CaseManagementApi

A small CRUD API built with ASP.NET Core, created as a practice project while preparing for a developer interview.

## Overview

Implements basic case management with the following endpoints:

- `GET /api/cases` - retrieve all cases
- `GET /api/cases/{id}` - retrieve a single case
- `POST /api/cases` - create a new case
- `PUT /api/cases/{id}/status` - update a case's status

Built to refresh hands-on C#/.NET skills, including dependency injection, REST API design, and proper HTTP status codes.

## Tech stack

- ASP.NET Core Web API (.NET 8)
- Swagger / OpenAPI for API testing and documentation

## Running the project

Open in Visual Studio and run, or use:

```bash
dotnet run
```

Swagger UI will be available for testing the endpoints directly in the browser.

## Notes

Data is currently stored in memory and resets on restart. A natural next step would be adding a real database (e.g. Entity Framework Core with PostgreSQL) and validation rules.
