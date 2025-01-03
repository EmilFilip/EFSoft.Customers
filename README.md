# EFSoft.Customers

EFSoft.Customers is a .NET-based web API designed to manage customer-related operations. 
Built with C# and minimal APIs, it provides a robust foundation for handling customer data efficiently.

## Features

- **Minimal API Architecture**: Utilizes .NET's minimal APIs for streamlined and efficient endpoint management.
- **CRUD Operations**: Supports Create, Read, Update, and Delete operations for customer entities.
- **Entity Framework Core Integration**: Leverages EF Core for object-database mapping and data persistence.
- **CQRS Pattern**: Implements the Command Query Responsibility Segregation pattern for clear separation between read and write operations.
- **Docker Support**: Includes a Dockerfile for containerization, facilitating easy deployment.
- **Kubernetes Deployment**: Contains Kubernetes deployment configurations for scalable orchestration.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started) (optional, for containerization)
- [Kubernetes](https://kubernetes.io/docs/setup/) (optional, for orchestration)

### Installation

1. **Clone the Repository**:
   git clone https://github.com/EmilFilip/EFSoft.Customers.git
   cd EFSoft.Customers
2. Restore Dependencies: dotnet restore
3. Build the Solution: dotnet build
4. Apply Migrations and Update Database:
Ensure your database is configured correctly in appsettings.json, then run: dotnet ef database update
5. Run the Application: dotnet run --project EFSoft.Customers.Api
The API should now be accessible at https://localhost:5001.

Usage
API Endpoints
- GET /customers: Retrieve a list of all customers.
- GET /customers/{id}: Retrieve details of a specific customer by ID.
- POST /customers: Create a new customer.
- PUT /customers/{id}: Update an existing customer's information.
- DELETE /customers/{id}: Delete a customer by ID.
  
Request and Response Format
All endpoints accept and return JSON-formatted data. Ensure that the Content-Type header is set to application/json for requests that include a body.

Docker Deployment
To build and run the application using Docker:
1.Build the Docker Image:
docker build -t efsoft-customers .
2.Run the Docker Container:
docker run -d -p 5000:80 efsoft-customers
The API will be accessible at http://localhost:5000.

Kubernetes Deployment
For deploying to a Kubernetes cluster:
1.Apply the Deployment Configuration:
kubectl apply -f k8s-deployment.yaml
2.Verify Deployment:
kubectl get pods
Once the pods are running, the service should be available based on your Kubernetes setup.

Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes. Ensure that your code adheres to the existing style and includes appropriate tests.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For questions or support, please open an issue in this repository.

This `README.md` provides an overview of your project, instructions for setup and deployment, and guidance for potential contributors.
 
