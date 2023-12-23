# IdeoDigital Task

This project includes a .NET Web API backend and an Angular frontend. Below are the instructions for setting up and running both parts of the project.

## Backend (.NET Web API)

### Prerequisites
* .NET SDK 7.0
* Entity Framework Core CLI 17.0

### Running the Project

Navigate to the Backend Project Directory
```bash
cd InvoicesApi/
```

Restore Dependencies
```bash
dotnet restore
```

Run Migrations
```bash
dotnet ef database update
```

Run the API
```bash
dotnet run
```

The .NET Web API will start running on http://localhost:5111.

## Frontend (Angular)

### Prerequisites
* Node.js 16.x
* Angular CLI 15.0

### Running the Project

Clone the Repository (if not done already)

Navigate to the Frontend Project Directory
```bash
cd InvoicesApp/
```

Install Dependencies
```bash
npm install
```

Run the Angular App
```bash
ng serve
```

The Angular application will start running on http://localhost:4200.

## Notes
* Ensure that the .NET backend API is running before starting the Angular frontend to allow API calls to be made successfully.
* The ports mentioned above are the default ones. If you have changed the ports in your configuration, adjust the URLs accordingly. including Cors for backend and angular's enviroment variables
* For detailed information about the API endpoints, refer to the Swagger documentation at http://localhost:5111/swagger.