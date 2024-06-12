# MasterskaYa (Backend)

MasterskaYa is a web application where master craftsmen can upload their products, accept applications for them and maintain a customer base.

[Link to the Angular frontend project](https://github.com/1zbbxzak1/CRM-master-frontend)

_Developed for the UrFu Project-Practice 2024 (4th semester)_

## Tech Stack

**Frameworks & Libraries:** 
- .NET 8
- Swagger (Swashbuckle)
- Entity Framework Core 8
- ASP.NET Core Identity 8
- MailKit (for email delivery)
- DotNetEnv (for secrets & db configuration in .env files)

**Database:** PostgreSQL

**Deployment:** Docker Compose

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/AnTaif/CRM-master-backend
    ```
2. Navigate to the project directory:
    ```bash
    cd CRM-master-backend
    ```
3. Create .env file with following structure:

```
DATABASE_NAME=postgres
DATABASE_USER=postgres
DATABASE_PASSWORD="password"

VK_SERVICE_TOKEN=token
VK_API_VERSION=5.199

SMTP_USER=jamarcus17@ethereal.email
SMTP_PASSWORD=JeHtDvjWf3GvmKpzeZ
```

4. Build and run the application using Docker Compose:
```bash
docker compose up -d
```

Once the webapi is running, you can access it at [http://localhost:8080](http://localhost:8080) or swagger docs at [http://localhost:8080/swagger](http://localhost:8080/swagger/index.html) 

To stop the application and remove the containers, run:
```bash
docker compose down
```
