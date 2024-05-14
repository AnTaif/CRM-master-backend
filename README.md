# МастерскаЯ (Backend)

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
DATABASE_NAME=master-crm-db
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

Once the webapi is running, you can access it at [http://localhost:8080](http://localhost:8080/swagger/index.html)

To stop the application and remove the containers, run:
```bash
docker compose down
```

